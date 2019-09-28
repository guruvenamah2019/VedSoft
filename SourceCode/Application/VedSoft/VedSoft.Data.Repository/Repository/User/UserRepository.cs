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
}
