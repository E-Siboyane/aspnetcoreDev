using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PRStrategicGoal", Schema = "PerformanceManagement")]
    public class PRStrategicGoal : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRStrategicGoalId { get; set; }
        [Required, ForeignKey("PerformanceReview"), Index("IDX_Unique_PerformanceReviewStrategicGoal", 0, IsUnique = true)]
        public int PerformanceReviewId { get; set; }
        public virtual PerformanceReview PerformanceReview { get; set; }
        [Required, ForeignKey("StrategicGoal"), Index("IDX_Unique_PerformanceReviewStrategicGoal", 1, IsUnique = true)]
        public int StrategicGoalId { get; set; }
        public virtual StrategicGoal StrategicGoal { get; set; }
        [Required, Range(0.01, 100.00, ErrorMessage = "Weight should range from 0.01 to 100.00")]
        public decimal Weight { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}