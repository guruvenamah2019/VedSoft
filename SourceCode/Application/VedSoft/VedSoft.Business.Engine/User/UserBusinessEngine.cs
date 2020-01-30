using System.Collections.Generic;
using System.Linq;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;
using VedSoft.Utility.Constants;

namespace VedSoft.Business.Engine.Master
{
   
    public class UserBusinessEngine:BusinessEngineBase, IUserBusinessEngine
    {
        public IUserBusiness UserBusiness { get; set; }

        #region User
        public ResponseModel<ResultModel> AddUser(RequestModel<UserModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = UserBusiness.AddUser(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateUser(RequestModel<UserModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.UpdateUser(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<UserModel>> GetUserList(SearchRequestModel<UserModel> input)
        {
            ResponseModel<List<UserModel>> responseModel = new ResponseModel<List<UserModel>>();
            responseModel.ResponseData = UserBusiness.GetUserList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveUser(RequestModel<UserModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.MakeInActiveUser(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion

        #region Student
        public ResponseModel<ResultModel> AddStudent(RequestModel<StudentAdmissionModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();

            var userId = UserBusiness.AddStudent(input);
            responseModel.ResponseData.PrimaryKey = userId;
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            
            return responseModel;
        }


        public ResponseModel<ResultModel> UpdateStudent(RequestModel<StudentAdmissionModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();

            var userId = UserBusiness.UpdateStudent(input);
            responseModel.ResponseData.PrimaryKey = userId;
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateStudent(RequestModel<StudentModel_Old> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.UpdateStudent(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<StudentViewModel>> GetStudentList(SearchRequestModel<StudentViewModel> input)
        {
            ResponseModel<List<StudentViewModel>> responseModel = new ResponseModel<List<StudentViewModel>>();
            responseModel.ResponseData = UserBusiness.GetStudentList(input);
            responseModel.Status = CommonConstants.Success;
            responseModel.RecordCount = responseModel.ResponseData.Select(x => x.Counter).FirstOrDefault();

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveStudent(RequestModel<StudentModel_Old> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.MakeInActiveStudent(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }

        public ResponseModel<StudentAdmissionModel> GetStudentDetails(SearchRequestModel<StudentViewModel> input)
        {
            ResponseModel<StudentAdmissionModel> responseModel = new ResponseModel<StudentAdmissionModel>();
            responseModel.ResponseData = UserBusiness.GetStudentDetails(input);

            return responseModel;
        }
        #endregion

        #region Student Admission
        public ResponseModel<ResultModel> AddStudentAdmission(RequestModel<StudentAdmissionModel_Old> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = UserBusiness.AddStudentAdmission(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateStudentAdmission(RequestModel<StudentAdmissionModel_Old> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.UpdateStudentAdmission(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<StudentAdmissionModel_Old>> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel_Old> input)
        {
            ResponseModel<List<StudentAdmissionModel_Old>> responseModel = new ResponseModel<List<StudentAdmissionModel_Old>>();
            responseModel.ResponseData = UserBusiness.GetStudentAdmissionList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel_Old> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.MakeInActiveStudentAdmission(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion

        #region Student Admission
        public ResponseModel<ResultModel> AddStudentCourse(RequestModel<StudentCourseModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.PrimaryKey = UserBusiness.AddStudentCourse(input);
            responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
            if (responseModel.ResponseData.PrimaryKey > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateStudentCourse(RequestModel<StudentCourseModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.UpdateStudentCourse(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<List<StudentCourseModel>> GetStudentCourseList(SearchRequestModel<StudentCourseModel> input)
        {
            ResponseModel<List<StudentCourseModel>> responseModel = new ResponseModel<List<StudentCourseModel>>();
            responseModel.ResponseData = UserBusiness.GetStudentCourseList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveStudentCourse(RequestModel<StudentCourseModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            responseModel.ResponseData.ResponseValue = UserBusiness.MakeInActiveStudentCourse(input);
            if ((int)responseModel.ResponseData.ResponseValue > 0)
                responseModel.ResponseData.StatusId = CommonConstants.Success;
            else
                responseModel.ResponseData.StatusId = (int)responseModel.ResponseData.ResponseValue;

            return responseModel;
        }
        #endregion
    }
}
