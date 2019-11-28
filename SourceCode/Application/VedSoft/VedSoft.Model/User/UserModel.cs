using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int RollNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int UserTypeId { get; set; }
        public string NotificationEmailId { get; set; }
        public string ContactNumber { get; set; }//json
        public string Address { get; set; }//json
        public string Password { get; set; }//encrypted
        public DateTime? LastLoginDate { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public int? LockAttempts { get; set; }
        public int? TemproryPassword { get; set; }
        public int? Active { get; set; }
        public int UserDetailsId { get; set; }
        public string PasswordValidationCode { get; set; }//encrypted
        public int ActionUserId { get; set; }//It will have the user Id ...who is going to perform the operation on it...not the actual user id
        public int RequestedPageSize { get; set; }
        public int RequestedLanguageId { get; set; }
        public string AcademicInstitute { get; set; }
        public string Qualification { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
        public string ImageName { get; set; }
    }

    public class UserRoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }

    public class StudentModel_Old
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public UserModel FatherUser { get; set; }
        public UserModel MotherUser { get; set; }
        public UserModel GuardianUser { get; set; }
        public int BranchId { get; set; }
        public int IsEnrolled { get; set; }
        public int ActionUserId { get; set; }//It will have the user Id ...who is going to perform the operation on it...not the actual user id
    }

    public class StudentAdmissionModel_Old
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int BranchId { get; set; }
        public int AcademicYearId { get; set; }
        public DateTime? DateOfAdmission { get; set; }
        public int AdmissionTypeId { get; set; }
        public int ActionUserId { get; set; }//It will have the user Id ...who is going to perform the operation on it...not the actual user id
    }

    public class StudentCourseModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int BranchCourseId { get; set; }
        public decimal CourseFee { get; set; }
        public int DiscountAllowed { get; set; }
        public decimal DiscountedFeeAmount { get; set; }
        public int ActionUserId { get; set; }//It will have the user Id ...who is going to perform the operation on it...not the actual user id
    }

    public class StudentAdmissionModel
    {
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RollNo { get; set; }
        public int AcademicInstituteId { get; set; }
        public int IsEnrolled { get; set; }
        public StudentBaseModel StudentDetails { get; set; }
        public GuardianBaseModel GuardianDetails { get; set; }
    }

    public class UserBaseModel
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NotificationId { get; set; }
        public string PrimaryContact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string ImageName { get; set; }
    }

    public class StudentBaseModel:UserBaseModel
    {
        public ParentModel Father { get; set; }
        public ParentModel Mother { get; set; }
        public UserAdditionalDetailsModel Details { get; set; }
    }

    public class GuardianBaseModel:UserBaseModel
    {
        public UserAdditionalDetailsModel Details { get; set; }
    }

    public class UserAdditionalDetailsModel
    {
        public string Qualification { get; set; }
        public decimal AnnualIncome { get; set; }
        public string Occupation { get; set; }
        public AddressModel Address { get; set; }
        public ContactNumberModel ContactNumber { get; set; }
    }

    public class ParentModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NotificationId { get; set; }
        public string PrimaryContact { get; set; }
        public string Qualification { get; set; }
        public decimal AnnualIncome { get; set; }
    }
    public class AddressModel
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
    }
    public class ContactNumberModel
    {
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Landline { get; set; }
    }
}
