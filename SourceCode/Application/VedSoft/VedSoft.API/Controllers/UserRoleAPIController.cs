
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
        [Route(UserRoleAPIAction.ActionAddCustomerRole)]
        public async Task<ResponseModel<ResultModel>> AddUserRole([FromBody] RequestModel<UserRoleModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.AddUserRole(input);
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
        [Route(UserRoleAPIAction.ActionUpdateCustomerRole)]
        public async Task<ResponseModel<ResultModel>> UpdateUserRole([FromBody] RequestModel<UserRoleModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.UpdateUserRole(input);
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
        [Route(UserRoleAPIAction.ActionGetCustomerRole)]
        public async Task<ResponseModel<List<UserRoleModel>>> GetUserRoles([FromBody] SearchRequestModel<UserRoleModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<UserRoleModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.GetUserRole(input);
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
        [Route(UserRoleAPIAction.ActionMakeInActiveCustomerRole)]
        public async Task<ResponseModel<ResultModel>> MakeInActiveUserRole([FromBody] RequestModel<UserRoleModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _masterBusinessEngine.MakeInActiveUserRole(input);
                    return result;

                });

            });

            return result;
        }


    }
}

    
