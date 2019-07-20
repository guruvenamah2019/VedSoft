using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Model;
using VedSoft.Data.Contracts.User;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VedSoft.Model.Login;
using VedSoft.Model.User;

namespace VedSoft.Data.Repository.Repository.User
{
    public class UserRepository : RepositoryBase<UserMasterDB>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public UserModel Authenticate(LoginRequestModel loginRequestModel)
        {
            var user = this.RepositoryContext.User;
            var userDetails = this.RepositoryContext.UserDetails;
            var userModel = (from u in user
                     where u.LoginId.ToLower() == loginRequestModel.UserName.ToLower()
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
                         PasswordExpiryDate = udd.PasswordExpirationDate,
                         TemproryPassword = udd.IsTemproryPassword,
                         LockAttempts = udd.LockAttemptCount,
                         Password = u.Password,
                         Active = u.Active,
                         UserDetailsId = udd.Id
                     }).FirstOrDefault();

            return userModel;
        }

        public int GetUserIdByLoginId(LoginRequestModel loginRequestModel)
        {
            return this.RepositoryContext
                            .User
                            .Where(x => x.LoginId.ToLower() == loginRequestModel.UserName)
                            .Select(x => x.UserId)
                            .FirstOrDefault();
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

    }
}
