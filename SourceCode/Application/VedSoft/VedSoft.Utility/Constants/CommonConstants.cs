using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Utility.Constants
{
    public class ApiCallConstants
    {
        public static string GetCommonAPIAddress(string apiUrl, string actionName)
        {
            return string.Format("{0}/{1}", apiUrl, actionName);
        }
        public static string ContentTypeJSON
        {
            get { return "application/json"; }
        }
        public static string APICallingLanguageKey
        {
            get { return "Accept-Language"; }
        }
        public static string APICallingLanguageValue
        {
            get { return "en-US"; }
        }
    }

    public enum LoginStatusConstants
    {
        Success=1,
        InvalidCredentials=2,
        PasswordExpired=3,
        LoginAttemptExceeded=4,
        TemproryPassword=5,
        InActive = 6,
        InvalidRefreshToken=7,
        AccontLocked = 8
    }

    public class CommonConstants
    {
        public const int UserLoginAttemptsCountExceeded = 5;
        public const int ActiveStatus = 1;
        public const int Success = 1;
        public const string UserLoginDetailsIdClaim  = "UserLoginDetailsIdClaim";
        public const int AccountLockedTimeInMiutes = 30;
    }
        
}
