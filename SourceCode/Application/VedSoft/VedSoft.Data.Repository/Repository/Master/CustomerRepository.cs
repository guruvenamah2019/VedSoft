using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts;
using VedSoft.Data.Contracts.Master;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Common;
using VedSoft.Utility.Constants;
namespace VedSoft.Data.Repository.Repository
{
    public class CustomerRepository : RepositoryBase<CustomerModelDB>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public int AddCustomer(RequestModel<Model.Master.CustomerModel> input)
        {
            //Initializing the Object
            CustomerModelDB customerModelDB = new CustomerModelDB

            {
                CustomerId = input.RequestParameter.CustomerId,
                Name = input.RequestParameter.Name,
                Code = input.RequestParameter.Code,
                SubDomain = input.RequestParameter.SubDomain,
                Description = input.RequestParameter.Description,
                Active = CommonConstants.ActiveStatus,
                ContactNumber = input.RequestParameter.ContactNumber,
                Address = input.RequestParameter.Address,
                OtherInfo = input.RequestParameter.OtherInfo,
                CreatedDate = DateTime.Now,
                CreatedBy = input.RequestParameter.CreatedBy

            };

            //Saving in database
            RepositoryContext.Add(customerModelDB);
            this.RepositoryContext.SaveChanges();
            input.RequestParameter.CustomerId = customerModelDB.CustomerId;
            return customerModelDB.CustomerId;
        }
    }
}
