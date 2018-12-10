using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("CostCentre", Schema = "ReportingStructure")]
    public class CostCentre : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CostCentreId { get; set; }
        [Required, Index("IXD_Unique_CostCentre", 0, IsUnique = true), StringLength(100)]
        public string Name { get; set; }
        [Required, Index("IXD_Unique_CostCentre", 1, IsUnique = true), StringLength(10)]
        public string Code { get; set; }
        [Required, ForeignKey("Department"), Index("IXD_Unique_CostCentre", 2, IsUnique = true)]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required, ForeignKey("RecordStatus"), Index("IXD_Unique_CostCentre", 3, IsUnique = true)]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}