using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PRScoreRating", Schema = "PerformanceManagement")]
    public class PRScoreRating : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRScoreRatingId { get; set; }
        [Required, StringLength(100), Index("IDX_Unique_ScoreRating", 0, IsUnique = true)]
        public string Rating { get; set; }
        [Required, StringLength(10), Index("IDX_Unique_ScoreRating", 1, IsUnique = true)]
        public string Code { get; set; }
        [Required]
        public decimal MinScore { get; set; }
        [Required]
        public decimal MaxScore { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}