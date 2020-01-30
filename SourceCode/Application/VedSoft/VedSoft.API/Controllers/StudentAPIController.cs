
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using VedSoft.Data.Contracts.Wrapper;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Business.Engine.Master;
using VedSoft.Business.Master;
using VedSoft.Utility.Constants;
using VedSoft.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using VedSoft.Model.User;

namespace VedSoft.API.Controllers
{
    public partial class UserAPIController : ApiBaseController
    {
        [HttpGet]
        public object test()
        {
            return new RequestModel<StudentAdmissionModel> {

                RequestParameter=new StudentAdmissionModel { }
            };
        }
        /// <summary>
        /// To add the Student
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionAddStudent)]
        public async Task<ResponseModel<ResultModel>> AddStudent([FromBody] RequestModel<StudentAdmissionModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result =_userBusinessEngine.AddStudent(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the  Student
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionUpdateStudent)]
        public async Task<ResponseModel<ResultModel>> UpdateStudent([FromBody] RequestModel<StudentAdmissionModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.UpdateStudent(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the  Student
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionGetStudentList)]
        public async Task<ResponseModel<List<StudentViewModel>>> GetStudentList([FromBody] SearchRequestModel<StudentViewModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<StudentViewModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.GetStudentList(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the  Student details
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionGetStudentDetails)]
        public async Task<ResponseModel<StudentAdmissionModel>> GetStudentDetails([FromBody] SearchRequestModel<StudentViewModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<StudentAdmissionModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.GetStudentDetails(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the  Student inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionMakeInActiveStudent)]
        public async Task<ResponseModel<ResultModel>> MakeInActiveStudent([FromBody] RequestModel<StudentModel_Old> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.MakeInActiveStudent(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To add the Student Admission
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionAddStudentAdmission)]
        public async Task<ResponseModel<ResultModel>> AddStudentAdmission([FromBody] RequestModel<StudentAdmissionModel_Old> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.AddStudentAdmission(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the  Student Admission
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionUpdateStudentAdmission)]
        public async Task<ResponseModel<ResultModel>> UpdateStudentAdmission([FromBody] RequestModel<StudentAdmissionModel_Old> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.UpdateStudentAdmission(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the  Student Admission
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionGetStudentAdmissionList)]
        public async Task<ResponseModel<List<StudentAdmissionModel_Old>>> GetStudentAdmissionList([FromBody] SearchRequestModel<StudentAdmissionModel_Old> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<StudentAdmissionModel_Old>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.GetStudentAdmissionList(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the  Student Admission inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionMakeInActiveStudentAdmission)]
        public async Task<ResponseModel<ResultModel>> MakeInActiveStudentAdmission([FromBody] RequestModel<StudentAdmissionModel_Old> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.MakeInActiveStudentAdmission(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To add the Student Course
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionAddStudentCourse)]
        public async Task<ResponseModel<ResultModel>> AddStudentCourse([FromBody] RequestModel<StudentCourseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.AddStudentCourse(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the  Student Course
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionUpdateStudentCourse)]
        public async Task<ResponseModel<ResultModel>> UpdateStudentCourse([FromBody] RequestModel<StudentCourseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.UpdateStudentCourse(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the  Student Course
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionGetStudentCourseList)]
        public async Task<ResponseModel<List<StudentCourseModel>>> GetStudentCourseList([FromBody] SearchRequestModel<StudentCourseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<StudentCourseModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.GetStudentCourseList(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the  Student Course inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionMakeInActiveStudentCourse)]
        public async Task<ResponseModel<ResultModel>> MakeInActiveStudentCourse([FromBody] RequestModel<StudentCourseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.MakeInActiveStudentCourse(input);
                    return result;

                });

            });

            return result;
        }


    }
}

    
