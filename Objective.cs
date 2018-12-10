using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("Objective", Schema = "Admin")]
    public class Objective: AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectiveId { get; set; }
        [Required, Index("IXD_Unique_Ojective", 0, IsUnique = true),StringLength(256)]
        public string Name { get; set; }
        [Required, Index("IXD_Unique_Ojective", 1, IsUnique = true), StringLength(10)]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Range(0.01, 100.00, ErrorMessage = "Weight should range from 0.01 to 100.00")]
        public decimal DefaultOverallWeight { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}