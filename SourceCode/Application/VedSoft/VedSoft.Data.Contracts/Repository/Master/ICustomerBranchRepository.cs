using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;

namespace VedSoft.Data.Contracts.Repository.Master
{
    public interface ICustomerBranchRepository : IRepositoryBase<CustomerBranchesDB>
    {
        int AddCustomerBranch(RequestModel<CustomerBranchModel> input);
        int UpdateCustomerBranch(RequestModel<CustomerBranchModel> input);
        List<CustomerBranchModel> GetCustomerBranches(SearchRequestModel<CustomerBranchModel> input);
        int MakeInActiveCustomerBranch(RequestModel<CustomerBranchModel> input);

        bool DoesCustomerBranchExist(RequestModel<CustomerBranchModel> input);

        bool DoesCustomerBranchExistUpdate(RequestModel<CustomerBranchModel> input);

        bool DoesCustomerBranchIdExist(RequestModel<CustomerBranchModel> input);
    }
}
