using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;

namespace VedSoft.Business.Engine.Master
{
    public interface IMasterBusinessEngine:IBusinessEngineBase
    {
        IMasterBusiness MasterBusiness { get; set; }
        ResponseModel<ResultModel> AddCustomer(RequestModel<CustomerModel> input);
        ResponseModel<CustomerModel> GetCustomerDetailsById(RequestModel<CustomerModel> input);
    }
}
