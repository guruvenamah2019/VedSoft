using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;

namespace VedSoft.Data.Contracts.User
{
    public interface IUserDetailsRepository : IRepositoryBase<UserDetailsDB>
    {
        bool IncrementUserLoginLockAttempt(int userDetailsId);
    }
}
