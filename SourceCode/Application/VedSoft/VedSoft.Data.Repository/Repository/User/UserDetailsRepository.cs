using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Model;
using VedSoft.Data.Contracts.User;
using VedSoft.Model.User;
using System.Linq;

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
    }
}
