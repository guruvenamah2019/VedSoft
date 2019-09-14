using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Common;
using VedSoft.Model.User;

namespace VedSoft.Data.Contracts.Repository.Master
{
    public interface IUserRoleRepository : IRepositoryBase<UserRoleDB>
    {
        int AddUserRole(RequestModel<UserRoleModel> input);
        int UpdateUserRole(RequestModel<UserRoleModel> input);
        List<UserRoleModel> GetUserRoles(SearchRequestModel<UserRoleModel> input);
        int MakeInActiveUserRole(RequestModel<UserRoleModel> input);

        bool DoesUserRoleExist(RequestModel<UserRoleModel> input);

        bool DoesUserRoleExistUpdate(RequestModel<UserRoleModel> input);

        bool DoesUserRoleIdExist(RequestModel<UserRoleModel> input);
    }
}
