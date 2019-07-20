using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Model.User;

namespace VedSoft.Model.Login
{
    public class LoginRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginSourceInfo { get; set; }//Browser, IP etc in JSON format
    }

    public class LoginResponseModel
    {
        public Int64 LoginDetailsId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int LoginStatus { get; set; }
        public int UserId { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }

    public class AuthenticationModel
    {
        public LoginResponseModel LoginResponseDetails { get; set; }
        public UserModel UserDetails { get; set; }
    }
}
