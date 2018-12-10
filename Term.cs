using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiAuthentication.Models {
    [Table("Term", Schema = "Admin")]
    public class Term : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TermId { get; set; }
        [Required, StringLength(50), Index("IXD_Unique_TermName", 0, IsUnique = true)]
        public string Name { get; set; }
        [Required, StringLength(10), Index("IXD_Unique_TermCode", 0, IsUnique = true)]
        public string Code { get; set; }
        [Required, ForeignKey("RecordStatus")]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}