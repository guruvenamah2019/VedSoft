using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Model;
using VedSoft.Data.Contracts.User;
using VedSoft.Model.Login;
using VedSoft.Model.User;
using System.Linq;

namespace VedSoft.Data.Repository.Repository.User
{
    public class UserLoginDetailsRepository : RepositoryBase<UserLoginDetailsDB>, IUserLoginDetailsRepository
    {
        public UserLoginDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public int SaveUserLoginDetails(UserLoginDetails input)
        {
            //Make db object
            UserLoginDetailsDB userLoginDetailsDB = new UserLoginDetailsDB
            {
                CreatedBy = input.CreatedBy,
                CreatedDate = input.CreatedDate,
                CustomerId = input.CustomerId,
                LoginDate = input.LoginDate,
                LoginSourceDetails = input.LoginSourceDetails,
                StatusId = input.Status,
                UserId = input.UserId
            };

            //Save in database
            this.RepositoryContext.Add(userLoginDetailsDB);
            this.RepositoryContext.SaveChanges();

            input.Id = userLoginDetailsDB.Id;

            return userLoginDetailsDB.Id;
        }

        public bool UpdateUserLoginDetails(LoginResponseModel input)
        {

            var userLoginDetails = this.FindByCondition(x => x.Id == input.LoginDetailsId).FirstOrDefault();
            if(userLoginDetails!=null)
            {
                userLoginDetails.LoginToken = input.Token;
                userLoginDetails.LoginRefreshToken = input.RefreshToken;
                userLoginDetails.ModifiedBy = input.UserId;
                userLoginDetails.ModifiedDate = input.CurrentDateTime;
                this.RepositoryContext.Update(userLoginDetails);
                this.RepositoryContext.SaveChanges();
            }

            return true;
        }

        public UserModel GetUserDetailsByLoginDetailsId(LoginResponseModel input)
        {
            var userLoginDetails = this.RepositoryContext.UserLoginDetails;
            var user = this.RepositoryContext.User;
            var userDetails = this.RepositoryContext.UserDetails;
            var userModel = (from ul in userLoginDetails where ul.Id==input.LoginDetailsId
                             join u in user on ul.UserId equals u.UserId
                             //&& u.Password == loginRequestModel.Password
                             join ud in userDetails on u.UserId equals ud.UserId into usr
                             from udd in usr.DefaultIfEmpty()
                             select new UserModel
                             {
                                 Id = u.UserId,
                                 NotificationEmailId = u.NotificationEmailId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 MiddleName = u.MiddleName,
                                 UserName = u.LoginId,
                                 LastLoginDate = udd.LastLoginDate,
                                 PasswordExpiryDate = udd.PasswordExpirationDate ?? DateTime.Now.AddDays(100),
                                 TemproryPassword = udd.IsTemproryPassword,
                                 LockAttempts = udd.LockAttemptCount,
                                 Password = u.Password,
                                 Active = u.Active,
                                 UserDetailsId = udd.Id
                             }).FirstOrDefault();

            return userModel;
        }
    }
}
