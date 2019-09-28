using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;

namespace VedSoft.Business.Master
{
   public interface IUserBusiness:IBusinessBase
   {
        #region Customer Course
        int AddUser(RequestModel<UserModel> input);
        int UpdateUser(RequestModel<UserModel> input);
        List<UserModel> GetUserList(SearchRequestModel<UserModel> input);
        int MakeInActiveUser(RequestModel<UserModel> input);
        #endregion
    }
}
