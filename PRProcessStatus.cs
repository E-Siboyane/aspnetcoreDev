using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PRProcessStatus", Schema = "PerformanceManagement")]
    public class PRProcessStatus : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRProcessStatusId { get; set; }
        [Required, ForeignKey("PerformanceReview"), Index("IDX_Unique_PRProcessStatus", 0, IsUnique = true)]
        public int PerformanceReviewId { get; set; }
        public virtual PerformanceReview PerformanceReview { get; set; }
        [Required, ForeignKey("PRProcess"), Index("IDX_Unique_PRProcessStatus", 1, IsUnique = true)]
        public int PRProcessId { get; set; }
        public virtual PRProcess PRProcess { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}