using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiAuthentication.Models {
    [Table("ReviewPeriod", Schema = "Admin")]
    public class ReviewPeriod : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewPeriodId { get; set; }
        [Required, Index("IXD_Unique_ReviewPeriodName", 0, IsUnique = true),StringLength(50)]
        public string Name { get; set; }
        [Required, Index("IXD_Unique_ReviewPeriodCode", 0, IsUnique = true), StringLength(10)]
        public string Code { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}