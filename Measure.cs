using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("Measure", Schema = "Admin")]
    public class Measure : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeasureId { get; set; }
        [Required, StringLength(2500), Index("IDX_Unique_Measure", 0, IsUnique = true)]
        public string Name { get; set; }
        [Required, StringLength(10), Index("IDX_Unique_Measure", 1, IsUnique = true)]
        public string Code { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}