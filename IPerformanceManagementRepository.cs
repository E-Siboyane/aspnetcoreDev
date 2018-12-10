using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAuthentication.Models {
    public interface IPerformanceManagementRepository : IBaseRepository {
        AuthContext GetApplicationDbContext { get; }
    }
}