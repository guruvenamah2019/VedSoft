using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedSoft.Data.Contracts.Model
{
    [Table("CUSTOMER_MASTER")]
    public class CustomerModelDB
    {
        [Key]
        [Column("ID")]
        public int CustomerId { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("CODE")]
        public string Code { get; set; }
        [Column("SUB_DOMAIN")]
        public string SubDomain { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("ACTIVE")]
        public int Active { get; set; }
        [Column("CONTACT_NO")]
        public string ContactNumber { get; set; }
        [Column("ADDRESS")]
        public string Address { get; set; }
        [Column("OTHER_INFO")]
        public string OtherInfo { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
    }

    [Table("CUSTOMER_COURSE_HIERACHY")]
    public class CustomerCourseHierarchyDB
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }
        [Column("HIERACHY_LEVEL")]
        public int? HierarchyLevel { get; set; }
        [Column("PARENT_ID")]
        public int? ParentId { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
        [Column("ACTIVE")]
        public int? Active { get; set; }
    }


}
