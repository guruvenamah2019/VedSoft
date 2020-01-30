using System;
using System.Collections.Generic;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;

namespace VedSoft.Data.Contracts.Master
{
    public interface ICustomerRepository:IRepositoryBase<CustomerModelDB>
    {
        int AddCustomer(RequestModel<CustomerModel> input);
       // int UpdateCustomer(RequestModel<CustomerModel> input);
      //  bool DoesCustomerExits(RequestModel<CustomerModel> input);
      //  List <CustomerModel>GetAllCustomers(SearchRequestModel<CustomerModel> input);
        
     //   int MakeInActiveCustomer(RequestModel<CustomerModel> input);

    }
}
