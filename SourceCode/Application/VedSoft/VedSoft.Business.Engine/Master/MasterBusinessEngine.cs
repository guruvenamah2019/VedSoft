using System.Collections.Generic;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;
using VedSoft.Utility.Constants;

namespace VedSoft.Business.Engine.Master
{
   
    public class MasterBusinessEngine:BusinessEngineBase, IMasterBusinessEngine
    {
        public IMasterBusiness MasterBusiness { get; set; }

        #region customer
        //To add a new customer
        public ResponseModel<ResultModel> AddCustomer(RequestModel<CustomerModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = MasterBusiness.AddCustomer(input.RequestParameter);

            return responseModel;
        }

        //To get the customer details by customerId
        public ResponseModel<CustomerModel> GetCustomerDetailsById(RequestModel<CustomerModel> input)
        {
            ResponseModel<CustomerModel> responseModel = new ResponseModel<CustomerModel>();
            responseModel.ResponseData = MasterBusiness.GetCustomerDetailsById(input.RequestParameter);

            return responseModel;
        }
        #endregion

        #region Course Hierarchy
        public ResponseModel<ResultModel> AddCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddCourseHierarchy(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if(responseModel.ResponseData.PrimaryKey>0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateCourseHierarchy(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<CourseHiearchyModel>> GetCourseHierarchy(SearchRequestModel<CourseHiearchyModel> input)
        {
            ResponseModel<List<CourseHiearchyModel>> responseModel = new ResponseModel<List<CourseHiearchyModel>>();
            responseModel.ResponseData = MasterBusiness.GetCourseHierarchy(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveCourseHierarchy(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion

        #region Customer bracnh
        public ResponseModel<CustomerModel> GetCustomerDetailsBySubDomain(RequestModel<CustomerModel> input)
        {
            ResponseModel<CustomerModel> responseModel = new ResponseModel<CustomerModel>();
            responseModel.ResponseData = MasterBusiness.GetCustomerDetailsBySubDomain(input.RequestParameter);


            return responseModel;
        }

        public ResponseModel<ResultModel> AddCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddCustomerBranch(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateCustomerBranch(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<CustomerBranchModel>> GetCustomerBranches(SearchRequestModel<CustomerBranchModel> input)
        {
            ResponseModel<List<CustomerBranchModel>> responseModel = new ResponseModel<List<CustomerBranchModel>>();
            responseModel.ResponseData = MasterBusiness.GetCustomerBranches(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveCustomerBranch(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }

        #endregion

        #region User Role
        public ResponseModel<ResultModel> AddUserRole(RequestModel<UserRoleModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddUserRole(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateUserRole(RequestModel<UserRoleModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateUserRole(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<UserRoleModel>> GetUserRole(SearchRequestModel<UserRoleModel> input)
        {
            ResponseModel<List<UserRoleModel>> responseModel = new ResponseModel<List<UserRoleModel>>();
            responseModel.ResponseData = MasterBusiness.GetUserRoles(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveUserRole(RequestModel<UserRoleModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveUserRole(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion

        #region academic year
        public ResponseModel<ResultModel> AddAcademicYear(RequestModel<AcademicYearModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddAcademicYear(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateAcademicYear(RequestModel<AcademicYearModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateAcademicYear(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<AcademicYearModel>> GetAcademicYears(SearchRequestModel<AcademicYearModel> input)
        {
            ResponseModel<List<AcademicYearModel>> responseModel = new ResponseModel<List<AcademicYearModel>>();
            responseModel.ResponseData = MasterBusiness.GetAcademicYears(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveAcademicYear(RequestModel<AcademicYearModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveAcademicYear(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion

        #region bank
        public ResponseModel<ResultModel> AddBank(RequestModel<BankModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddBank(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateBank(RequestModel<BankModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateBank(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<BankModel>> GetBankList(SearchRequestModel<BankModel> input)
        {
            ResponseModel<List<BankModel>> responseModel = new ResponseModel<List<BankModel>>();
            responseModel.ResponseData = MasterBusiness.GetBankList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveBank(RequestModel<BankModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveBank(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion

        #region Education institute
        public ResponseModel<ResultModel> AddEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddEducationInstitute(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateEducationInstitute(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<EducationInstituteModel>> GetEducationInstituteList(SearchRequestModel<EducationInstituteModel> input)
        {
            ResponseModel<List<EducationInstituteModel>> responseModel = new ResponseModel<List<EducationInstituteModel>>();
            responseModel.ResponseData = MasterBusiness.GetEducationInstituteList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveEducationInstitute(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion

        #region Customer Course
        public ResponseModel<ResultModel> AddCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddCustomerCourse(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateCustomerCourse(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<CustomerCourseModel>> GetCustomerCourseList(SearchRequestModel<CustomerCourseModel> input)
        {
            ResponseModel<List<CustomerCourseModel>> responseModel = new ResponseModel<List<CustomerCourseModel>>();
            responseModel.ResponseData = MasterBusiness.GetCustomerCourseList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }
        public ResponseModel<CustomerCourseModel> GetCustomerCourseInfo(RequestModel<ResultInputIdModel> input) {
            ResponseModel<CustomerCourseModel> responseModel = new ResponseModel<CustomerCourseModel>();
            responseModel.ResponseData = MasterBusiness.GetCustomerCourseInfo(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }


        public ResponseModel<ResultModel> MakeInActiveCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveCustomerCourse(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion

        #region Customer Course Subject
        public ResponseModel<ResultModel> AddCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = MasterBusiness.AddCustomerCourseSubject(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.UpdateCustomerCourseSubject(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<CustomerCourseSubjectModel>> GetCustomerCourseSubjectList(SearchRequestModel<CustomerCourseSubjectModel> input)
        {
            ResponseModel<List<CustomerCourseSubjectModel>> responseModel = new ResponseModel<List<CustomerCourseSubjectModel>>();
            responseModel.ResponseData = MasterBusiness.GetCustomerCourseSubjectList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = MasterBusiness.MakeInActiveCustomerCourseSubject(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion
    }

    public class BatchBusinessEngine : BusinessEngineBase, IBatchBusinessEngine
    {
        public IBatchBusiness BatchBusiness { get; set; }

        public ResponseModel<ResultModel> AddBatch(RequestModel<BatchMasterModel> input)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel<List<BatchMasterModel>> GetBarchBatchList(SearchRequestModel<BatchMasterModel> input)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel<ResultModel> MakeInActiveBatch(RequestModel<BatchMasterModel> input)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel<ResultModel> UpdateBatch(RequestModel<BatchMasterModel> input)
        {
            throw new System.NotImplementedException();
        }
    }


}
