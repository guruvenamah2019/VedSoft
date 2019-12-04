using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VedSoft.Data.Contracts.Model
{
    [Table("USER_MASTER")]
    public class UserMasterDB
    {
        [Key]
        [Column("ID")]
        public int UserId { get; set; }
        [Column("LOGIN_ID")]
        public string LoginId { get; set; }
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Column("FIRST_NAME")]
        public string FirstName { get; set; }
        [Column("MIDDLE_NAME")]
        public string MiddleName { get; set; }
        [Column("LAST_NAME")]
        public string LastName{ get; set; }
        [Column("PRIMARY_CONTACTNO")]
        public string PrimaryContactNo { get; set; }
        [Column("USER_TYPE_ID")]
        public int? UserTypeId { get; set; }
        [Column("CONTACT_NO")]
        public string ContactNo { get; set; }
        [Column("ADDRESS")]
        public string Address { get; set; }
        [Column("NOTIFICATION_ID")]
        public string NotificationEmailId { get; set; }
        [Column("CREATED_BY")]
        public int? CreatedBy { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
        [Column("ACTIVE")]
        public int? Active { get; set; }
        [Column("CUSTOMER_ID")]
        public int? CustomerId { get; set; }
    }

    [Table("USER_DETAILS")]
    public class UserDetailsDB
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Column("PASSWORD_EXPIRATION_DATE")]
        public DateTime? PasswordExpirationDate { get; set; }
        [Column("PWD_VALIDATION_CODE")]
        public string PasswordValidationCode { get; set; }
        [Column("LANGUAGE_ID")]
        public int? LanguageId { get; set; }
        [Column("PAGE_SIZE")]
        public int? PageSize { get; set; }
        [Column("IS_TEMPORARYPASSWORD")]
        public int? IsTemproryPassword { get; set; }
        [Column("LAST_LOGIN_DATE")]
        public DateTime? LastLoginDate { get; set; }
        [Column("LOCK_ATTEMPTS")]
        public int? LockAttemptCount { get; set; }
        [Column("CREATED_BY")]
        public int? CreatedBy { get; set; }
        [Column("CREATED_DATE")]
        public DateTime? CreatedDate { get; set; }
        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
    }

    [Table("USER_LOGIN_DETAILS")]
    public class UserLoginDetailsDB
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Column("LOGIN_DATE")]
        public DateTime? LoginDate { get; set; }
        [Column("CUSTOMER_ID")]
        public int? CustomerId { get; set; }
        [Column("USER_BROWSER_SYSTEM_DETAILS")]
        public string LoginSourceDetails { get; set; }
        [Column("LOG_OUT")]
        public DateTime? LogOutDateTime { get; set; }
        [Column("IS_SUCCESS")]
        public int StatusId { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("CREATED_DATE")]
        public DateTime? CreatedDate { get; set; }
        [Column("MODIFIED_BY")]
        public int ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
        [Column("LOGIN_TOKEN")]
        public string LoginToken { get; set; }
        [Column("LOGIN_REFRESH_TOKEN")]
        public string LoginRefreshToken { get; set; }
    }

    [Table("STUDENT")]
    public class StudentDB:CommonDBTableColumns
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("BIOMETRIC_ID")]
        public string BiometricId { get; set; }
        [Column("ROLL_NO")]
        public int RollNo { get; set; }
        [Column("USER_ID")]
        public int UserId { get; set; }
        //[Column("FATHER_USER_ID")]
        //public int FatherUserId { get; set; }
        //[Column("MOTHER_USER_ID")]
        //public int MotherUserId { get; set; }
        [Column("GUARDIAN_USER_ID")]
        public int? GuardinanUserId { get; set; }
        [Column("IS_ENROLLED")]
        public int IsEnrolled { get; set; }
    }

    [Table("STUDENT_DETAILS")]
    public class StudentDetailsDB : CommonDBTableColumns
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("STUDENT_ID")]
        public int StudentId { get; set; }
        [Column("ACADEMIC_INSTITUE_ID")]
        public int AcademicInstituteId { get; set; }
        [Column("STUDENT_IMAGE_PATH")]
        public string StudentImagePath { get; set; }
        [Column("FATHER_FIRST_NAME")]
        public string FatherFirstName { get; set; }
        [Column("FATHER_MIDDLE_NAME")]
        public string FatherMiddleName { get; set; }
        [Column("FATHER_LAST_NAME")]
        public string FatherLastName { get; set; }
        [Column("FATHER_CONTACTNO")]
        public string FatherContactNo { get; set; }
        [Column("FATHER_ANUAL_INCOME")]
        public decimal FatherAnnualIncome { get; set; }
        [Column("FATHER_QUALIFICATION")]
        public string FatherQualification { get; set; }
        [Column("FATHER_OCCUPATION")]
        public string FatherOccupation { get; set; }
        [Column("MOTHER_FIRST_NAME")]
        public string MotherFirstName { get; set; }
        [Column("MOTHER_MIDDLE_NAME")]
        public string MotherMiddleName { get; set; }
        [Column("MOTHER_LAST_NAME")]
        public string MotherLastName { get; set; }
        [Column("MOTHER_CONTACTNO")]
        public string MotherContactNo { get; set; }
        [Column("MOTHER_ANUAL_INCOME")]
        public decimal MotherAnnualIncome { get; set; }
        [Column("MOTHER_QUALIFICATION")]
        public string MotherQualification { get; set; }
        [Column("DATE_OF_BIRTH")]
        public DateTime DateOfBirth { get; set; }
        [Column("STUDENT_QUALIFICATION")]
        public string StudentQualification { get; set; }
    }

    [Table("STUDENT_ADMISSION_DETAILS")]
    public class StudentAdmissionDetailsDB : CommonDBTableColumns
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("STUDENT_ID")]
        public int StudentId { get; set; }
        [Column("BRANCH_ID")]
        public int BranchId { get; set; }
        [Column("ACADEMIC_YEARID")]
        public int ACADEMIC_YEARID { get; set; }
        [Column("DATE_OF_ADMISSION")]
        public DateTime? DateOfAdmission { get; set; }
        [Column("ADMISSION_TYPEID")]
        public int AdmissionTypeId { get; set; }
    }

    [Table("STUDENT_COURSES")]
    public class StudentCoursesDB : CommonDBTableColumns
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("STUDENT_ID")]
        public int StudentId { get; set; }
        [Column("BRANCH_COURSES_ID")]
        public int BranchCourseId { get; set; }
        [Column("COURSE_FEE_AMOUNT")]
        public decimal CourseFeeAmount { get; set; }
        [Column("DISCOUNT_ALLOWED")]
        public int DiscountAllowed { get; set; }
        [Column("DISCOUNTED_FEE_AMOUNT")]
        public decimal DiscountedFeeAmount { get; set; }
    }

    [Table("STUDENT_BRANCHES")]
    public class StudentBranchesDB : CommonDBTableColumns
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("STUDENT_ID")]
        public int StudentId { get; set; }
        [Column("BRANCH_ID")]
        public int BranchId { get; set; }
    }
}
