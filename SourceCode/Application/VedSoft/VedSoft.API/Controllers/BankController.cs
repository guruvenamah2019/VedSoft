
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
        /// To add the bank
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(BankAPIAction.ActionAddBank)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> AddBank([FromBody] RequestModel<BankModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.AddBank(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the bank
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(BankAPIAction.ActionUpdateBank)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> UpdateBank([FromBody] RequestModel<BankModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.UpdateBank(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the bank list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(BankAPIAction.ActionGetBankList)]
        //[Authorize]
        public async Task<ResponseModel<List<BankModel>>> GetBankList([FromBody] SearchRequestModel<BankModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<BankModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetBankList(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the Bank inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(BankAPIAction.ActionMakeInActiveBank)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> MakeInActiveBank([FromBody] RequestModel<BankModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.MakeInActiveBank(input);
                    return result;

                });

            });

            return result;
        }


    }
}

    
