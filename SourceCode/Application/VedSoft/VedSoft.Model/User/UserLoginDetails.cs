using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.User
{
    public class UserLoginDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public int CustomerId { get; set; }
        public string LoginSourceDetails { get; set; }
        public DateTime LogOutDate { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LoginToken { get; set; }
        public string LoginRefreshToken { get; set; }
    }
}
