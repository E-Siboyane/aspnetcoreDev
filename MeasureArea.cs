using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication.Models {
    [Table("MeasureArea", Schema = "Admin")]
    public class MeasureArea: AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeasureAreaId { get; set; }
        [Required, ForeignKey("Measure"), Index("IXD_Unique_MeasureArea", 0, IsUnique = true)]
        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
        [Required, ForeignKey("Department"), Index("IXD_Unique_MeasureArea", 1, IsUnique = true)]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}