using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("Organization", Schema = "ReportingStructure")]
    public class Organization : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganizationId { get; set; }
        [Required, StringLength(100), Index("IDX_Unique_Organization", 0, IsUnique = true)]
        public string Name { get; set; }
        [Required, StringLength(10), Index("IDX_Unique_Organization", 1, IsUnique = true)]
        public string Code { get; set; }
        [Required, Index("IDX_Unique_Organization", 2, IsUnique = true)]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}