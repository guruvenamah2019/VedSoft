using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Master;
using VedSoft.Data.Contracts.Repository.Master;
using VedSoft.Data.Contracts.User;

namespace VedSoft.Data.Contracts.Wrapper
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository CustomerRepository { get; }
        IUserDetailsRepository UserDetailsRepository { get; }
        IUserRepository UserRepository { get; }
        IUserLoginDetailsRepository UserLoginDetailsRepository { get; }
        ICustomerCourseHierarchyRepository MasterRepository { get; }
        ICustomerBranchRepository CustomerBranchRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IAcademicYearRepository AcademicYearRepository { get; }
        IBankRepository BankRepository { get; }
        IEducationInstituteRepository EducationInstituteRepository { get; }
        ICustomerCourseRepository CustomerCourseRepository { get; }
        IStudentRepository StudentRepository { get; }
        ICustomerCourseSubjectRepository CustomerCourseSubjectRepository { get; }
        IStudentAdmisionDetailsRepository StudentAdmisionDetailsRepository { get; }
        IStudentCourseRepository StudentCourseRepository { get; }
    }
}
