using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("PRProcess", Schema = "PerformanceManagement")]
    public class PRProcess : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRProcessId { get; set; }
        [Required, StringLength(100), Index("IDX_Unique_Process", 0, IsUnique = true)]
        public string Process { get; set; }
        [Required, StringLength(10), Index("IDX_Unique_Process", 1, IsUnique = true)]
        public string Code { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}