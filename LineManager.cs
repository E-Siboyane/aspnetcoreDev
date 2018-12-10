using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("LineManager", Schema = "ReportingStructure")]
    public class LineManager : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineManagerId { get; set; }
        [Required, ForeignKey("EmployeeDetail"), Index("IXD_Unique_EmployeeManager", 0, IsUnique = true)]
        public int EmployeeDetailId { get; set; }
        public virtual Employee EmployeeDetail { get; set; }
        [Required, ForeignKey("ManagerDetail"), Index("IXD_Unique_EmployeeManager", 1, IsUnique = true)]
        public int ManagerDetailId { get; set; }
        public virtual Employee ManagerDetail { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}