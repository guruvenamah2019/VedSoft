using System;
using System.Collections.Generic;
using System.Linq;
using VedSoft.Data.Contracts.Model;
using VedSoft.Data.Contracts.Repository.Master;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Utility;
using VedSoft.Utility.Constants;

namespace VedSoft.Data.Repository.Repository.Master
{
    public class CustomerBranchRepository : RepositoryBase<CustomerBranchesDB>, ICustomerBranchRepository
    {
        public CustomerBranchRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public int AddCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            //Make db object
            CustomerBranchesDB customerBranchDB = new CustomerBranchesDB
            {
                CreatedBy = input.RequestParameter.UserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                CustomerId = input.CustomerId.GetValueOrDefault(),
                Name = input.RequestParameter.Name,
                Address = input.RequestParameter.Address,
                Code = input.RequestParameter.Code,
                ContactNumber = input.RequestParameter.ContactNumber,
                OtherInfo = input.RequestParameter.OtherInfo
            };

            //Save in database
            RepositoryContext.Add(customerBranchDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = customerBranchDB.Id;

            return customerBranchDB.Id;
        }

        public int UpdateCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            var customerBranch = this.RepositoryContext.CustomerBranch
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (customerBranch != null)
            {
                customerBranch.Name = input.RequestParameter.Name;
                customerBranch.Code = input.RequestParameter.Code;
                customerBranch.ModifiedBy = input.RequestParameter.UserId;
                customerBranch.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(customerBranch);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<CustomerBranchModel> GetCustomerBranches(SearchRequestModel<CustomerBranchModel> input)
        {
            List<CustomerBranchModel> customerBranchModelList = new List<CustomerBranchModel>();
            var customerBranchList = this.RepositoryContext.CustomerBranch
                                      .Where(x => x.CustomerId == input.CustomerId
                                      && x.Active == CommonConstants.ActiveStatus)
                                      .Page(input.PageSize, input.PageNumber);


            foreach (var customerBranch in customerBranchList.ToList())
            {
                customerBranchModelList.Add(new CustomerBranchModel
                {
                    Id = customerBranch.Id,
                    Name = customerBranch.Name,
                    Address = customerBranch.Address,
                    Code = customerBranch.Code,
                    OtherInfo = customerBranch.OtherInfo,
                    ContactNumber = customerBranch.ContactNumber,
                });
            }

            return customerBranchModelList;
        }

        public int MakeInActiveCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            var customerBranch = this.RepositoryContext.CustomerBranch
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (customerBranch != null)
            {
                customerBranch.Active = CommonConstants.InActiveStatus;
                customerBranch.ModifiedBy = input.RequestParameter.UserId;
                customerBranch.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(customerBranch);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesCustomerBranchExist(RequestModel<CustomerBranchModel> input)
        {
            return this.RepositoryContext.CustomerBranch
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus
                                  && (x.Name.ToLower() == input.RequestParameter.Name.ToLower()
                                   || x.Code.ToLower() == input.RequestParameter.Code.ToLower())
                                  )
                                  .Count() > 0;
        }

        public bool DoesCustomerBranchExistUpdate(RequestModel<CustomerBranchModel> input)
        {
            return this.RepositoryContext.CustomerBranch
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && (x.Name.ToLower() == input.RequestParameter.Name.ToLower()
                                   || x.Code.ToLower() == input.RequestParameter.Code.ToLower())
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.Id != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesCustomerBranchIdExist(RequestModel<CustomerBranchModel> input)
        {
            return this.RepositoryContext.CustomerBranch
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }
}
