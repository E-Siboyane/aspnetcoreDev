using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ApiAuthentication.Models {
    public class AuthContext : IdentityDbContext<IdentityUser> {
        public AuthContext()
            : base("AuthContext") {

        }

        public static AuthContext Create() {
            return new AuthContext();
        }

        protected override void OnModelCreating( DbModelBuilder modelBuilder ) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<MetadataSetting> MetadataSettings { get; set; }
        public DbSet<RecordStatus> RecordStatuses { get; set; }
        public DbSet<StrategicGoal> StrategicGoals { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<MeasureArea> MeasureAreas { get; set; }
        public DbSet<ObjectiveArea> OjectiveAreas { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<ReviewPeriod> ReviewPeriods { get; set; }
        public DbSet<PerformanceYear> PerformanceYears { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Department> Deparments { get; set; }
        public DbSet<CostCentre> CostCentres { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LineManager> LineManagers { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<PRStrategicGoal> PerformanceReviewStrategicGoals { get; set; }
        public DbSet<PRDocumentType> PRDocumentTypes { get; set; }
        public DbSet<PRScoreRating> PMScoreRatings { get; set; }
        public DbSet<PRObjective> PRObjectives { get; set; }
        public DbSet<PRMeasure> PRMeasures { get; set; }
        public DbSet<PRScore> PRScores { get; set; }
        public DbSet<PRProcess> PRProcesses { get; set; }
        public DbSet<PRProcessStatus> PRProcessStatuses { get; set; }
    }
}