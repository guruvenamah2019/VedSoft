using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;

namespace VedSoft.Data.Contracts.Repository.Master
{
    public interface ICustomerCourseHierarchyRepository:IRepositoryBase<CustomerCourseHierarchyDB>
    {
        int AddCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        int UpdateCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        List<CourseHiearchyModel> GetCourseHierarchy(SearchRequestModel<CourseHiearchyModel> input);

        int MakeInActiveCourseHierarchy(RequestModel<CourseHiearchyModel> input);

        bool DoesCourseHieararchyExist(RequestModel<CourseHiearchyModel> input);

        bool DoesCourseHieararchyExistUpdate(RequestModel<CourseHiearchyModel> input);

        bool DoesCourseHieararchyIdExist(RequestModel<CourseHiearchyModel> input);
    }

    public interface IAcademicYearRepository : IRepositoryBase<AcademicYearsDB>
    {
        int AddAcademicYear(RequestModel<AcademicYearModel> input);
        int UpdateAcademicYear(RequestModel<AcademicYearModel> input);
        List<AcademicYearModel> GetAcademicYears(SearchRequestModel<AcademicYearModel> input);

        int MakeInActiveAcademicYear(RequestModel<AcademicYearModel> input);

        bool DoesAcademicYearExist(RequestModel<AcademicYearModel> input);

        bool DoesAcademicYearExistUpdate(RequestModel<AcademicYearModel> input);

        bool DoesAcademicYearIdExist(RequestModel<AcademicYearModel> input);
    }

    public interface IBankRepository : IRepositoryBase<BankDB>
    {
        int AddBank(RequestModel<BankModel> input);
        int UpdateBank(RequestModel<BankModel> input);
        List<BankModel> GetBankList(SearchRequestModel<BankModel> input);

        int MakeInActiveBank(RequestModel<BankModel> input);

        bool DoesBankExist(RequestModel<BankModel> input);

        bool DoesBankExistUpdate(RequestModel<BankModel> input);

        bool DoesBankIdExist(RequestModel<BankModel> input);
    }

    public interface IEducationInstituteRepository : IRepositoryBase<EducationInstituteDB>
    {
        int AddEducationInstitute(RequestModel<EducationInstituteModel> input);
        int UpdateEducationInstitute(RequestModel<EducationInstituteModel> input);
        List<EducationInstituteModel> GetEducationInstituteList(SearchRequestModel<EducationInstituteModel> input);

        int MakeInActiveEducationInstitute(RequestModel<EducationInstituteModel> input);

        bool DoesEducationInstituteExist(RequestModel<EducationInstituteModel> input);

        bool DoesEducationInstituteExistUpdate(RequestModel<EducationInstituteModel> input);

        bool DoesEducationInstituteIdExist(RequestModel<EducationInstituteModel> input);
    }

    public interface ICustomerCourseRepository : IRepositoryBase<CustomerCourseDB>
    {
        int AddCustomerCourse(RequestModel<CustomerCourseModel> input);
        int UpdateCustomerCourse(RequestModel<CustomerCourseModel> input);
        List<CustomerCourseModel> GetCustomerCourseList(SearchRequestModel<CustomerCourseModel> input);

        int MakeInActiveCustomerCourse(RequestModel<CustomerCourseModel> input);

        bool DoesCustomerCourseExist(RequestModel<CustomerCourseModel> input);

        bool DoesCustomerCourseExistUpdate(RequestModel<CustomerCourseModel> input);

        bool DoesCustomerCourseIdExist(RequestModel<CustomerCourseModel> input);
    }

    public interface ICustomerCourseSubjectRepository : IRepositoryBase<CustomerCourseSubjectMappingDB>
    {
        int AddCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input);
        int UpdateCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input);
        List<CustomerCourseSubjectModel> GetCustomerCourseSubjectList(SearchRequestModel<CustomerCourseSubjectModel> input);

        int MakeInActiveCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input);

        bool DoesCustomerCourseSubjectExist(RequestModel<CustomerCourseSubjectModel> input);

        bool DoesCustomerCourseSubjectExistUpdate(RequestModel<CustomerCourseSubjectModel> input);

        bool DoesCustomerCourseSubjectIdExist(RequestModel<CustomerCourseSubjectModel> input);
    }
}
