using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PRMeasure", Schema = "PerformanceManagement")]
    public class PRMeasure : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRMeasureId { get; set; }
        [Required, ForeignKey("MeasureArea"), Index("IDX_Unique_PRMeasure", 0, IsUnique = true)]
        public int MeasureAreaId { get; set; }
        public virtual MeasureArea MeasureArea { get; set; }
        [Required, ForeignKey("PRObjective"), Index("IDX_Unique_PRMeasure", 1, IsUnique = true)]
        public int PRObjectiveId { get; set; }
        public virtual PRObjective PRObjective { get; set; }
        [Required, ForeignKey("Term"), Index("IDX_Unique_PRMeasure", 2, IsUnique = true)]
        public int TermId { get; set; }
        public virtual Term Term { get; set; }
        [Required, Range(0.01, 100.00, ErrorMessage = "Weight should range from 0.01 to 100.00")]
        public decimal Weight { get; set; }
        public string SourceOfInformation { get; set; }
        public string SubjectMatterExpert { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}