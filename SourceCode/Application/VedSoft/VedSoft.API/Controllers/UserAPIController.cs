
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
using VedSoft.Model.User;
using Microsoft.AspNetCore.Cors;

namespace VedSoft.API.Controllers
{
    [Route(UserAPIAction.RoutePrefixUser)]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public partial class UserAPIController : ApiBaseController
    {

        private IUserBusinessEngine _userBusinessEngine;

        public UserAPIController(IUserBusinessEngine userBusinessEngine, IUserBusiness userBusiness,
            IVedSoftLogger iLogger, IRepositoryWrapper repoWrapper) : base(iLogger)
        {
            _userBusinessEngine = userBusinessEngine;
            _userBusinessEngine.UserBusiness = userBusiness;
            _userBusinessEngine.RepositoryWrapper = repoWrapper;
            userBusiness.RepositoryWrapper = repoWrapper;
        }

        /// <summary>
        /// To add the User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(UserAPIAction.ActionAddUser)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> AddUser([FromBody] RequestModel<UserModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.AddUser(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To update the User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(UserAPIAction.ActionUpdateUser)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> UpdateUser([FromBody] RequestModel<UserModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.UpdateUser(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To get the user list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(UserAPIAction.ActionGetUserList)]
        //[Authorize]
        public async Task<ResponseModel<List<UserModel>>> GetUserList([FromBody] SearchRequestModel<UserModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<List<UserModel>> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.GetUserList(input);
                    return result;

                });

            });

            return result;
        }

        /// <summary>
        /// To make the User inactive
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(UserAPIAction.ActionMakeInActiveUser)]
        //[Authorize]
        public async Task<ResponseModel<ResultModel>> MakeInActiveUser([FromBody] RequestModel<UserModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<ResultModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _userBusinessEngine.MakeInActiveUser(input);
                    return result;

                });

            });

            return result;
        }
    }
}

    
