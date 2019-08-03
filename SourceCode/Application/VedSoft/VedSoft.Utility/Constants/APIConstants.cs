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
        public const string ActionGetCustomerDetailsBySubDomain = "GetCustomerDetailsBySubDomain";
    }

    public class LoginAPIAction
    {
        public const string RoutePrefixLogin = "api/Login";

        public const string ActionAuthenticate = "Authenticate";
        public const string ActionRefreshToken = "RefreshToken";
        public const string SetPassword = "SetPassword";
        public const string Logout = "Logout";
        public const string UserDetailsByToken = "GetUserDetailsByToken";
    }

    public class CourseAPIAction
    {
        public const string RoutePrefixCourse = "api/Course";

        public const string ActionAddCourseHierarchy = "AddCourseHierarchy";
        public const string ActionUpdateCourseHierarchy = "UpdateCourseHierarchy";
        public const string ActionGetCourseHierarchy = "GetCourseHierarchy";
        public const string ActionMakeInActiveCourseHierarchy = "MakeInActiveCourseHierarchy";
    }
}
