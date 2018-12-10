using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PRDocumentType", Schema = "PerformanceManagement")]
    public class PRDocumentType : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRDocumentTypeId { get; set; }
        [Required, StringLength(100), Index("IDX_Unique_PRDocumentType", 0, IsUnique = true)]
        public string Name { get; set; }
        [Required, StringLength(10), Index("IDX_Unique_PRDocumentType", 1, IsUnique = true)]
        public string Code { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}