
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
        /// <summary>
        /// To add the Student
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionAddStudent)]
        public async Task<ResponseModel<ResultModel>> AddStudent([FromBody] RequestModel<StudentModel> input)
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
        public async Task<ResponseModel<ResultModel>> UpdateStudent([FromBody] RequestModel<StudentModel> input)
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
        public async Task<ResponseModel<List<StudentModel>>> GetStudentList([FromBody] SearchRequestModel<StudentModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<StudentModel>> result = null;

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
        /// To make the  Student inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(StudentAPIAction.ActionMakeInActiveStudent)]
        public async Task<ResponseModel<ResultModel>> MakeInActiveStudent([FromBody] RequestModel<StudentModel> input)
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
        public async Task<ResponseModel<ResultModel>> AddStudentAdmission([FromBody] RequestModel<StudentAdmissionModel> input)
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
        public async Task<ResponseModel<ResultModel>> UpdateStudentAdmission([FromBody] RequestModel<StudentAdmissionModel> input)
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
        public async Task<ResponseModel<List<StudentAdmissionModel>>> GetStudentAdmissionList([FromBody] SearchRequestModel<StudentAdmissionModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<StudentAdmissionModel>> result = null;

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
        public async Task<ResponseModel<ResultModel>> MakeInActiveStudentAdmission([FromBody] RequestModel<StudentAdmissionModel> input)
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


    }
}

    
