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

        public const string ActionAddSubjectHierarchy = "AddSubjectHierarchy";
        public const string ActionUpdateSubjectHierarchy = "UpdateSubjectHierarchy";
        public const string ActionGetSubjectHierarchy = "GetSubjectHierarchy";
        public const string ActionMakeInActiveSubjectHierarchy = "MakeInActiveSubjectHierarchy";
        public const string ActionAddCustomerCourse = "AddCustomerCourse";
        public const string ActionUpdateCustomerCourse = "UpdateCustomerCourse";
        public const string ActionGetCustomerCourseList = "GetCustomerCourseList";
        public const string ActionMakeInActiveCustomerCourse = "MakeInActiveCustomerCourse";
        public const string ActionAddCustomerCourseSubject = "AddCustomerCourseSubject";
        public const string ActionUpdateCustomerCourseSubject = "UpdateCustomerCourseSubject";
        public const string ActionGetCustomerCourseSubjectList = "GetCustomerCourseSubjectList";
        public const string ActionMakeInActiveCustomerCourseSubject = "MakeInActiveCustomerCourseSubject";
    }

    public class UserAPIAction
    {
        public const string RoutePrefixUser = "api/User";

        public const string ActionAddUser = "AddUser";
        public const string ActionUpdateUser = "UpdateUser";
        public const string ActionGetUserList = "GetUserList";
        public const string ActionMakeInActiveUser = "MakeInActiveUser";
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

    public class StudentAPIAction
    {
        public const string ActionAddStudent = "AddStudent";
        public const string ActionUpdateStudent = "UpdateStudent";
        public const string ActionGetStudentList = "GetStudentList";
        public const string ActionMakeInActiveStudent = "MakeInActiveStudent";
        public const string ActionAddStudentAdmission = "AddStudentAdmission";
        public const string ActionUpdateStudentAdmission = "UpdateStudentAdmission";
        public const string ActionGetStudentAdmissionList = "GetStudentAdmissionList";
        public const string ActionMakeInActiveStudentAdmission = "MakeInActiveStudentAdmission";
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

    public class EducationInstituteAPIAction
    {
        public const string ActionAddEducationInstitute = "AddEducationInstitute";
        public const string ActionUpdateEducationInstitute = "UpdateEducationInstitute";
        public const string ActionGetEducationInstituteList = "GetEducationInstituteList";
        public const string ActionMakeInActiveEducationInstitute = "MakeInActiveEducationInstitute";
    }
}
