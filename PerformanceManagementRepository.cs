using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAuthentication.Models {
    public class PerformanceManagementRepository : BaseRepository, IPerformanceManagementRepository, IDisposable {
         private readonly AuthContext _applicationDbContext;
         public PerformanceManagementRepository( AuthContext _context ) {
            this._applicationDbContext = _context;
        }
        /// <summary>
        /// Return Application Database DbContext
        /// </summary>
        public AuthContext GetApplicationDbContext { get { return _applicationDbContext; } }

        /// <summary>
        /// Dispose the Context after use
        /// </summary>
        public void Dispose() {
            _applicationDbContext.Dispose();
        }
    }
}