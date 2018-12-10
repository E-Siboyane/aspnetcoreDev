using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PRScore", Schema = "PerformanceManagement")]
    public class PRScore : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRScoreId { get; set; }
        [Required, ForeignKey("PRMeasure")]
        public int PRMeasureId { get; set; }
        public virtual PRMeasure PRMeasure { get; set; }
        public decimal OwnScore { get; set; }
        public decimal LineManagerScore { get; set; }
        public decimal AuditedScore { get; set; }
        public string OwnComment { get; set; }
        public string LineManagerComment { get; set; }
        public string AuditSComments { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}