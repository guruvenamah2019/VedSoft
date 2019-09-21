
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

namespace VedSoft.API.Controllers
{
    //[Route(CourseAPIAction.RoutePrefixCourse)]
    [AllowAnonymous]
    [EnableCors("CorsPolicy")]
    public partial class MasterAPIController : ApiBaseController
    {
        /// <summary>
        /// To add the course hierarchy
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CourseAPIAction.ActionAddCourseHierarchy)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> AddCourseHierarchy([FromBody] RequestModel<CourseHiearchyModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.AddCourseHierarchy(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the course hierarchy
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CourseAPIAction.ActionUpdateCourseHierarchy)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> UpdateCourseHierarchy([FromBody] RequestModel<CourseHiearchyModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.UpdateCourseHierarchy(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the course hierarchy
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CourseAPIAction.ActionGetCourseHierarchy)]
        //[Authorize]
        public async Task<ResponseModel<List<CourseHiearchyModel>>> GetCourseHierarchy([FromBody] SearchRequestModel<CourseHiearchyModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<CourseHiearchyModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetCourseHierarchy(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the course hierarchy inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CourseAPIAction.ActionMakeInActiveCourseHierarchy)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> MakeInActiveCourseHierarchy([FromBody] RequestModel<CourseHiearchyModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.MakeInActiveCourseHierarchy(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To add the customer course
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CourseAPIAction.ActionAddCustomerCourse)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> AddCustomerCourse([FromBody] RequestModel<CustomerCourseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.AddCustomerCourse(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the customer course
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CourseAPIAction.ActionUpdateCustomerCourse)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> UpdateCustomerCourse([FromBody] RequestModel<CustomerCourseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.UpdateCustomerCourse(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the course course list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CourseAPIAction.ActionGetCustomerCourseList)]
        //[Authorize]
        public async Task<ResponseModel<List<CustomerCourseModel>>> GetCustomerCourseList([FromBody] SearchRequestModel<CustomerCourseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<CustomerCourseModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetCustomerCourseList(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the customer course inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CourseAPIAction.ActionMakeInActiveCustomerCourse)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> MakeInActiveMakeInActiveCustomerCourse([FromBody] RequestModel<CustomerCourseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.MakeInActiveCustomerCourse(input);
                    return result;

                });

            });

            return result;
        }


    }
}

    
