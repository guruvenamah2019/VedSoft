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

    public class CustomerBranchAPIAction
    {
        public const string ActionAddCustomerBranch = "AddBranch";
        public const string ActionUpdateCustomerBranch = "UpdateBranch";
        public const string ActionGetCustomerBranch = "GetBranches";
        public const string ActionMakeInActiveCustomerBranch = "MakeInActiveBranch";
    }

    public class UserRoleAPIAction
    {
        public const string ActionAddCustomerRole = "AddRole";
        public const string ActionUpdateCustomerRole = "UpdateRole";
        public const string ActionGetCustomerRole = "GetRole";
        public const string ActionMakeInActiveCustomerRole = "MakeInActiveRole";
    }

    public class AcademicYearAPIAction
    {
        public const string ActionAddAcademicYear = "AddAcademicYear";
        public const string ActionUpdateAcademicYear = "UpdateAcademicYear";
        public const string ActionGetAcademicYears = "GetAcademicYears";
        public const string ActionMakeInActiveAcademicYear = "MakeInActiveAcademicYear";
    }

    public class BankAPIAction
    {
        public const string ActionAddBank = "AddBank";
        public const string ActionUpdateBank = "UpdateBank";
        public const string ActionGetBankList = "GetBankList";
        public const string ActionMakeInActiveBank = "MakeInActiveBank";
    }
}
