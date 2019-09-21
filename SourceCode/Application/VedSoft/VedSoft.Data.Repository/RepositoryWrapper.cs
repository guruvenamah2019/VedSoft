using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts;
using VedSoft.Data.Contracts.Wrapper;
using VedSoft.Data.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using VedSoft.Data.Contracts.Master;
using VedSoft.Data.Repository.Repository.User;
using VedSoft.Data.Contracts.User;
using VedSoft.Data.Contracts.Repository.Master;
using VedSoft.Data.Repository.Repository.Master;

namespace VedSoft.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICustomerRepository _customerRepository;
        private IUserRepository _userRepository;
        private IUserDetailsRepository _userDetailsRepository;
        private IUserLoginDetailsRepository _userLoginDetailsRepository;
        private ICustomerCourseHierarchyRepository _masterRepository;
        private ICustomerBranchRepository _customerBranchRepository;
        private IUserRoleRepository _userRoleRepository;
        private IAcademicYearRepository _academicYearRepository;
        private IBankRepository _bankRepository;
        private IEducationInstituteRepository _educationInstituteRepository;

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
                return _customerRepository ?? new CustomerRepository(_repoContext);
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? new UserRepository(_repoContext);
            }
        }

        public IUserDetailsRepository UserDetailsRepository
        {
            get
            {
                return _userDetailsRepository ?? new UserDetailsRepository(_repoContext);
            }
        }

        public IUserLoginDetailsRepository UserLoginDetailsRepository
        {
            get
            {
                return _userLoginDetailsRepository ?? new UserLoginDetailsRepository(_repoContext);
            }
        }
        public ICustomerCourseHierarchyRepository MasterRepository
        {
            get
            {
                return _masterRepository ?? new CustomerCourseHierarchyRepository(_repoContext);
            }
        }

        public ICustomerBranchRepository CustomerBranchRepository
        {
            get
            {
                return _customerBranchRepository ?? new CustomerBranchRepository(_repoContext);
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                return _userRoleRepository ?? new UserRoleRepository(_repoContext);
            }
        }

        public IAcademicYearRepository AcademicYearRepository
        {
            get
            {
                return _academicYearRepository ?? new AcademicYearRepository(_repoContext);
            }
        }

        public IBankRepository BankRepository
        {
            get
            {
                return _bankRepository ?? new BankRepository(_repoContext);
            }
        }

        public IEducationInstituteRepository EducationInstituteRepository
        {
            get
            {
                return _educationInstituteRepository ?? new EducationalInstituteRepository(_repoContext);
            }
        }
    }
}
