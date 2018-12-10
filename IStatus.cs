using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAuthentication.Models {
    public interface IStatus {
        int StatusId { get; set; }
        RecordStatus RecordStatus { get; set; }
    }
}
