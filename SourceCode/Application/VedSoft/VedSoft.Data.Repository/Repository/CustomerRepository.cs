using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts;
using VedSoft.Data.Contracts.Master;
using VedSoft.Data.Contracts.Model;

namespace VedSoft.Data.Repository.Repository
{
    public class CustomerRepository : RepositoryBase<CustomerModelDB>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
