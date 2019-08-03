using System.Collections.Generic;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Utility.Constants;

namespace VedSoft.Business.Engine.Master
{
   
    public class MasterBusinessEngine:BusinessEngineBase, IMasterBusinessEngine
    {
        public IMasterBusiness MasterBusiness { get; set; }

        //To add a new customer
        public ResponseModel<ResultModel> AddCustomer(RequestModel<CustomerModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = MasterBusiness.AddCustomer(input.RequestParameter);

            return responseModel;
        }

        //To get the customer details by customerId
        public ResponseModel<CustomerModel> GetCustomerDetailsById(RequestModel<CustomerModel> input)
        {
            ResponseModel<CustomerModel> responseModel = new ResponseModel<CustomerModel>();
            responseModel.ResponseData = MasterBusiness.GetCustomerDetailsById(input.RequestParameter);
            

            return responseModel;
        }

        public ResponseModel<ResultModel> AddCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddCourseHierarchy(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if(responseModel.ResponseData.PrimaryKey>0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateCourseHierarchy(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<CourseHiearchyModel>> GetCourseHierarchy(SearchRequestModel<CourseHiearchyModel> input)
        {
            ResponseModel<List<CourseHiearchyModel>> responseModel = new ResponseModel<List<CourseHiearchyModel>>();
            responseModel.ResponseData = MasterBusiness.GetCourseHierarchy(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveCourseHierarchy(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }

        public ResponseModel<CustomerModel> GetCustomerDetailsBySubDomain(RequestModel<CustomerModel> input)
        {
            ResponseModel<CustomerModel> responseModel = new ResponseModel<CustomerModel>();
            responseModel.ResponseData = MasterBusiness.GetCustomerDetailsBySubDomain(input.RequestParameter);


            return responseModel;
        }
    }
}
