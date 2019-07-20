using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedSoft.Utility.Constants;
using Microsoft.AspNetCore.Mvc;
using VedSoft.Business.Login;
using VedSoft.Logger;
using VedSoft.Data.Contracts.Wrapper;
using VedSoft.Model.Common;
using VedSoft.Model.Login;
using System.Security.Claims;
using VedSoft.API.Util.Token;
using VedSoft.API.Util;

namespace VedSoft.API.Controllers
{
    [Route(LoginAPIAction.RoutePrefixLogin)]
    [ApiController]
    public class LoginController : ApiBaseController
    {
        private ILoginBusinessEngine _loginBusinessEngine;
        private readonly ITokenService _tokenService;

        public LoginController(ILoginBusinessEngine loginBusinessEngine, ILoginBusiness loginBusiness,
            IVedSoftLogger iLogger, IRepositoryWrapper repoWrapper, ITokenService tokenService) : base(iLogger)
        {
            _loginBusinessEngine = loginBusinessEngine;
            _loginBusinessEngine.LoginBusiness = loginBusiness;
            //_loginBusinessEngine.RepositoryWrapper = repoWrapper;
            loginBusiness.RepositoryWrapper = repoWrapper;
            _tokenService = tokenService;

            var x = ConfigKey.JWTSecurityKey;
        }

        /// <summary>
        /// To authenticate the user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(LoginAPIAction.ActionAuthenticate)]
        public async Task<ResponseModel<AuthenticationModel>> Authenticate([FromBody] RequestModel<LoginRequestModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<AuthenticationModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    result = _loginBusinessEngine.Authenticate(input);

                    //If success...then only create the token
                    if (result.ResponseData.LoginResponseDetails.LoginStatus == CommonConstants.Success)
                    {
                        #region Token process
                        var usersClaims = new[]
                        {
                            new Claim(CommonConstants.UserLoginDetailsIdClaim, result.ResponseData.LoginResponseDetails.LoginDetailsId.ToString()),
                        };
                        string token = _tokenService.GenerateAccessToken(usersClaims);
                        string refreshToken = _tokenService.GenerateRefreshToken();
                        LoginResponseModel loginResponseModel = new LoginResponseModel
                        {
                            LoginDetailsId = result.ResponseData.LoginResponseDetails.LoginDetailsId,
                            RefreshToken = refreshToken,
                            Token = token,
                            CurrentDateTime = DateTime.Now,
                            UserId = result.ResponseData.UserDetails.Id
                        };
                        #endregion

                        _loginBusinessEngine.UpdateLoginToken(loginResponseModel);

                        result.ResponseData.LoginResponseDetails = loginResponseModel;
                    }

                    return result;
                });

            });

            return result;
        }

        //To get the refresh token
        [HttpPost]
        [Route(LoginAPIAction.ActionRefreshToken)]
        public async Task<ResponseModel<LoginResponseModel>> RefreshToken([FromBody] RequestModel<LoginResponseModel> input)
        {
            CurrentRequestParameter = input;
            CurrentUniqueID = input.RequestTxnID;
            ResponseModel<LoginResponseModel> result = null;

            await Task.Factory.StartNew(() =>
            {
                return GetResponse(Request, () =>
                {
                    var principal = _tokenService.GetPrincipalFromExpiredToken(input.RequestParameter.Token);
                    var userLoginDetailsId= principal.FindFirst(CommonConstants.UserLoginDetailsIdClaim).Value;
                    result = new ResponseModel<LoginResponseModel>();
                    result.ResponseData = input.RequestParameter;
                    input.RequestParameter.LoginDetailsId = Convert.ToInt64(userLoginDetailsId);

                    string refreshToken = _loginBusinessEngine.GetRefreshTokenByUserLoginDetailsId(input.RequestParameter);
                    result.ResponseData.LoginStatus = (int)LoginStatusConstants.InvalidRefreshToken;
                    if ( refreshToken==input.RequestParameter.RefreshToken)
                    {
                        var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
                        var newRefreshToken = _tokenService.GenerateRefreshToken();
                        
                        result.ResponseData.RefreshToken = newRefreshToken;
                        result.ResponseData.Token = newJwtToken;
                        result.ResponseData.CurrentDateTime = DateTime.Now;
                        result.ResponseData.LoginStatus = (int)LoginStatusConstants.Success;

                        _loginBusinessEngine.UpdateLoginToken(result.ResponseData);
                    }

                    return result;
                });

            });

            return result;
        }
    }
}
