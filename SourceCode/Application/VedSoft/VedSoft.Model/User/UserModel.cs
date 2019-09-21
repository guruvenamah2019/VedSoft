using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        //public string EmailId { get; set; }
        public string NotificationEmailId { get; set; }
        public string Password { get; set; }//encrypted
        public DateTime? LastLoginDate { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public int? LockAttempts { get; set; }
        public int? TemproryPassword { get; set; }
        public int? Active { get; set; }
        public int UserDetailsId { get; set; }
    }

    public class UserRoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }

    public class Student
    {
        public int UserId { get; set; }
        public int FatherUserId { get; set; }
        public int MotherUserId { get; set; }
        public int GuardianUserId { get; set; }
        public int IsEnrolled { get; set; }
    }

    public class StudentAdmissionDetails
    {
        public int StudentId { get; set; }
        public int BranchId { get; set; }
        public int AcademicYearId { get; set; }
        public int DateOfAdmission { get; set; }
        public int AdmissionTypeId { get; set; }
    }

    public class StudentC
    {
        public int StudentId { get; set; }
        public int BranchId { get; set; }
        public int AcademicYearId { get; set; }
        public int DateOfAdmission { get; set; }
        public int AdmissionTypeId { get; set; }
    }

    public class UserDetailsModel
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int FatherUserId { get; set; }
        public int MotherUserId { get; set; }
    }
        
}
