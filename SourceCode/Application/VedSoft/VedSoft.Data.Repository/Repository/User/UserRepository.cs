﻿using System;
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
                CreatedBy = input.RequestParameter.ActionUserId,
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
                UserTypeId = input.RequestParameter.UserTypeId
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
                FatherUserId = input.RequestParameter.FatherUserId,
                MotherUserId = input.RequestParameter.MotherUserId,
                UserId = input.RequestParameter.UserId,
                GuardinanUserId = input.RequestParameter.UserId,
                IsEnrolled = input.RequestParameter.IsEnrolled,
            };

            //Save in database
            this.RepositoryContext.Add(studentDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = studentDB.UserId;

            return studentDB.UserId;
        }

        public int UpdateStudent(RequestModel<StudentModel> input)
        {
            var student = this.RepositoryContext.Student
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (student != null)
            {
                student.UserId = input.RequestParameter.UserId;
                student.GuardinanUserId = input.RequestParameter.GuardianUserId;
                student.FatherUserId = input.RequestParameter.FatherUserId;
                student.IsEnrolled = input.RequestParameter.IsEnrolled;
                student.MotherUserId = input.RequestParameter.MotherUserId;
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
                                FatherUserId = st.FatherUserId,
                                MotherUserId = st.MotherUserId,
                                GuardianUserId = st.GuardinanUserId.GetValueOrDefault(),
                                IsEnrolled = st.IsEnrolled,
                                UserId = st.UserId
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
                                  .Where(x => x.UserId == input.RequestParameter.UserId
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
}
