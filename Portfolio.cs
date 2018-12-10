using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("Portfolio", Schema = "ReportingStructure")]
    public class Portfolio : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PortfolioId { get; set; }
        [Required, StringLength(100), Index("IDX_Unique_Portfolio",0,IsUnique = true)]
        public string Name { get; set; }
        [Required, StringLength(10), Index("IDX_Unique_Portfolio", 1, IsUnique = true)]
        public string Code { get; set; }
         [Required, ForeignKey("Organization"), Index("IDX_Unique_Portfolio", 2, IsUnique = true)]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        [Required, ForeignKey("RecordStatus"), Index("IDX_Unique_Portfolio", 3, IsUnique = true)]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}