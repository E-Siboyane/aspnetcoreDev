using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiAuthentication.Models {
    [Table("Department", Schema = "ReportingStructure")]
    public class Department : AuditProperty, IStatus {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        [Required, StringLength(100), Index("IDX_Unique_Department", 0, IsUnique = true)]
        public string Name { get; set; }
        [Required, StringLength(10), Index("IDX_Unique_Department", 1, IsUnique = true)]
        public string Code { get; set; }
        [Required, ForeignKey("Portfolio"), Index("IDX_Unique_Department", 2, IsUnique = true)]
        public int PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        [Required, ForeignKey("RecordStatus"), Index("IDX_Unique_Department", 3, IsUnique = true)]
        public int StatusId { get; set; }
        public virtual RecordStatus RecordStatus { get; set; }
    }
}