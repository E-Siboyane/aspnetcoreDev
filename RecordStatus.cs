using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ApiAuthentication.Models {
    [Table("RecordStatus", Schema = "Admin")]
   public class RecordStatus : AuditProperty {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }
        [Required, StringLength(50), Index("IXD_Unique_RecordStatus", 0, IsUnique = true)]
        public string Name { get; set; }
        [Required, StringLength(10), Index("IXD_Unique_RecordStatus", 1, IsUnique = true)]
        public string Code { get; set; }
    }
}
