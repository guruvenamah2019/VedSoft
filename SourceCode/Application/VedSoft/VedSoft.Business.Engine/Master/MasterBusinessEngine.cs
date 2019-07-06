using System.Collections.Generic;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
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
    }
}
