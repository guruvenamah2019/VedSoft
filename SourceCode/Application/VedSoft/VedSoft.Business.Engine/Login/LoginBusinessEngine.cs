using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Model.Common;
using VedSoft.Model.Login;
using VedSoft.Model.User;

namespace VedSoft.Business.Login
{
    public class LoginBusinessEngine: BusinessEngineBase, ILoginBusinessEngine
    {
        public ILoginBusiness LoginBusiness { get; set; }
        public ResponseModel<AuthenticationModel> Authenticate(RequestModel<LoginRequestModel> input)
        {
            ResponseModel<AuthenticationModel> responseModel = new ResponseModel<AuthenticationModel>();
            responseModel.ResponseData= LoginBusiness.Authenticate(input);
            
            return responseModel;
        }

        public bool UpdateLoginToken(LoginResponseModel input)
        {
            return LoginBusiness.UpdateLoginToken(input);
        }

        public string GetRefreshTokenByUserLoginDetailsId(LoginResponseModel input)
        {
            return LoginBusiness.GetRefreshTokenByUserLoginDetailsId(input);
        }
        public int UpdatePassword(RequestModel<SetPasswordRequestModel> input)
        {
            return LoginBusiness.UpdatePassword(input);
        }
    }
}
