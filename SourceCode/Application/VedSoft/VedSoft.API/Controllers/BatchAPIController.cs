
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
    public partial class MasterAPIController : ApiBaseController
    {
        /// <summary>
        /// To add the User Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CustomerBatchAPIAction.ActionAddCustomerBatch)]
        public async Task<ResponseModel<ResultModel>> AddCustomerBatch([FromBody] RequestModel<BatchMasterModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _batchBusinessEngine.AddBatch(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the  User Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CustomerBatchAPIAction.ActionUpdateCustomerBatch)]
        public async Task<ResponseModel<ResultModel>> UpdateCustomerBatch([FromBody] RequestModel<BatchMasterModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _batchBusinessEngine.UpdateBatch(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the  User Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CustomerBatchAPIAction.ActionGetCustomerBatch)]
        public async Task<ResponseModel<List<BatchMasterModel>>> GetCustomerBatchs([FromBody] SearchRequestModel<BatchMasterModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<BatchMasterModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _batchBusinessEngine.GetBarchBatchList(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the  User Role inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CustomerBatchAPIAction.ActionMakeInActiveCustomerBatch)]
        public async Task<ResponseModel<ResultModel>> MakeInActiveCustomerBatch([FromBody] RequestModel<BatchMasterModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _batchBusinessEngine.MakeInActiveBatch(input);
                    return result;

                });

            });

            return result;
        }


    }
}

    
