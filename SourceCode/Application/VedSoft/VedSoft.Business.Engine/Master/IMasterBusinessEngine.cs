using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;

namespace VedSoft.Business.Engine.Master
{
    public interface IMasterBusinessEngine:IBusinessEngineBase
    {
        IMasterBusiness MasterBusiness { get; set; }

        #region Customer
        ResponseModel<ResultModel> AddCustomer(RequestModel<CustomerModel> input);
        ResponseModel<CustomerModel> GetCustomerDetailsBySubDomain(RequestModel<CustomerModel> input);
        ResponseModel<CustomerModel> GetCustomerDetailsById(RequestModel<CustomerModel> input);
        #endregion

        #region CourseHierarchy
        ResponseModel<ResultModel> AddCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        ResponseModel<ResultModel> UpdateCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        ResponseModel<List<CourseHiearchyModel>>  GetCourseHierarchy(SearchRequestModel<CourseHiearchyModel> input);
        ResponseModel<ResultModel> MakeInActiveCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        #endregion

        #region Customer Branch
        ResponseModel<ResultModel> AddCustomerBranch(RequestModel<CustomerBranchModel> input);
        ResponseModel<ResultModel> UpdateCustomerBranch(RequestModel<CustomerBranchModel> input);
        ResponseModel<List<CustomerBranchModel>> GetCustomerBranches(SearchRequestModel<CustomerBranchModel> input);
        ResponseModel<ResultModel> MakeInActiveCustomerBranch(RequestModel<CustomerBranchModel> input);
        #endregion

        #region User Role
        ResponseModel<ResultModel> AddUserRole(RequestModel<UserRoleModel> input);
        ResponseModel<ResultModel> UpdateUserRole(RequestModel<UserRoleModel> input);
        ResponseModel<List<UserRoleModel>> GetUserRole(SearchRequestModel<UserRoleModel> input);
        ResponseModel<ResultModel> MakeInActiveUserRole(RequestModel<UserRoleModel> input);
        #endregion

        #region Academic Year
        ResponseModel<ResultModel> AddAcademicYear(RequestModel<AcademicYearModel> input);
        ResponseModel<ResultModel> UpdateAcademicYear(RequestModel<AcademicYearModel> input);
        ResponseModel<List<AcademicYearModel>> GetAcademicYears(SearchRequestModel<AcademicYearModel> input);
        ResponseModel<ResultModel> MakeInActiveAcademicYear(RequestModel<AcademicYearModel> input);
        #endregion
    }
}
