
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

namespace VedSoft.API.Controllers
{
    //[Route(CourseAPIAction.RoutePrefixCourse)]
    [Authorize]
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


    }
}

    
