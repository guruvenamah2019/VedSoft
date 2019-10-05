using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;

namespace VedSoft.Business.Master
{
   public interface IMasterBusiness:IBusinessBase
   {
        #region Customer
        ResultModel AddCustomer(CustomerModel input);
        CustomerModel GetCustomerDetailsById(CustomerModel input);
        CustomerModel GetCustomerDetailsBySubDomain(CustomerModel input);
        #endregion

        #region CourseHierarchy
        int AddCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        int UpdateCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        List<CourseHiearchyModel> GetCourseHierarchy(SearchRequestModel<CourseHiearchyModel> input);
        int MakeInActiveCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        #endregion

        #region Customer Branch
        int AddCustomerBranch(RequestModel<CustomerBranchModel> input);
        int UpdateCustomerBranch(RequestModel<CustomerBranchModel> input);
        List<CustomerBranchModel> GetCustomerBranches(SearchRequestModel<CustomerBranchModel> input);
        int MakeInActiveCustomerBranch(RequestModel<CustomerBranchModel> input);
        #endregion

        #region User Role
        int AddUserRole(RequestModel<UserRoleModel> input);
        int UpdateUserRole(RequestModel<UserRoleModel> input);
        List<UserRoleModel> GetUserRoles(SearchRequestModel<UserRoleModel> input);
        int MakeInActiveUserRole(RequestModel<UserRoleModel> input);
        #endregion

        #region Academic Year
        int AddAcademicYear(RequestModel<AcademicYearModel> input);
        int UpdateAcademicYear(RequestModel<AcademicYearModel> input);
        List<AcademicYearModel> GetAcademicYears(SearchRequestModel<AcademicYearModel> input);
        int MakeInActiveAcademicYear(RequestModel<AcademicYearModel> input);
        #endregion

        #region Bank
        int AddBank(RequestModel<BankModel> input);
        int UpdateBank(RequestModel<BankModel> input);
        List<BankModel> GetBankList(SearchRequestModel<BankModel> input);
        int MakeInActiveBank(RequestModel<BankModel> input);
        #endregion

        #region Education Institute
        int AddEducationInstitute(RequestModel<EducationInstituteModel> input);
        int UpdateEducationInstitute(RequestModel<EducationInstituteModel> input);
        List<EducationInstituteModel> GetEducationInstituteList(SearchRequestModel<EducationInstituteModel> input);
        int MakeInActiveEducationInstitute(RequestModel<EducationInstituteModel> input);
        #endregion

        #region Customer Course
        int AddCustomerCourse(RequestModel<CustomerCourseModel> input);
        int UpdateCustomerCourse(RequestModel<CustomerCourseModel> input);
        List<CustomerCourseModel> GetCustomerCourseList(SearchRequestModel<CustomerCourseModel> input);
        int MakeInActiveCustomerCourse(RequestModel<CustomerCourseModel> input);
        #endregion

        #region Customer Course Subject
        int AddCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input);
        int UpdateCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input);
        List<CustomerCourseSubjectModel> GetCustomerCourseSubjectList(SearchRequestModel<CustomerCourseSubjectModel> input);
        int MakeInActiveCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input);
        #endregion
    }
}
