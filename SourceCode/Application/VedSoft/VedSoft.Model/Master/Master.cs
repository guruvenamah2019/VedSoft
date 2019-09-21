using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.Master
{
    public class CourseHiearchyModel
    {
        public int? Id { get; set; } 
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
        public int? HierarchyLevel { get; set; }
    }

    public class CustomerBranchModel
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string OtherInfo { get; set; }
        public int UserId { get; set; }
    }

    public class AcademicYearModel
    {
        public int? Id { get; set; }
        public string AcademicYear { get; set; }
        public int UserId { get; set; }
    }

    public class BankModel
    {
        public int? Id { get; set; }
        public string BankName { get; set; }
        public int UserId { get; set; }
    }

    public class EducationInstituteModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int InstituteTypeId { get; set; }
        public int UserId { get; set; }
    }

}
