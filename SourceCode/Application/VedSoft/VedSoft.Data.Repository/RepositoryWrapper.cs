using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts;
using VedSoft.Data.Contracts.Wrapper;
using VedSoft.Data.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using VedSoft.Data.Contracts.Master;

namespace VedSoft.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICustomerRepository _customerRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;

        }

        public RepositoryWrapper(RepositoryContext repositoryContext, string connString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseMySql(connString);

            RepositoryContext obupdatedContext = new RepositoryContext(optionsBuilder.Options);
            _repoContext = obupdatedContext;
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository == null ? new CustomerRepository(_repoContext) : _customerRepository;
            }
        }
    }
}
