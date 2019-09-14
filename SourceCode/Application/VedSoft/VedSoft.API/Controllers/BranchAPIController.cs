
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
    public partial class MasterAPIController : ApiBaseController
    {
        /// <summary>
        /// To add the customer branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CustomerBranchAPIAction.ActionAddCustomerBranch)]
        public async Task<ResponseModel<ResultModel>> AddCustomerBranch([FromBody] RequestModel<CustomerBranchModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.AddCustomerBranch(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the customer branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CustomerBranchAPIAction.ActionUpdateCustomerBranch)]
        public async Task<ResponseModel<ResultModel>> UpdateCustomerBranch([FromBody] RequestModel<CustomerBranchModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.UpdateCustomerBranch(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the customer branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CustomerBranchAPIAction.ActionGetCustomerBranch)]
        public async Task<ResponseModel<List<CustomerBranchModel>>> GetCustomerBranches([FromBody] SearchRequestModel<CustomerBranchModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<CustomerBranchModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetCustomerBranches(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the branch inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CustomerBranchAPIAction.ActionMakeInActiveCustomerBranch)]
        public async Task<ResponseModel<ResultModel>> MakeInCustomerBranch([FromBody] RequestModel<CustomerBranchModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.MakeInActiveCustomerBranch(input);
                    return result;

                });

            });

            return result;
        }


    }
}

    
