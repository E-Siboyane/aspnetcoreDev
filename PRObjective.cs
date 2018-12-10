using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PRObjective", Schema = "PerformanceManagement")]
    public class PRObjective : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRObjectiveId { get; set; }
        [Required, ForeignKey("PRStrategicGoal"), Index("IDX_Unique_PRObjective", 0, IsUnique = true)]
        public int PRStrategicGoalId { get; set; }
        public virtual PRStrategicGoal PRStrategicGoal { get; set; }
        [Required, ForeignKey("ObjectiveArea"), Index("IDX_Unique_PRObjective", 1, IsUnique = true)]
        public int ObjectiveAreaId { get; set; }
        public virtual ObjectiveArea ObjectiveArea { get; set; }
        [Required, Range(0.01, 100.00, ErrorMessage = "Weight should range from 0.01 to 100.00")]
        public decimal Weight { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}