
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
    //[AllowAnonymous]
    //[EnableCors("CorsPolicy")]
    public partial class MasterAPIController : ApiBaseController
    {
        /// <summary>
        /// To add the AcademicYear
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(AcademicYearAPIAction.ActionAddAcademicYear)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> AddAcademicYear([FromBody] RequestModel<AcademicYearModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.AddAcademicYear(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the AcademicYear
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(AcademicYearAPIAction.ActionUpdateAcademicYear)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> UpdateAcademicYear([FromBody] RequestModel<AcademicYearModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.UpdateAcademicYear(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the AcademicYear
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(AcademicYearAPIAction.ActionGetAcademicYears)]
        //[Authorize]
        public async Task<ResponseModel<List<AcademicYearModel>>> GetAcademicYear([FromBody] SearchRequestModel<AcademicYearModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<AcademicYearModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetAcademicYears(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the AcademicYear inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(AcademicYearAPIAction.ActionMakeInActiveAcademicYear)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> MakeInActiveAcademicYear([FromBody] RequestModel<AcademicYearModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.MakeInActiveAcademicYear(input);
                    return result;

                });

            });

            return result;
        }


    }
}

    
