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
}
