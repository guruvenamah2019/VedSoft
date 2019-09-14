
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
    [Route(MasterAPIAction.RoutePrefixMaster)]
    [ApiController]
    public partial class MasterAPIController : ApiBaseController
    {

        private IMasterBusinessEngine _masterBusinessEngine;

        public MasterAPIController(IMasterBusinessEngine masterBusinessEngine, IMasterBusiness masterBusiness,
            IVedSoftLogger iLogger, IRepositoryWrapper repoWrapper) : base(iLogger)
        {
            _masterBusinessEngine = masterBusinessEngine;
            _masterBusinessEngine.MasterBusiness = masterBusiness;
            _masterBusinessEngine.RepositoryWrapper = repoWrapper;
            masterBusiness.RepositoryWrapper = repoWrapper;
        }

        /// <summary>
        /// To add the customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(MasterAPIAction.ActionAddCustomer)]
        public async Task<ResponseModel<ResultModel>> AddCustomer([FromBody] RequestModel<CustomerModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.AddCustomer(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the customer details by Id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(MasterAPIAction.ActionGetCustomerDetails)]
        public async Task<ResponseModel<CustomerModel>> GetCustomerDetailsById([FromBody] RequestModel<CustomerModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<CustomerModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetCustomerDetailsById(input);
                    return result;

                });
            });

            return result;
        }

        /// <summary>
        /// To get the customer details by Id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(MasterAPIAction.ActionGetCustomerDetailsBySubDomain)]
        [AllowAnonymous]
        public async Task<ResponseModel<CustomerModel>> GetCustomerDetailsBySubDomain([FromBody] RequestModel<CustomerModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<CustomerModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetCustomerDetailsBySubDomain(input);
                    return result;

                });
            });

            return result;
        }
    }
}

    
