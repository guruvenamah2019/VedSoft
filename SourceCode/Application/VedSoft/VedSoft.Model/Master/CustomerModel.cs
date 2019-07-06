using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VedSoft.Model.Master
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string SubDomain { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string OtherInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }


}
