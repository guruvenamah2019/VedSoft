using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;

namespace VedSoft.Business.Engine.Master
{
    public interface IUserBusinessEngine:IBusinessEngineBase
    {
        IUserBusiness UserBusiness { get; set; }

        #region User
        ResponseModel<ResultModel> AddUser(RequestModel<UserModel> input);
        ResponseModel<ResultModel> UpdateUser(RequestModel<UserModel> input);
        ResponseModel<List<UserModel>> GetUserList(SearchRequestModel<UserModel> input);
        ResponseModel<ResultModel> MakeInActiveUser(RequestModel<UserModel> input);
        #endregion
    }
}
