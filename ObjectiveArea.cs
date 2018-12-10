using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiAuthentication.Models {
    [Table("ObjectiveArea", Schema = "Admin")]
    public class ObjectiveArea : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectiveAreaId { get; set; }
        [Required, ForeignKey("Objective"), Index("IXD_Unique_OjectiveArea", 0, IsUnique = true)]
        public int ObjectiveId { get; set; }
        public virtual Objective Objective { get; set; }
        [Required, ForeignKey("Department"), Index("IXD_Unique_OjectiveArea", 1, IsUnique = true)]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}