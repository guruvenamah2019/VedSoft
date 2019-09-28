using System.Collections.Generic;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;
using VedSoft.Utility.Constants;

namespace VedSoft.Business.Engine.Master
{
   
    public class UserBusinessEngine:BusinessEngineBase, IUserBusinessEngine
    {
        public IUserBusiness UserBusiness { get; set; }

        #region Customer Course
        public ResponseModel<ResultModel> AddUser(RequestModel<UserModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = UserBusiness.AddUser(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateUser(RequestModel<UserModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.UpdateUser(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<UserModel>> GetUserList(SearchRequestModel<UserModel> input)
        {
            ResponseModel<List<UserModel>> responseModel = new ResponseModel<List<UserModel>>();
            responseModel.ResponseData = UserBusiness.GetUserList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveUser(RequestModel<UserModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.MakeInActiveUser(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion
    }
}
