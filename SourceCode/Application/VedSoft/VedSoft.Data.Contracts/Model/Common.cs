using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VedSoft.Data.Contracts.Model
{
    public class CommonDBTableColumns
    {
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
}
