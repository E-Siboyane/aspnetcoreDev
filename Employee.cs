using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("Employee", Schema = "ReportingStructure")]
    public class Employee : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required, StringLength(50), Index("IDX_Unique_Employee", 0, IsUnique = true)]
        public string Code { get; set; }
        [Required, StringLength(50), Index("IDX_Unique_Employee", 1, IsUnique = true)]
        public string NetworkUsername { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, ForeignKey("CostCentre")]
        public int CostCentreId { get; set; }
        public virtual CostCentre CostCentre { get; set; }
        [Required, StringLength(150)]
        public string Position { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}