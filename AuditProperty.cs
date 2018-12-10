using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ApiAuthentication.Models {
    public abstract class AuditProperty {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid RecordId { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime  CreatedDate { get; set; }
        [Required, StringLength(100)]
        public string CreatedBy { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ModifiedDate { get; set; }
        [Required, StringLength(100)]
        public string ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        [StringLength(100)]
        public string DeletedBy { get; set; }
    }
}
