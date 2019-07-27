using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Login;
using VedSoft.Model.User;

namespace VedSoft.Data.Contracts.User
{
    public interface IUserLoginDetailsRepository : IRepositoryBase<UserLoginDetailsDB>
    {
        int SaveUserLoginDetails(UserLoginDetails input);
        bool UpdateUserLoginDetails(LoginResponseModel input);
        UserModel GetUserDetailsByLoginDetailsId(LoginResponseModel input);
    }
}
