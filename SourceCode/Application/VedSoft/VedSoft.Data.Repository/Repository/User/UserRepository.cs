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

namespace VedSoft.Data.Repository.Repository.User
{
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
        public int AddStudent(RequestModel<StudentModel> input)
        {
            //Make db object
            StudentDB studentDB = new StudentDB
            {
                CreatedBy = input.RequestParameter.ActionUserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                //FatherUserId = input.RequestParameter.FatherUserId,
                //MotherUserId = input.RequestParameter.MotherUserId,
                UserId = input.RequestParameter.User.Id,
                //GuardinanUserId = input.RequestParameter.UserId,
                IsEnrolled = input.RequestParameter.IsEnrolled,
            };

            //Save in database
            this.RepositoryContext.Add(studentDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = studentDB.Id;

            return studentDB.UserId;
        }

        public int UpdateStudent(RequestModel<StudentModel> input)
        {
            var student = this.RepositoryContext.Student
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (student != null)
            {
                //student.UserId = input.RequestParameter.UserId;
                if (input.RequestParameter.GuardianUser != null && input.RequestParameter.GuardianUser.Id > 0)
                    student.GuardinanUserId = input.RequestParameter.GuardianUser.Id;
                if (input.RequestParameter.FatherUser != null && input.RequestParameter.FatherUser.Id > 0)
                    student.FatherUserId = input.RequestParameter.FatherUser.Id;
                student.IsEnrolled = input.RequestParameter.IsEnrolled;
                if (input.RequestParameter.MotherUser != null && input.RequestParameter.MotherUser.Id > 0)
                    student.MotherUserId = input.RequestParameter.MotherUser.Id;
                student.ModifiedBy = input.RequestParameter.ActionUserId;
                student.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(student);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<StudentModel> GetStudentList(SearchRequestModel<StudentModel> input)
        {
            List<StudentModel> userList = new List<StudentModel>();
            userList = (from st in this.RepositoryContext.Student//.Where(x => x.Id == input.RequestParameter.Id)
                            join u in this.RepositoryContext.User.Where(x => x.CustomerId == input.CustomerId
                            && x.Active == CommonConstants.ActiveStatus) on st.UserId equals u.UserId
                            //join udd in this.RepositoryContext.UserDetails on u.UserId equals udd.UserId
                            select new StudentModel
                            {
                                Id = st.Id,
                                FatherUser = new UserModel(),
                                MotherUser = new UserModel(),
                                GuardianUser = new UserModel(),
                                IsEnrolled = st.IsEnrolled,
                                User = new UserModel() {
                                    Id = u.UserId,
                                    NotificationEmailId = u.NotificationEmailId,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    MiddleName = u.MiddleName,
                                    UserName = u.LoginId,
                                    Password = u.Password,
                                    Active = u.Active,
                                }
                                }).Page(input.PageSize, input.PageNumber).ToList();


            return userList;
        }

        public int MakeInActiveStudent(RequestModel<StudentModel> input)
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

        public bool DoesStudentExist(RequestModel<StudentModel> input)
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

        public bool DoesStudentIdExist(RequestModel<StudentModel> input)
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
        public int AddStudentAdmission(RequestModel<StudentAdmissionModel> input)
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

        public int UpdateStudentAdmission(RequestModel<StudentAdmissionModel> input)
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

        public List<StudentAdmissionModel> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel> input)
        {
            List<StudentAdmissionModel> userList = new List<StudentAdmissionModel>();
            userList = (from st in this.RepositoryContext.Student
                        join sa in this.RepositoryContext.StudentAdmission
                        .Where(x => x.Active == CommonConstants.ActiveStatus)
                        on st.Id equals sa.StudentId
                        select new StudentAdmissionModel
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

        public int MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel> input)
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

        public bool DoesStudentAdmissionExist(RequestModel<StudentAdmissionModel> input)
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

        public bool DoesStudentAdmissionIdExist(RequestModel<StudentAdmissionModel> input)
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
