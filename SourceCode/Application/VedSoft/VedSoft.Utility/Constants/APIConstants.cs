using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Utility.Constants
{
    public class MasterAPIAction
    {
        public const string RoutePrefixMaster = "api/Customer";

        public const string ActionAddCustomer ="AddCustomer";

        public const string ActionGetCustomerDetails = "GetCustomerDetails";
    }

    public class LoginAPIAction
    {
        public const string RoutePrefixLogin = "api/Login";

        public const string ActionAuthenticate = "Authenticate";
        public const string ActionRefreshToken = "RefreshToken";
    }
}
