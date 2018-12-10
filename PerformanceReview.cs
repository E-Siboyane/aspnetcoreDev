using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PerformanceReview", Schema = "PerformanceManagement")]
    public class PerformanceReview : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerformanceReviewId { get; set; }
        [Required, ForeignKey("ReviewPeriod"), Index("IDX_Unique_PerformanceReview",0,IsUnique=true)]
        public int ReviewPeriodId { get; set; }
        public virtual ReviewPeriod ReviewPeriod { get; set; }
        [Required, ForeignKey("PerformanceYear"), Index("IDX_Unique_PerformanceReview", 1, IsUnique = true)]
        public int PerformanceYearId { get; set; }
        public virtual PerformanceYear PerformanceYear { get; set; }
        [Required, ForeignKey("LineManager"), Index("IDX_Unique_PerformanceReview", 2, IsUnique = true)]
        public int LineManagerId { get; set; }
        public virtual LineManager LineManager { get; set; }
          [Required, ForeignKey("PRDocumentType"), Index("IDX_Unique_PerformanceReview", 3, IsUnique = true)]
        public int PRDocumentTypeId { get; set; }
        public virtual PRDocumentType PRDocumentType { get; set; }
        public string OwnOverallComment { get; set; }
        public string LineManagerComment { get; set; }
        public string AuditComment { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}