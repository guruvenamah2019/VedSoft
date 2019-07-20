using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;

namespace VedSoft.Business.Master
{
   public interface IMasterBusiness:IBusinessBase
   {
        ResultModel AddCustomer(CustomerModel input);
        CustomerModel GetCustomerDetailsById(CustomerModel input);
    }
}
