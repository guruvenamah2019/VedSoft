using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Model;
using VedSoft.Data.Contracts.User;
using VedSoft.Model.User;
using System.Linq;
using VedSoft.Model.Common;
using VedSoft.Utility.Constants;

namespace VedSoft.Data.Repository.Repository.User
{
    public class UserDetailsRepository : RepositoryBase<UserDetailsDB>, IUserDetailsRepository
    {
        public UserDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public bool UpdateUserLoginLockAttempt(UserModel userDetailsReceived)
        {
            UserDetailsDB userDetails = this.RepositoryContext.UserDetails.Where(x => x.Id == userDetailsReceived.Id).FirstOrDefault();
            if(userDetails!=null)
            {
                userDetails.LockAttemptCount= userDetailsReceived.LockAttempts;
                userDetails.LastLoginDate = DateTime.Now;
                this.RepositoryContext.Update(userDetails);
                this.RepositoryContext.SaveChanges();
            }

            return true;
        }

        public int AddUserDetails(RequestModel<UserModel> input)
        {
            //Make db object
            UserDetailsDB userDetails = new UserDetailsDB
            {
                UserId=input.RequestParameter.Id,
                CreatedBy = input.RequestParameter.ActionUserId,
                CreatedDate = DateTime.Now,
                IsTemproryPassword = input.RequestParameter.TemproryPassword,
                LanguageId = input.RequestParameter.RequestedLanguageId,
                PageSize = input.RequestParameter.RequestedPageSize,
                PasswordExpirationDate = input.RequestParameter.PasswordExpiryDate,
                PasswordValidationCode = input.RequestParameter.PasswordValidationCode
            };

            //Save in database
            this.RepositoryContext.Add(userDetails);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = userDetails.Id;

            return userDetails.Id;
        }

        public int UpdateUserDetails(RequestModel<UserModel> input)
        {
            var userDetails = this.RepositoryContext.UserDetails
                            .Where(x => x.UserId == input.RequestParameter.Id)
                            .FirstOrDefault();
            if (userDetails != null)
            {
                userDetails.IsTemproryPassword = input.RequestParameter.TemproryPassword;
                userDetails.LanguageId = input.RequestParameter.RequestedLanguageId;
                userDetails.PageSize = input.RequestParameter.RequestedPageSize;
                userDetails.PasswordExpirationDate = input.RequestParameter.PasswordExpiryDate;
                userDetails.PasswordValidationCode = input.RequestParameter.PasswordValidationCode;
                userDetails.ModifiedBy = input.RequestParameter.ActionUserId;
                userDetails.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(userDetails);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }
    }
}
