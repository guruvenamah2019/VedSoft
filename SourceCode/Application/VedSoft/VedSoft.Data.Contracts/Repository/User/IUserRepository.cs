using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Login;
using VedSoft.Model.User;

namespace VedSoft.Data.Contracts.User
{
    public interface IUserRepository : IRepositoryBase<UserMasterDB>
    {
        UserModel Authenticate(RequestModel<LoginRequestModel> loginRequestModel);
        UserModel GetUserIdByLoginId(int UserId);
        bool UpdatePassword(SetPasswordRequestModel input);

        int AddUser(RequestModel<UserModel> input);
        int UpdateUser(RequestModel<UserModel> input);
        List<UserModel> GetUserList(SearchRequestModel<UserModel> input);
        int MakeInActiveUser(RequestModel<UserModel> input);
        bool DoesUserExist(RequestModel<UserModel> input);
        bool DoesUserExistUpdate(RequestModel<UserModel> input);
        bool DoesUserIdExist(RequestModel<UserModel> input);
    }
}
