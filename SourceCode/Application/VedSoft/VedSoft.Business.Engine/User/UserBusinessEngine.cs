﻿using System.Collections.Generic;
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
        public ResponseModel<ResultModel> AddStudent(RequestModel<StudentModel> input)
        {
            ResponseModel<ResultModel> responseModel = new ResponseModel<ResultModel>();
            responseModel.ResponseData = new ResultModel();
            RequestModel<UserModel> inputUser = new RequestModel<UserModel>()
            {
                CustomerId = input.CustomerId,
                RequestParameter = input.RequestParameter.User
            };

            var userId = UserBusiness.AddUser(inputUser);
            if (userId > 0)
            {
                input.RequestParameter.User.Id = userId;
                responseModel.ResponseData.PrimaryKey = UserBusiness.AddStudent(input);
                responseModel.ResponseData.ResponseValue = responseModel.ResponseData.PrimaryKey;
                if (responseModel.ResponseData.PrimaryKey > 0)
                    responseModel.ResponseData.StatusId = CommonConstants.Success;
                else
                    responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;

                responseModel.Status = CommonConstants.Success;
            }
            else {
                responseModel.ResponseData.StatusId = CommonConstants.DuplicateRecord;
            }
            return responseModel;
        }

        public ResponseModel<ResultModel> UpdateStudent(RequestModel<StudentModel> input)
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

        public ResponseModel<List<StudentModel>> GetStudentList(SearchRequestModel<StudentModel> input)
        {
            ResponseModel<List<StudentModel>> responseModel = new ResponseModel<List<StudentModel>>();
            responseModel.ResponseData = UserBusiness.GetStudentList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveStudent(RequestModel<StudentModel> input)
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
        #endregion

        #region Student Admission
        public ResponseModel<ResultModel> AddStudentAdmission(RequestModel<StudentAdmissionModel> input)
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

        public ResponseModel<ResultModel> UpdateStudentAdmission(RequestModel<StudentAdmissionModel> input)
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

        public ResponseModel<List<StudentAdmissionModel>> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel> input)
        {
            ResponseModel<List<StudentAdmissionModel>> responseModel = new ResponseModel<List<StudentAdmissionModel>>();
            responseModel.ResponseData = UserBusiness.GetStudentAdmissionList(input);
            responseModel.Status = CommonConstants.Success;

            return responseModel;
        }

        public ResponseModel<ResultModel> MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel> input)
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