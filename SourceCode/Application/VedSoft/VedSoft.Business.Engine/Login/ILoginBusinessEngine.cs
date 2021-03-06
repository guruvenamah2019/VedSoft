﻿using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Model.Common;
using VedSoft.Model.Login;
using VedSoft.Model.User;

namespace VedSoft.Business.Login
{
    public interface ILoginBusinessEngine : IBusinessEngineBase
    {
        ILoginBusiness LoginBusiness { get; set; }
        ResponseModel<AuthenticationModel> Authenticate(RequestModel<LoginRequestModel> input);
        bool UpdateLoginToken(LoginResponseModel input);
        string GetRefreshTokenByUserLoginDetailsId(LoginResponseModel input);
        int UpdatePassword(RequestModel<SetPasswordRequestModel> input);

        ResponseModel<UserModel> GetUserDetailsByLoginDetailsId(RequestModel<LoginResponseModel> input);

    }
}
