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

}
