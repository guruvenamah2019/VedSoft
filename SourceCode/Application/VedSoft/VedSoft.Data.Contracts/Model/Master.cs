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

    [Table("CUSTOMER_SUBJECT_HIRARCHY")]
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

    [Table("CUSTOMER_BRANCHES")]
    public class CustomerBranchesDB
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }
        [Column("CODE")]
        public string Code { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("ACTIVE")]
        public int? Active { get; set; }
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
        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
    }

    [Table("ACADEMIC_YEARS")]
    public class AcademicYearsDB
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ACADEMIC_YEAR")]
        public string AcademicYear { get; set; }
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }
        [Column("ACTIVE")]
        public int? Active { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
    }

    [Table("BANK")]
    public class BankDB
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string BankName { get; set; }
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }
        [Column("ACTIVE")]
        public int? Active { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
    }

    [Table("CUSTOMER_EDUCATIONAL_INSTITUTIONS")]
    public class EducationInstituteDB
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("INSTITUTION_TYPE_ID")]
        public int InstitutionTypeId { get; set; }
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("ACTIVE")]
        public int? Active { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
    }

    [Table("CUSTOMER_COURSES")]
    public class CustomerCourseDB
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }
        [Column("VEDIC_COURSE_ID")]
        public int? VedicCourseId { get; set; }
        [Column("COURSE_TYPE_ID")]
        public int? CourseTypeId { get; set; }
        [Column("COURSE_DESCRIPTION")]
        public string CourseDescription { get; set; }
        [Column("DURATION")]
        public int Duration { get; set; }
        [Column("DURATION_UOM")]
        public string DurationUOM { get; set; }
        [Column("COURSE_COST")]
        public decimal CourseCost { get; set; }
        [Column("ACTIVE")]
        public int? Active { get; set; }
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
        [Column("MODIFIED_DATE")]
        public DateTime? ModifiedDate { get; set; }
    }

    [Table("CUSTOMER_COURSE_SUBJECT_MAPPING")]
    public class CustomerCourseSubjectMappingDB:CommonDBTableColumns
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }
        [Column("CUSTOMER_COURSE_ID")]
        public int CustomerCourseId { get; set; }
        [Column("CUSTOMER_SUBJECT_HIERACHY_ID")]
        public int CustomerSubjectHierarchyId { get; set; }
    }
}
