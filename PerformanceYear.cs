using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiAuthentication.Models {
    [Table("PerformanceYear", Schema = "Admin")]
    public class PerformanceYear : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerformanceYearId { get; set; }
        [Required, Index("IXD_Unique_PerformanceYear", 0, IsUnique = true)]
        public DateTime StartDate { get; set; }
        [Required, Index("IXD_Unique_PerformanceYear", 1, IsUnique = true)]
        public DateTime EndDate { get; set; }
        [Required, Index("IXD_Unique_PerformanceYear", 2, IsUnique = true),StringLength(50)]
        public string Name { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}