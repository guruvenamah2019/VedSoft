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



    }
}
