using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Model;
using VedSoft.Data.Contracts.User;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VedSoft.Model.Login;
using VedSoft.Model.User;
using VedSoft.Model.Common;
using VedSoft.Utility.Constants;
using VedSoft.Utility;
using ppp=MySql.Data.MySqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
//using MySql.Data.EntityFrameworkCore;

namespace VedSoft.Data.Repository.Repository.User
{
    public class OracleDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();
        private readonly List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();

        public void Add(string name, MySqlDbType oracleDbType, ParameterDirection direction, object value = null, int? size = null)
        {
            MySqlParameter oracleParameter;
            if (size.HasValue)
            {
                oracleParameter = new MySqlParameter();
                oracleParameter.ParameterName = name;
                oracleParameter.Direction = direction;
                oracleParameter.Value = value;
                oracleParameter.MySqlDbType = oracleDbType;
                oracleParameter.Size = size.Value;
            }
            else
            {
                //oracleParameter = new MySqlParameter(name, oracleDbType, value, direction);
                oracleParameter = new MySqlParameter();
                oracleParameter.ParameterName = name;
                oracleParameter.Direction = direction;
                //oracleParameter.Value = value;
                //oracleParameter.Size = size.Value;
            }

            mySqlParameters.Add(oracleParameter);
        }

        public void Add(string name, MySqlDbType oracleDbType, ParameterDirection direction)
        {
            MySqlParameter oracleParameter = new MySqlParameter();
            oracleParameter.ParameterName = name;
            oracleParameter.Direction = direction;
            //oracleParameter.Value = value;
            oracleParameter.MySqlDbType = oracleDbType;
            //oracleParameter.Size = size.Value;
            mySqlParameters.Add(oracleParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);

            var oracleCommand = command as MySqlCommand;

            if (oracleCommand != null)
            {
                oracleCommand.Parameters.AddRange(mySqlParameters.ToArray());
            }
        }
    }
    public class UserRepository : RepositoryBase<UserMasterDB>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public UserModel Authenticate(RequestModel<LoginRequestModel> loginRequestModel)
        {
            var user = this.RepositoryContext.User;
            var userDetails = this.RepositoryContext.UserDetails;
            var userModel = (from u in user
                     where u.LoginId.ToLower() == loginRequestModel.RequestParameter.UserName.ToLower()
                     && u.CustomerId == loginRequestModel.CustomerId
                           //&& u.Password == loginRequestModel.Password
                     join ud in userDetails on u.UserId equals ud.UserId into usr
                     from udd in usr.DefaultIfEmpty()
                     select new UserModel
                     {
                         Id=u.UserId,
                         NotificationEmailId = u.NotificationEmailId,
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         MiddleName = u.MiddleName,
                         UserName = u.LoginId,
                         LastLoginDate = udd.LastLoginDate,
                         PasswordExpiryDate = udd.PasswordExpirationDate??DateTime.Now.AddDays(100),
                         TemproryPassword = udd.IsTemproryPassword,
                         LockAttempts = udd.LockAttemptCount,
                         Password = u.Password,
                         Active = u.Active,
                         UserDetailsId = udd.Id
                     }).FirstOrDefault();

            return userModel;
        }

        public UserModel GetUserIdByLoginId(int userId)
        {
            var userModel = this.RepositoryContext.User.Where(x => x.UserId == userId).Select(u => new UserModel
            {
                Id = u.UserId,
                NotificationEmailId = u.NotificationEmailId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                MiddleName = u.MiddleName,
                UserName = u.LoginId,
                Password = u.Password,
                Active = u.Active,
            }).FirstOrDefault();
            return userModel;
        }

        public bool UpdateLockAttempt(int userId)
        {
            var user = this.RepositoryContext.UserDetails.Where(x => x.UserId==userId).FirstOrDefault();
            if(user!=null)
            {
                user.LockAttemptCount++;
            }

            this.RepositoryContext.Update(user);

            return true;
        }

        public bool UpdatePassword(SetPasswordRequestModel input) {
            var user = this.RepositoryContext.User.Where(x => x.UserId == input.UserId).FirstOrDefault();
            if (user != null)
            {
                user.Password = input.NewPassword;
                user.ModifiedBy = input.LoginUserId;
                user.ModifiedDate = DateTime.Now;
            }
            this.RepositoryContext.Update(user);

            return true;
        }


        public int AddUser(RequestModel<UserModel> input)
        {
            //Make db object
            UserMasterDB userMaster = new UserMasterDB
            {
                CreatedBy = input.LoginUserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                Address = input.RequestParameter.Address,
                ContactNo = input.RequestParameter.ContactNumber,
                FirstName = input.RequestParameter.FirstName,
                LastName = input.RequestParameter.LastName,
                LoginId = input.RequestParameter.UserName,
                MiddleName = input.RequestParameter.MiddleName,
                NotificationEmailId = input.RequestParameter.NotificationEmailId,
                Password = input.RequestParameter.Password,
                UserTypeId = input.RequestParameter.UserTypeId,
                CustomerId = input.CustomerId,
                
                

            };

            //Save in database
            this.RepositoryContext.Add(userMaster);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = userMaster.UserId;

            return userMaster.UserId;
        }

        public int UpdateUser(RequestModel<UserModel> input)
        {
            var user = this.RepositoryContext.User
                            .Where(x => x.UserId == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (user != null)
            {
                user.Address = input.RequestParameter.Address;
                user.ContactNo = input.RequestParameter.ContactNumber;
                user.FirstName = input.RequestParameter.FirstName;
                user.LastName = input.RequestParameter.LastName;
                if(!string.IsNullOrEmpty(input.RequestParameter.UserName))
                    user.LoginId = input.RequestParameter.UserName;
                user.MiddleName = input.RequestParameter.MiddleName;
                user.NotificationEmailId = input.RequestParameter.NotificationEmailId;
                if (!string.IsNullOrEmpty(input.RequestParameter.Password))
                    user.Password = input.RequestParameter.Password;
                user.UserTypeId = input.RequestParameter.UserTypeId;
                user.ModifiedBy = input.RequestParameter.ActionUserId;
                user.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(user);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<UserModel> GetUserList(SearchRequestModel<UserModel> input)
        {
            List<UserModel> userList = new List<UserModel>();

            userList = (from u in this.RepositoryContext.User.Where(x => x.CustomerId == input.CustomerId && x.Active == CommonConstants.ActiveStatus)
                             join udd in this.RepositoryContext.UserDetails on u.UserId equals udd.UserId
                             select new UserModel
                             {
                                 Id = u.UserId,
                                 NotificationEmailId = u.NotificationEmailId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 MiddleName = u.MiddleName,
                                 UserName = u.LoginId,
                                 LastLoginDate = udd.LastLoginDate,
                                 PasswordExpiryDate = udd.PasswordExpirationDate,
                                 TemproryPassword = udd.IsTemproryPassword,
                                 LockAttempts = udd.LockAttemptCount,
                                 Password = u.Password,
                                 Active = u.Active,
                                 UserDetailsId = udd.Id,
                                 Address = u.Address,
                                 ContactNumber = u.ContactNo,
                                 UserTypeId = u.UserTypeId.GetValueOrDefault(),

                             }).Page(input.PageSize, input.PageNumber).ToList();

            
            return userList;
        }

        public int MakeInActiveUser(RequestModel<UserModel> input)
        {
            var user = this.RepositoryContext.User
                                    .Where(x => x.UserId == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (user != null)
            {
                user.Active = CommonConstants.InActiveStatus;
                user.ModifiedBy = input.RequestParameter.ActionUserId;
                user.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(user);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesUserExist(RequestModel<UserModel> input)
        {
            return this.RepositoryContext.User
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.LoginId == input.RequestParameter.UserName
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        public bool DoesUserExistUpdate(RequestModel<UserModel> input)
        {
            return this.RepositoryContext.User
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.LoginId == input.RequestParameter.UserName
                                  && x.UserId != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesUserIdExist(RequestModel<UserModel> input)
        {
            return this.RepositoryContext.User
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.UserId == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }

    public class StudentRepository : RepositoryBase<StudentDB>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        IUserRepository UserRepository { get; set; }
        public int AddStudent(RequestModel<StudentAdmissionModel> input)
        {
            string studentJSON = Utility.SerializeObjects.SerializeJsonObject.GetJsonValue(input.RequestParameter);
            var Parameters = new DynamicParameters();
            Parameters.Add("P_STUDENT_OBJECT", studentJSON, DbType.String, ParameterDirection.Input);
            Parameters.Add("P_OUT_FLAG", "", DbType.String, ParameterDirection.Output);
            Parameters.Add("P_OUT_STUDENTID", 0, DbType.Int32, ParameterDirection.Output);

            List<int> returnValue=this.RepositoryContext.ExecuteSP<int>(Parameters, "SP_CREATE_STUDENT").ToList();

            return (Parameters.Get<Int32>("P_OUT_STUDENTID"));
        }

        public int UpdateStudent(RequestModel<StudentModel_Old> input)
        {
            var student = this.RepositoryContext.Student
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (student != null)
            {
                //student.UserId = input.RequestParameter.UserId;
                if (input.RequestParameter.GuardianUser != null && input.RequestParameter.GuardianUser.Id > 0)
                    student.GuardinanUserId = input.RequestParameter.GuardianUser.Id;
                //if (input.RequestParameter.FatherUser != null && input.RequestParameter.FatherUser.Id > 0)
                //    student.FatherUserId = input.RequestParameter.FatherUser.Id;
                student.IsEnrolled = input.RequestParameter.IsEnrolled;
                //if (input.RequestParameter.MotherUser != null && input.RequestParameter.MotherUser.Id > 0)
                //    student.MotherUserId = input.RequestParameter.MotherUser.Id;
                student.ModifiedBy = input.RequestParameter.ActionUserId;
                student.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(student);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<StudentViewModel> GetStudentList(SearchRequestModel<StudentViewModel> input)
        {
            string query = string.Format(@"SELECT @@COLUMNNAME@@
                            FROM STUDENT s JOIN USER_MASTER u ON s.user_id=u.id
                            JOIN STUDENT_BRANCHES sb ON sb.student_id=s.id
                            JOIN CUSTOMER_BRANCHES b ON sb.branch_id=b.id
                            WHERE (0={0} OR u.customer_id={0}) 
                                AND (0={1} OR u.id={1}) 
                                AND (0={2} OR s.id={2}) 
                                AND (0={3} OR sb.branch_id={3}) 
                                ORDER BY s.id 
                             LIMIT {4},{5}", input.CustomerId,
                             input.RequestParameter.UserId,
                             input.RequestParameter.StudentId,
                             input.RequestParameter.BranchId,
                             PagingUtils.MySQLStartLimit(input.PageNumber, input.PageSize),
                             input.PageSize);

            #region total record count
            string queryCount = query.Replace("@@COLUMNNAME@@", " count(s.id) studentCount ");
            var studentCount = this.RepositoryContext.ExecuteSqlQuery<Int32>(queryCount).FirstOrDefault();
            #endregion

            string studentListquery = query.Replace("@@COLUMNNAME@@", @" s.id  StudentId,u.id  UserId,u.first_name FirstName,u.middle_name MiddleName,u.last_name LastName,
                            u.primary_contactno PrimaryContact, u.login_id LoginId, u.notification_id NotificationId, sb.branch_id BranchId,
                            b.name BranchName "); 
            List<StudentViewModel> studentList = this.RepositoryContext.ExecuteSqlQuery<StudentViewModel>(studentListquery).ToList();
            //add the counter property...need to relook
            studentList.ForEach(x => x.Counter = studentCount);

            return studentList;
        }

        public StudentAdmissionModel GetStudentDetails(SearchRequestModel<StudentViewModel> input)
        {
            StudentAdmissionModel studentAdmissionDetails = (from s in this.RepositoryContext.Student.Where(x => x.Id == input.RequestParameter.StudentId && x.Active == CommonConstants.ActiveStatus)
                                                             join sd in this.RepositoryContext.StudentDetails on s.Id equals sd.StudentId
                                                             join u in this.RepositoryContext.User.Where(p => p.CustomerId == input.CustomerId) on s.UserId equals u.UserId
                                                             join gu in this.RepositoryContext.User.Where(p => p.CustomerId == input.CustomerId) on s.GuardinanUserId equals gu.UserId
                                                             join sb in this.RepositoryContext.StudentBranches on s.Id equals sb.StudentId
                                                             join cb in this.RepositoryContext.CustomerBranch on sb.BranchId equals cb.Id
                                                             select new StudentAdmissionModel
                                                             {
                                                                 StudentDetails = new StudentBaseModel
                                                                 {
                                                                     //BranchId=sb.BranchId,
                                                                     //BranchName=cb.Name,
                                                                     DateOfBirth = sd.DateOfBirth,
                                                                     FirstName = u.FirstName,
                                                                     ImageName = sd.StudentImagePath,
                                                                     LastName = u.LastName,
                                                                     LoginId = u.LoginId,
                                                                     MiddleName = u.MiddleName,
                                                                     NotificationId = u.NotificationEmailId,
                                                                     Password = u.Password,
                                                                     PrimaryContact = u.PrimaryContactNo,
                                                                     StudentId = s.Id,
                                                                     //UserId = u.UserId,
                                                                     Details = new UserAdditionalDetailsModel
                                                                     {
                                                                         Address = new AddressModel
                                                                         {
                                                                             Address1 = u.Address
                                                                         },
                                                                         ContactNumber = new ContactNumberModel
                                                                         {

                                                                             Landline = u.ContactNo
                                                                         },
                                                                         Qualification = sd.StudentQualification,

                                                                     },
                                                                     Father = new ParentModel
                                                                     {
                                                                         AnnualIncome = sd.FatherAnnualIncome,
                                                                         FirstName = sd.FatherFirstName,
                                                                         LastName = sd.FatherLastName,
                                                                         MiddleName = sd.FatherMiddleName,
                                                                         //PrimaryContact = sd.FatherContactNo,
                                                                         Qualification = sd.FatherQualification,
                                                                     },
                                                                     Mother = new ParentModel
                                                                     {
                                                                         AnnualIncome = sd.MotherAnnualIncome,
                                                                         FirstName = sd.MotherFirstName,
                                                                         LastName = sd.MotherLastName,
                                                                         MiddleName = sd.MotherMiddleName,
                                                                         //PrimaryContact = sd.MotherContactNo,
                                                                         Qualification = sd.MotherQualification,
                                                                     },
                                                                 },
                                                                 AcademicInstituteId = sd.AcademicInstituteId,
                                                                 BranchId = sb.BranchId,
                                                                 CustomerId = u.CustomerId,
                                                                 CreatedBy = s.CreatedBy,
                                                                 CreatedDate = s.CreatedDate,
                                                                 IsEnrolled = s.IsEnrolled,
                                                                 RollNo = s.RollNo,
                                                                 GuardianDetails = new GuardianBaseModel
                                                                 {
                                                                     FirstName = gu.FirstName,
                                                                     Details = new UserAdditionalDetailsModel
                                                                     {
                                                                         Address = new AddressModel { Address1 = gu.Address },
                                                                         ContactNumber = new ContactNumberModel { Landline = gu.ContactNo },
                                                                     },
                                                                     PrimaryContact = gu.PrimaryContactNo,
                                                                     LastName = gu.LastName,
                                                                     LoginId = gu.LoginId,
                                                                     MiddleName = gu.MiddleName,
                                                                     NotificationId = gu.NotificationEmailId,
                                                                     Password = gu.Password,
                                                                 }
                                                             }).FirstOrDefault();

            #region Address & Mobile number serialization
            if (studentAdmissionDetails!=null 
                && studentAdmissionDetails.StudentDetails != null 
                && studentAdmissionDetails.StudentDetails.Details !=null
                && studentAdmissionDetails.StudentDetails.Details.Address != null
                && studentAdmissionDetails.StudentDetails.Details.Address.Address1 != null
                )
            {
                var addressObject = studentAdmissionDetails.StudentDetails.Details.Address;
                AddressModel address = Utility.SerializeObjects.SerializeJsonObject.DeserializeObject<AddressModel>(addressObject.Address1);
                addressObject.Address1 = address.Address1;
                addressObject.Address2 = address.Address2;
                addressObject.City = address.City;
                addressObject.State = address.State;
                addressObject.Pincode = address.Pincode;
            }

            if (studentAdmissionDetails != null
                && studentAdmissionDetails.StudentDetails != null
                && studentAdmissionDetails.StudentDetails.Details != null
                && studentAdmissionDetails.StudentDetails.Details.ContactNumber != null
                && studentAdmissionDetails.StudentDetails.Details.ContactNumber.Landline != null
                )
            {
                var landlineObject = studentAdmissionDetails.StudentDetails.Details.ContactNumber;
                ContactNumberModel contactNumber = Utility.SerializeObjects.SerializeJsonObject.DeserializeObject<ContactNumberModel>(landlineObject.Landline);
                contactNumber.Landline = contactNumber.Landline;
                contactNumber.Mobile = contactNumber.Mobile;
                contactNumber.Mobile2 = contactNumber.Mobile2;
            }

            if (studentAdmissionDetails != null
                && studentAdmissionDetails.GuardianDetails != null
                && studentAdmissionDetails.GuardianDetails.Details != null
                && studentAdmissionDetails.GuardianDetails.Details.Address != null
                )
            {
                var addressObject = studentAdmissionDetails.GuardianDetails.Details.Address;
                AddressModel address = Utility.SerializeObjects.SerializeJsonObject.DeserializeObject<AddressModel>(addressObject.Address1);
                addressObject.Address1 = address.Address1;
                addressObject.Address2 = address.Address2;
                addressObject.City = address.City;
                addressObject.State = address.State;
                addressObject.Pincode = address.Pincode;
            }

            if (studentAdmissionDetails != null
                && studentAdmissionDetails.GuardianDetails != null
                && studentAdmissionDetails.GuardianDetails.Details != null
                && studentAdmissionDetails.GuardianDetails.Details.ContactNumber != null
                && studentAdmissionDetails.GuardianDetails.Details.ContactNumber.Landline != null
                )
            {
                var landlineObject = studentAdmissionDetails.GuardianDetails.Details.ContactNumber;
                ContactNumberModel contactNumber = Utility.SerializeObjects.SerializeJsonObject.DeserializeObject<ContactNumberModel>(landlineObject.Landline);
                landlineObject.Landline = contactNumber.Landline;
                landlineObject.Mobile = contactNumber.Mobile;
                landlineObject.Mobile2 = contactNumber.Mobile2;
            }
            #endregion

            return studentAdmissionDetails;
        }

        public int MakeInActiveStudent(RequestModel<StudentModel_Old> input)
        {
            var student = this.RepositoryContext.Student
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (student != null)
            {
                student.Active = CommonConstants.InActiveStatus;
                student.ModifiedBy = input.RequestParameter.ActionUserId;
                student.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(student);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesStudentExist(RequestModel<StudentModel_Old> input)
        {
            return this.RepositoryContext.Student
                                  .Where(x => x.UserId == input.RequestParameter.User.Id
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        //public bool DoesStudentExistUpdate(RequestModel<UserModel> input)
        //{
        //    return this.RepositoryContext.Student
        //                          .Where(x => x.CustomerId == input.CustomerId
        //                          && x.Active == CommonConstants.ActiveStatus
        //                          && x.LoginId == input.RequestParameter.UserName
        //                          && x.UserId != input.RequestParameter.Id)
        //                          .Count() > 0;
        //}

        public bool DoesStudentIdExist(RequestModel<StudentModel_Old> input)
        {
            return this.RepositoryContext.Student
                                  .Where(x=>x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }

    public class StudentAdmissionRepository : RepositoryBase<StudentAdmissionDetailsDB>, IStudentAdmisionDetailsRepository
    {
        public StudentAdmissionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        IUserRepository UserRepository { get; set; }
        public int AddStudentAdmission(RequestModel<StudentAdmissionModel_Old> input)
        {
            //Make db object
            StudentAdmissionDetailsDB studentAdmissionDB = new StudentAdmissionDetailsDB
            {
                CreatedBy = input.RequestParameter.ActionUserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                ACADEMIC_YEARID = input.RequestParameter.AcademicYearId,
                AdmissionTypeId = input.RequestParameter.AdmissionTypeId,
                BranchId = input.RequestParameter.BranchId,
                DateOfAdmission = input.RequestParameter.DateOfAdmission,
                StudentId = input.RequestParameter.StudentId
            };

            //Save in database
            this.RepositoryContext.Add(studentAdmissionDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = studentAdmissionDB.Id;

            return studentAdmissionDB.Id;
        }

        public int UpdateStudentAdmission(RequestModel<StudentAdmissionModel_Old> input)
        {
            var studentAdmission = this.RepositoryContext.StudentAdmission
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (studentAdmission != null)
            {
                studentAdmission.ModifiedBy = input.RequestParameter.ActionUserId;
                studentAdmission.ModifiedDate = DateTime.Now;
                studentAdmission.ACADEMIC_YEARID = input.RequestParameter.AcademicYearId;
                studentAdmission.AdmissionTypeId = input.RequestParameter.AdmissionTypeId;
                studentAdmission.BranchId = input.RequestParameter.BranchId;
                studentAdmission.DateOfAdmission = input.RequestParameter.DateOfAdmission;
                studentAdmission.StudentId = input.RequestParameter.StudentId;
            }

            //Save in database
            this.RepositoryContext.Update(studentAdmission);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<StudentAdmissionModel_Old> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel_Old> input)
        {
            List<StudentAdmissionModel_Old> userList = new List<StudentAdmissionModel_Old>();
            userList = (from st in this.RepositoryContext.Student
                        join sa in this.RepositoryContext.StudentAdmission
                        .Where(x => x.Active == CommonConstants.ActiveStatus)
                        on st.Id equals sa.StudentId
                        select new StudentAdmissionModel_Old
                        {
                            Id = st.Id,
                            AcademicYearId = sa.ACADEMIC_YEARID,
                            StudentId = sa.StudentId,
                            AdmissionTypeId = sa.AdmissionTypeId,
                            BranchId = sa.BranchId,
                            DateOfAdmission = sa.DateOfAdmission
                        }).Page(input.PageSize, input.PageNumber).ToList();


            return userList;
        }

        public int MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel_Old> input)
        {
            var studentAdmission = this.RepositoryContext.StudentAdmission
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (studentAdmission != null)
            {
                studentAdmission.Active = CommonConstants.InActiveStatus;
                studentAdmission.ModifiedBy = input.RequestParameter.ActionUserId;
                studentAdmission.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(studentAdmission);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesStudentAdmissionExist(RequestModel<StudentAdmissionModel_Old> input)
        {
            return this.RepositoryContext.StudentAdmission
                                  .Where(x => x.StudentId==input.RequestParameter.StudentId
                                  && x.BranchId==input.RequestParameter.BranchId
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        //public bool DoesStudentExistUpdate(RequestModel<UserModel> input)
        //{
        //    return this.RepositoryContext.Student
        //                          .Where(x => x.CustomerId == input.CustomerId
        //                          && x.Active == CommonConstants.ActiveStatus
        //                          && x.LoginId == input.RequestParameter.UserName
        //                          && x.UserId != input.RequestParameter.Id)
        //                          .Count() > 0;
        //}

        public bool DoesStudentAdmissionIdExist(RequestModel<StudentAdmissionModel_Old> input)
        {
            return this.RepositoryContext.StudentAdmission
                                  .Where(x => x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }

    public class StudentCourseRepository : RepositoryBase<StudentCoursesDB>, IStudentCourseRepository
    {
        public StudentCourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        //IUserRepository UserRepository { get; set; }
        public int AddStudentCourse(RequestModel<StudentCourseModel> input)
        {
            //Make db object
            StudentCoursesDB studentCourseDB = new StudentCoursesDB
            {
                CreatedBy = input.RequestParameter.ActionUserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                StudentId = input.RequestParameter.StudentId,
                BranchCourseId = input.RequestParameter.BranchCourseId,
                CourseFeeAmount = input.RequestParameter.CourseFee,
                DiscountAllowed = input.RequestParameter.DiscountAllowed,
                DiscountedFeeAmount = input.RequestParameter.DiscountedFeeAmount,
            };

            //Save in database
            this.RepositoryContext.Add(studentCourseDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = studentCourseDB.Id;

            return studentCourseDB.Id;
        }

        public int UpdateStudentCourse(RequestModel<StudentCourseModel> input)
        {
            var studentCourse = this.RepositoryContext.StudentCourse
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (studentCourse != null)
            {
                studentCourse.ModifiedBy = input.RequestParameter.ActionUserId;
                studentCourse.ModifiedDate = DateTime.Now;
                studentCourse.StudentId = input.RequestParameter.StudentId;
                studentCourse.DiscountAllowed = input.RequestParameter.DiscountAllowed;
                studentCourse.DiscountedFeeAmount = input.RequestParameter.DiscountedFeeAmount;
                studentCourse.StudentId = input.RequestParameter.StudentId;
            }

            //Save in database
            this.RepositoryContext.Update(studentCourse);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<StudentCourseModel> GetStudentCourseList(SearchRequestModel<StudentCourseModel> input)
        {
            List<StudentCourseModel> userList = new List<StudentCourseModel>();
            userList = (from st in this.RepositoryContext.Student
                        join sa in this.RepositoryContext.StudentAdmission
                            .Where(x => x.Active == CommonConstants.ActiveStatus)
                            on st.Id equals sa.StudentId
                        join sc in this.RepositoryContext.StudentCourse.Where(x => x.Active == CommonConstants.ActiveStatus)
                        on sa.StudentId equals sc.StudentId
                        select new StudentCourseModel
                        {
                            Id = st.Id,
                            StudentId = sa.StudentId,
                            BranchCourseId = sc.BranchCourseId,
                            CourseFee = sc.CourseFeeAmount,
                            DiscountAllowed = sc.DiscountAllowed,
                            DiscountedFeeAmount = sc.DiscountedFeeAmount
                        }).Page(input.PageSize, input.PageNumber).ToList();


            return userList;
        }

        public int MakeInActiveStudentCourse(RequestModel<StudentCourseModel> input)
        {
            var studentCourse = this.RepositoryContext.StudentCourse
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (studentCourse != null)
            {
                studentCourse.Active = CommonConstants.InActiveStatus;
                studentCourse.ModifiedBy = input.RequestParameter.ActionUserId;
                studentCourse.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(studentCourse);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesStudentCourseExist(RequestModel<StudentCourseModel> input)
        {
            return this.RepositoryContext.StudentCourse
                                  .Where(x => 
                                  x.StudentId == input.RequestParameter.StudentId
                                  && x.BranchCourseId==input.RequestParameter.BranchCourseId
                                  && x.BranchCourseId == input.RequestParameter.BranchCourseId
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        public bool DoesStudentCourseIdExist(RequestModel<StudentCourseModel> input)
        {
            return this.RepositoryContext.StudentCourse
                                  .Where(x => x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }
}
