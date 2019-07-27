using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Login;
using VedSoft.Model.User;

namespace VedSoft.Data.Contracts.User
{
    public interface IUserRepository : IRepositoryBase<UserMasterDB>
    {
        UserModel Authenticate(LoginRequestModel loginRequestModel);
        UserModel GetUserIdByLoginId(int UserId);
        bool UpdatePassword(SetPasswordRequestModel input);

        
    }
}
