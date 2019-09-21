import { CONTROLLER_NAME } from './controller-name.constant';

export const COURSE_SERVICE_URL = {
    ACTION_ADD_COURSE_HIERARCHY: CONTROLLER_NAME.MASTER_CONTROLLER + "/AddCourseHierarchy",
    ACTION_UPDATE_COURSE_HIERARCHY: CONTROLLER_NAME.MASTER_CONTROLLER + "/UpdateCourseHierarchy",
    ACTION_GET_COURSE_HIERARCHY: CONTROLLER_NAME.MASTER_CONTROLLER + "/GetCourseHierarchy",
    ACTION_MAKE_INACTIVE_COURSE_HIERARCHY: CONTROLLER_NAME.MASTER_CONTROLLER + "/MakeInActiveCourseHierarchy",
    ACTION_GET_CUSTOMER_DETAILS: CONTROLLER_NAME.MASTER_CONTROLLER + "/GetCustomerDetails",
    ACTION_GET_CUSTOMER_DETAILS_BY_SUB_DOMAIN: CONTROLLER_NAME.MASTER_CONTROLLER + "/GetCustomerDetailsBySubDomain",
}

export const BRANCH_SERVICE_URL = {
    ACTION_ADD_CUSTOMER_BRANCH: CONTROLLER_NAME.MASTER_CONTROLLER + "/AddBranch",
    ACTION_UPDATE_CUSTOMER_BRANCH: CONTROLLER_NAME.MASTER_CONTROLLER + "/UpdateBranch",
    ACTION_GET_CUSTOMER_BRANCH: CONTROLLER_NAME.MASTER_CONTROLLER + "/GetBranches",
    ACTION_MAKE_INACTIVE_CUSTOMER_BRANCH: CONTROLLER_NAME.MASTER_CONTROLLER + "/MakeInActiveBranch",
}
export const CUSTOMER_ROLE_SERVICE_URL = {
    ACTION_ADD_CUSTOMER_ROLE: CONTROLLER_NAME.MASTER_CONTROLLER + "/AddRole",
    ACTION_UPDATE_CUSTOMER_ROLE: CONTROLLER_NAME.MASTER_CONTROLLER + "/UpdateRole",
    ACTION_GET_CUSTOMER_ROLE: CONTROLLER_NAME.MASTER_CONTROLLER + "/GetRole",
    ACTION_MAKE_INACTIVE_CUSTOMER_ROLE: CONTROLLER_NAME.MASTER_CONTROLLER + "/MakeInActiveRole",
}
export const BANK_SERVICE_URL = {
    ACTION_ADD_BANK: CONTROLLER_NAME.MASTER_CONTROLLER + "/AddBank",
    ACTION_UPDATE_BANK: CONTROLLER_NAME.MASTER_CONTROLLER + "/UpdateBank",
    ACTION_GET_BANK: CONTROLLER_NAME.MASTER_CONTROLLER + "/GetBankList",
    ACTION_MAKE_INACTIVE_BANK: CONTROLLER_NAME.MASTER_CONTROLLER + "/MakeInActiveBank",
}
export const INSTITUTE_SERVICE_URL = {
    ACTION_ADD_INSTITUTE: CONTROLLER_NAME.MASTER_CONTROLLER + "/AddEducationInstitute",//http://localhost:65253/api/Customer/AddEducationEducationInstitute
    ACTION_UPDATE_INSTITUTE: CONTROLLER_NAME.MASTER_CONTROLLER + "/UpdateEducationInstitute",
    ACTION_GET_INSTITUTE: CONTROLLER_NAME.MASTER_CONTROLLER + "/GetEducationInstituteList",
    ACTION_MAKE_INACTIVE_INSTITUTE: CONTROLLER_NAME.MASTER_CONTROLLER + "/MakeInActiveEducationInstitute",
}
export const ACADEMIC_YEAR_SERVICE_URL = {
    ACTION_ADD_ACADEMIC_YEAR: CONTROLLER_NAME.MASTER_CONTROLLER + "/AddAcademicYear",
    ACTION_UPDATE_ACADEMIC_YEAR: CONTROLLER_NAME.MASTER_CONTROLLER + "/UpdateAcademicYear",
    ACTION_GET_ACADEMIC_YEAR: CONTROLLER_NAME.MASTER_CONTROLLER + "/GetAcademicYears",
    ACTION_MAKE_INACTIVE_ACADEMIC_YEAR: CONTROLLER_NAME.MASTER_CONTROLLER + "/MakeInActiveAcademicYear",
}

