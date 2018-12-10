using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("MetadataSetting", Schema = "Admin")]
    public class MetadataSetting : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MetadataSettingId { get; set; }
        [Required, StringLength(50), Index("IDX_Unique_Metadata", 0, IsUnique = true)]
        public string Setting { get; set; }
        [Required, StringLength(256),Index("IDX_Unique_Metadata", 1, IsUnique = true)]
        public string Value { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}