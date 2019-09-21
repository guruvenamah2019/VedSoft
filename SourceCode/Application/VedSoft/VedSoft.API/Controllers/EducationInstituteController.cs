
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
        /// To add the EducationInstitute
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EducationInstituteAPIAction.ActionAddEducationInstitute)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> AddEducationInstitute([FromBody] RequestModel<EducationInstituteModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.AddEducationInstitute(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the EducationInstitute
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EducationInstituteAPIAction.ActionUpdateEducationInstitute)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> UpdateEducationInstitute([FromBody] RequestModel<EducationInstituteModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.UpdateEducationInstitute(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the EducationInstitute list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EducationInstituteAPIAction.ActionGetEducationInstituteList)]
        //[Authorize]
        public async Task<ResponseModel<List<EducationInstituteModel>>> GetEducationInstituteList([FromBody] SearchRequestModel<EducationInstituteModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<EducationInstituteModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetEducationInstituteList(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the EducationInstitute inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EducationInstituteAPIAction.ActionMakeInActiveEducationInstitute)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> MakeInActiveEducationInstitute([FromBody] RequestModel<EducationInstituteModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.MakeInActiveEducationInstitute(input);
                    return result;

                });

            });

            return result;
        }


    }
}

    
