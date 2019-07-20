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

        public bool IncrementUserLoginLockAttempt(int userDetailsId)
        {
            UserDetailsDB userDetails = this.RepositoryContext.UserDetails.Where(x => x.Id == userDetailsId).FirstOrDefault();
            if(userDetails!=null)
            {
                userDetails.LockAttemptCount++;
                this.RepositoryContext.Update(userDetails);
            }

            return true;
        }
    }
}
