namespace ApiAuthentication.Migrations {
    using ApiAuthentication.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiAuthentication.Models.AuthContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ApiAuthentication.Models.AuthContext";
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed( AuthContext context ) {
            AddDefaultRecordStatus(context);
            AddDefaultOrganization(context);
            AddDefaultPortfolio(context);
            AddDefaultDepartment(context);
            AddDefaultCostCentre(context);
            AddDefaultDocumentType(context);
            AddDefaultEmployee(context);
            AddDefaultLineManager(context);
            AddDefaultStrategicGoals(context);
            AddDefaultObjectives(context);
            AddDefaultObjectiveDepartment(context);          
            AddDefaultTerms(context);
            AddDefaultReviewPeriods(context);
            AddDefaultPerformanceYear(context);
            AddDefaultPerformanceReview(context);
            AddDefaultRatingScore(context);
            AddDefaultPerformanceReviewProcesses(context);
        }            

        public static void AddDefaultRecordStatus( AuthContext _context ) {
            _context.RecordStatuses.AddOrUpdate(p => new { p.Code, p.Name },
               new RecordStatus {
                   Name = "ACTIVE", Code = "ACT", CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(),
                   ModifiedDate = GetDate(), RecordId = GetRecordId()
               },
               new RecordStatus {
                   Name = "DELETED", Code = "DEL", CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(),
                   ModifiedDate = GetDate(), RecordId = GetRecordId()
               },
                new RecordStatus {
                    Name = "SUSPENDED", Code = "SUS", CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(),
                    ModifiedDate = GetDate(), RecordId = GetRecordId()
                }
           );
            _context.SaveChanges();
        }

        private static void AddDefaultDocumentType( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;

            _context.PRDocumentTypes.AddOrUpdate(p => new { p.Name, p.Code },
                new PRDocumentType {
                    Name = "Individual", Code = "IND", StatusId = statusId, CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(),
                    ModifiedDate = GetDate(), RecordId = GetRecordId()
                },
                new PRDocumentType {
                    Name = "Porfolio", Code = "PORT", StatusId = statusId, CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(),
                    ModifiedDate = GetDate(), RecordId = GetRecordId()
                },
                new PRDocumentType {
                    Name = "Organisational", Code = "ORG", StatusId = statusId, CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(),
                    ModifiedDate = GetDate(), RecordId = GetRecordId()
                },
                new PRDocumentType {
                    Name = "Department", Code = "DEPT", StatusId = statusId, CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(),
                    ModifiedDate = GetDate(), RecordId = GetRecordId()
                },
                new PRDocumentType {
                    Name = "Cost Centre", Code = "CCT", StatusId = statusId, CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(),
                    ModifiedDate = GetDate(), RecordId = GetRecordId()
                }
            );           
            _context.SaveChanges();
        }

        public static void AddDefaultRatingScore( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;

            _context.PMScoreRatings.AddOrUpdate(p => new { p.Rating, p.Code },
                new PRScoreRating {
                    Rating = "Not Achieved", Code = "NA", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(), MinScore = 1.00M, MaxScore = 1.99M
                },
                new PRScoreRating {
                    Rating = "Partially Achieved", Code = "PA", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(), MinScore = 2.00M, MaxScore = 2.99M
                },
                new PRScoreRating {
                    Rating = "Achieved", Code = "A", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(), MinScore = 3.00M, MaxScore = 3.69M
                },
                new PRScoreRating {
                    Rating = "Over Achieved", Code = "OA", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(), MinScore = 3.70M, MaxScore = 4.00M
                }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultOrganization( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;

            _context.Organizations.AddOrUpdate(p => new { p.Name, p.Code, p.StatusId },
                new Organization {
                    Name = "NeNSoft", Code = "N", RecordId = GetRecordId(), StatusId = statusId, CreatedBy = GetUser(),
                    ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultPortfolio(AuthContext _context){
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            var orgId = GetOrg(_context, EnumStatus.ACT).OrganizationId;

            _context.Portfolios.AddOrUpdate(p => new { p.OrganizationId, p.Name, p.Code, p.StatusId },
                new Portfolio {
                    Name = "Core Business", Code = "CB", OrganizationId = orgId, RecordId = GetRecordId(), StatusId = statusId,
                    CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Portfolio {
                    Name = "Support Services", Code = "SS", OrganizationId = orgId, RecordId = GetRecordId(), StatusId = statusId,
                    CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultDepartment( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            var cbPortfolioId = GetPortfolio(_context, EnumStatus.CB).PortfolioId;
            var ssPortfolioId = GetPortfolio(_context, EnumStatus.SS).PortfolioId;

            _context.Deparments.AddOrUpdate(p => new { p.PortfolioId, p.Name, p.Code, p.StatusId },
                new Department {
                    Name = "Information Communication & Technology", Code = "ICT", PortfolioId = cbPortfolioId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Department {
                    Name = "Research & Development", Code = "RAD", PortfolioId = cbPortfolioId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Department {
                    Name = "Supply Chain Management", Code = "SCM", PortfolioId = cbPortfolioId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Department {
                    Name = "Sales and Marketing", Code = "SAM", PortfolioId = ssPortfolioId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Department {
                    Name = "Human Capital", Code = "HC", PortfolioId = ssPortfolioId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Department {
                    Name = "Finance", Code = "FIN", PortfolioId = ssPortfolioId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultCostCentre( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            var ictId = GetDepartment(_context, EnumStatus.ICT).DepartmentId;
            var radId = GetDepartment(_context, EnumStatus.RAD).DepartmentId;
            var hcId = GetDepartment(_context, EnumStatus.HC).DepartmentId;

            _context.CostCentres.AddOrUpdate(p => new { p.DepartmentId, p.Name, p.Code, p.StatusId },
                new CostCentre { 
                    Name = "Web & Desktop App Development", Code = "WDD", DepartmentId = ictId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new CostCentre {
                    Name = "Mobile App Development", Code = "MAD", DepartmentId = ictId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new CostCentre {
                    Name = "IT Shared Services", Code = "ITSS", DepartmentId = ictId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new CostCentre {
                    Name = "Applications Development Research", Code = "ADR", DepartmentId = radId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new CostCentre {
                    Name = "Talent Managment", Code = "HCTM", DepartmentId = hcId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new CostCentre {
                    Name = "HC Recruiment", Code = "HCR", DepartmentId = hcId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new CostCentre {
                    Name = "Learning & Development", Code = "LAD", DepartmentId = ictId, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultEmployee(AuthContext _context) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            var webDevCentreId = GetCostCentre(_context, EnumStatus.WDD).CostCentreId;
            var mobileDevCentreId = GetCostCentre(_context, EnumStatus.MAD).CostCentreId;

            _context.Employees.AddOrUpdate(p => new { p.Code, p.NetworkUsername, p.CostCentreId },
                new Employee { 
                    Code ="E947470", NetworkUsername = "EliasS", Name ="Elias", Surname = "Seboyane", RecordId = GetRecordId(),
                    CostCentreId = webDevCentreId, StatusId = statusId, Email = "e.siboyane@gmail.com", CreatedBy = GetUser(), 
                    Position = "Full Stack Developer",ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Employee {
                    Code = "E947471", NetworkUsername = "JohnD", Name = "John", Surname = "Dow", RecordId = GetRecordId(),
                    CostCentreId = mobileDevCentreId, StatusId = statusId, Email = "j.dow@gmail.com", CreatedBy = GetUser(),
                    Position = "Mobile App Developer", ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Employee {
                    Code = "E947472", NetworkUsername = "KolobeM", Name = "Kolobe", Surname = "Malepe", RecordId = GetRecordId(),
                    CostCentreId = webDevCentreId, StatusId = statusId, Email = "e.siboyane@gmail.com", CreatedBy = GetUser(),
                    Position = "Back-End Developer", ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new Employee {
                    Code = "E947469", NetworkUsername = "MotlokwaL", Name = "Leon", Surname = "Motlokwa", RecordId = GetRecordId(),
                    CostCentreId = webDevCentreId, StatusId = statusId, Email = "e.siboyane@gmail.com", CreatedBy = GetUser(),
                    Position = "Architecture & solution Design", ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultLineManager( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            var managerId = GetEmployee(_context, EnumStatus.E947469).EmployeeId;
            var dev1Id = GetEmployee(_context, EnumStatus.E947470).EmployeeId;
            var dev2Id = GetEmployee(_context, EnumStatus.E947471).EmployeeId;
            var dev3Id = GetEmployee(_context, EnumStatus.E947472).EmployeeId;

            _context.LineManagers.AddOrUpdate(p => new { p.ManagerDetailId, p.EmployeeDetailId },
                new LineManager {
                    ManagerDetailId = managerId, EmployeeDetailId = dev1Id, RecordId = GetRecordId(), StatusId = statusId,
                    CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new LineManager {
                    ManagerDetailId = managerId, EmployeeDetailId = dev2Id, RecordId = GetRecordId(), StatusId = statusId,
                    CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new LineManager {
                    ManagerDetailId = managerId, EmployeeDetailId = dev3Id, RecordId = GetRecordId(), StatusId = statusId,
                    CreatedBy = GetUser(), ModifiedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate()
                }
            );

            _context.SaveChanges();
        }

        public static void AddDefaultPerformanceYear( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;

            _context.PerformanceYears.AddOrUpdate(p => new { p.Name, p.StartDate, p.EndDate },
                new PerformanceYear {
                    Name = "2017 - 2018 Performance Year", StartDate = new DateTime(2017, 04, 01), ModifiedBy = GetUser(),
                    EndDate = new DateTime(2018, 03, 31), StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedDate = GetDate()
                },
                new PerformanceYear {
                    Name = "2018 - 2019 Performance Year", StartDate = new DateTime(2018, 04, 01), ModifiedBy = GetUser(),
                    EndDate = new DateTime(2019, 03, 31), StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedDate = GetDate()
                }
           );
            _context.SaveChanges();
        }

        public static void AddDefaultPerformanceReview(AuthContext _context){
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            var perfYearId = GetPerformanceYear(_context).PerformanceYearId;
            var reviewPeriodId = GetReviewPeriod(_context, EnumStatus.YER).ReviewPeriodId;
            var reviewUserId1 = GetReviewPeriodUser(_context, EnumStatus.E947470).LineManagerId;
            var reviewUserId2 = GetReviewPeriodUser(_context, EnumStatus.E947471).LineManagerId;
            var reviewUserId3 = GetReviewPeriodUser(_context, EnumStatus.E947472).LineManagerId;
            var indDocumentTypeId = GetDocumentType(_context, EnumStatus.IND).PRDocumentTypeId;

            _context.PerformanceReviews.AddOrUpdate(p => new { p.LineManagerId, p.PerformanceYearId, p.ReviewPeriodId },
                new Models.PerformanceReview {
                    PerformanceYearId = perfYearId, ReviewPeriodId = reviewPeriodId, LineManagerId = reviewUserId1, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser(),
                    PRDocumentTypeId = indDocumentTypeId
                },
                new Models.PerformanceReview {
                    PerformanceYearId = perfYearId, ReviewPeriodId = reviewPeriodId, LineManagerId = reviewUserId2, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser(),
                    PRDocumentTypeId = indDocumentTypeId
                },
                new Models.PerformanceReview {
                    PerformanceYearId = perfYearId, ReviewPeriodId = reviewPeriodId, LineManagerId = reviewUserId3, RecordId = GetRecordId(),
                    StatusId = statusId, CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser(),
                    PRDocumentTypeId = indDocumentTypeId
                }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultPerformanceReviewProcesses( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;

            _context.PRProcesses.AddOrUpdate(p => new { p.Process, p.Code },
                new PRProcess {
                    Process = "Content Creation", Code = "PMCC", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(), 
                    CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new PRProcess {
                    Process = "Content Creation Completed", Code = "PMCCC", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new PRProcess {
                    Process = "Employee Scoring", Code = "PMES", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new PRProcess {
                    Process = "Line Manager Scoring", Code = "PMLMS", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new PRProcess {
                    Process = "Scoring Completed", Code = "PMSC", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new PRProcess {
                    Process = "Auditing", Code = "PMA", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new PRProcess {
                    Process = "Auditing Completed", Code = "PMAC", StatusId = statusId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedDate = GetDate(), ModifiedBy = GetUser()
                }
            );
            _context.SaveChanges();
        }

        private static PRDocumentType GetDocumentType( AuthContext _context, EnumStatus documentCode ) {
            return _context.PRDocumentTypes.FirstOrDefault(x => string.Compare(x.Code, documentCode.ToString(), true) == 0 &&
                                                          string.Compare(x.RecordStatus.Code, EnumStatus.ACT.ToString(), true) == 0);
        }

        private static PerformanceYear GetPerformanceYear( AuthContext context ) {
            return context.PerformanceYears.OrderByDescending(x => x.PerformanceYearId).FirstOrDefault();
        }

        private static ReviewPeriod GetReviewPeriod( AuthContext context, EnumStatus reviewPeriodCode ) {
            var result = context.ReviewPeriods.Include(x => x.RecordStatus).
                                               Where(x => string.Compare(x.Code, reviewPeriodCode.ToString(), true) == 0 &&
                                                          string.Compare(x.RecordStatus.Code, EnumStatus.ACT.ToString(), true) == 0);
            return (result.FirstOrDefault());
        }

        private static LineManager GetReviewPeriodUser( AuthContext context, EnumStatus employeeCode ) {
            var result = context.LineManagers.Include(x => x.EmployeeDetail).
                                              FirstOrDefault(x => string.Compare(x.EmployeeDetail.Code, employeeCode.ToString()) == 0 &&
                                                         string.Compare(x.RecordStatus.Code, EnumStatus.ACT.ToString(), true) == 0);
            return (result);
        }

        public static void AddDefaultReviewPeriods( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;

            _context.ReviewPeriods.AddOrUpdate(p => new { p.Name, p.Code },
                new ReviewPeriod {
                    Name = "Year End Review", Code = "YER", RecordId = GetRecordId(), StatusId = statusId, CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedBy = GetUser(),
                },
                 new ReviewPeriod {
                     Name = "Monthly Review", Code = "MR", RecordId = GetRecordId(), StatusId = statusId, CreatedBy = GetUser(),
                     CreatedDate = GetDate(), ModifiedBy = GetUser(),
                 },
                  new ReviewPeriod {
                      Name = "Quarterly Review", Code = "QE", RecordId = GetRecordId(), StatusId = statusId, CreatedBy = GetUser(),
                      CreatedDate = GetDate(), ModifiedBy = GetUser(),
                  }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultTerms(AuthContext _context){
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;

            _context.Terms.AddOrUpdate(p => new { p.Name, p.Code },
                new Term {
                    Name = "Daily", Code = "D", RecordId = GetRecordId(), CreatedDate =GetDate(), CreatedBy = GetUser(), 
                    StatusId = statusId, ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new Term {
                    Name = "Weekly", Code = "W", RecordId = GetRecordId(), CreatedDate =GetDate(), CreatedBy = GetUser(), 
                    StatusId = statusId, ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new Term {
                    Name = "Monthly", Code = "M", RecordId = GetRecordId(), CreatedDate =GetDate(), CreatedBy = GetUser(), 
                    StatusId = statusId, ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new Term {
                    Name = "Quarterly", Code = "Q", RecordId = GetRecordId(), CreatedDate =GetDate(), CreatedBy = GetUser(), 
                    StatusId = statusId, ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new Term {
                    Name = "Half-Yearly", Code = "HY", RecordId = GetRecordId(), CreatedDate =GetDate(), CreatedBy = GetUser(), 
                    StatusId = statusId, ModifiedDate = GetDate(), ModifiedBy = GetUser()
                },
                new Term {
                    Name = "Years", Code = "Y", RecordId = GetRecordId(), CreatedDate =GetDate(), CreatedBy = GetUser(), 
                    StatusId = statusId, ModifiedDate = GetDate(), ModifiedBy = GetUser()
                }
            );
            _context.SaveChanges();
        }

         public static void AddDefaultStrategicGoals( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            _context.StrategicGoals.AddOrUpdate(p => new { p.Goal, p.Code },
                new StrategicGoal {
                    Goal = "Employee Management", Code = "Goal1", DefaultOverallWeight = 10.00M,
                    CreatedDate = GetDate(), CreatedBy = GetUser(), ModifiedBy = GetUser(), ModifiedDate = GetDate(),
                    RecordId = GetRecordId(), StatusId = statusId
                },
                 new StrategicGoal {
                     Goal = "Client Managment", Code = "Goal2", DefaultOverallWeight = 10.00M,
                     CreatedDate = GetDate(), CreatedBy = GetUser(), ModifiedBy = GetUser(), ModifiedDate = GetDate(),
                     RecordId = GetRecordId(), StatusId = statusId
                 },
                 new StrategicGoal {
                     Goal = "Software development standards and procedures", Code = "Goal3", DefaultOverallWeight = 10.00M,
                     CreatedDate = GetDate(), CreatedBy = GetUser(), ModifiedBy = GetUser(), ModifiedDate = GetDate(),
                     RecordId = GetRecordId(), StatusId = statusId
                 }
            );
            _context.SaveChanges();
        }

        public static void AddDefaultObjectives( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            _context.Objectives.AddOrUpdate(p => new { p.Code, p.Name },
                new Objective {
                    Name = "Increase employees morale", Code = "OBJ1", DefaultOverallWeight = 10.00M, CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(),
                    RecordId = GetRecordId(), StatusId = statusId,
                    Description = "Increase employees morale"
                },
                new Objective {
                    Name = "Develop quality client software products", Code = "OBJ2", DefaultOverallWeight = 10.00M,
                    CreatedBy = GetUser(), CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(),
                    RecordId = GetRecordId(), StatusId = statusId,
                    Description = "Develop quality client software products"
                },
                new Objective {
                    Name = "Create good rapport with client", Code = "OBJ3", DefaultOverallWeight = 10.00M, CreatedBy = GetUser(),
                    CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(),
                    RecordId = GetRecordId(), StatusId = statusId,
                    Description = "Create good rapport with client"
                }
            );
            _context.SaveChanges();
        }

        private static void AddDefaultObjectiveDepartment( AuthContext _context ) {
            var statusId = GetStatus(_context, EnumStatus.ACT).StatusId;
            var objective1 = GetObjective(_context, EnumStatus.OBJ1);
            var objective2 = GetObjective(_context, EnumStatus.OBJ2);
            var objective3 = GetObjective(_context, EnumStatus.OBJ3);
            var departICTId = GetDepartment(_context, EnumStatus.ICT).DepartmentId;

            _context.OjectiveAreas.AddOrUpdate(p => new { p.DepartmentId, p.ObjectiveId },
               new ObjectiveArea {
                   DepartmentId = departICTId, ObjectiveId = objective1.ObjectiveId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                   CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(), StatusId = statusId
               },
               new ObjectiveArea {
                   DepartmentId = departICTId, ObjectiveId = objective2.ObjectiveId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                   CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(), StatusId = statusId
               },
               new ObjectiveArea {
                   DepartmentId = departICTId, ObjectiveId = objective3.ObjectiveId, RecordId = GetRecordId(), CreatedBy = GetUser(),
                   CreatedDate = GetDate(), ModifiedBy = GetUser(), ModifiedDate = GetDate(), StatusId = statusId
               }
            );
            _context.SaveChanges();
        }

        private static Objective GetObjective( AuthContext context, EnumStatus objectiveCode ) {
            return context.Objectives.FirstOrDefault(x => string.Compare(x.Code,objectiveCode.ToString(),true) == 0);
        }

        private static RecordStatus GetStatus( AuthContext _context, EnumStatus type ) {
            return _context.RecordStatuses.FirstOrDefault(x => string.Compare(x.Code, type.ToString(), true) == 0);
        }

        private static Organization GetOrg(AuthContext context, EnumStatus status){
            return context.Organizations.Include(x => x.RecordStatus).
                                   FirstOrDefault(x => string.Compare(x.RecordStatus.Code, status.ToString(), true) == 0);
        }

        private static Portfolio GetPortfolio( AuthContext context, EnumStatus portfolioType ) {
            var result = context.Portfolios.Where(x => string.Compare(x.Code, portfolioType.ToString(), true) == 0 && 
                                                       string.Compare(x.RecordStatus.Code,EnumStatus.ACT.ToString(),true) == 0);
            return result.FirstOrDefault();
        }

        private static Department GetDepartment( AuthContext _context, EnumStatus departmentCode ) {
            var result = _context.Deparments.Where(x => string.Compare(x.Code, departmentCode.ToString(), true) == 0 &&
                                                       string.Compare(x.RecordStatus.Code, EnumStatus.ACT.ToString(), true) == 0);
            return (result.FirstOrDefault());
        }

        private static CostCentre GetCostCentre(AuthContext _context, EnumStatus costCentreCode) {
            var result = _context.CostCentres.Where(x => string.Compare(x.Code, costCentreCode.ToString(), true) == 0 &&
                                                       string.Compare(x.RecordStatus.Code, EnumStatus.ACT.ToString(), true) == 0);
            return (result.FirstOrDefault());
        }

        private static Employee GetEmployee( AuthContext _context, EnumStatus employeeCode ) {
            var result = _context.Employees.Where(x => string.Compare(x.Code, employeeCode.ToString(), true) == 0 &&
                                                       string.Compare(x.RecordStatus.Code, EnumStatus.ACT.ToString(), true) == 0);
            return (result.FirstOrDefault());
        }

        private static Guid GetRecordId() {
            return new Guid(new Guid().ToString().ToUpper());
        }

        private static string GetUser() {
            return "MES";
        }

        private static DateTime GetDate() {
            return DateTime.Now;
        }
    }

    /// <summary>
    /// SQL Default Values CONFIGUIRATION
    /// </summary>
    internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator {
        protected override void Generate( AddColumnOperation addColumnOperation ) {
            SetCreatedUtcColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate( CreateTableOperation createTableOperation ) {
            SetCreatedUtcColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        private static void SetCreatedUtcColumn( IEnumerable<ColumnModel> columns ) {
            foreach (var columnModel in columns) {
                SetCreatedUtcColumn(columnModel);
            }
        }

        private static void SetCreatedUtcColumn( PropertyModel column ) {
            if (column.Name == "ModifiedDate") {
                column.DefaultValueSql = "GETUTCDATE()";
            }
            if (column.Name == "CreatedDate") {
                column.DefaultValueSql = "GETUTCDATE()";
            }
            if (column.Name == "RecordId") {
                column.DefaultValueSql = "NEWID()";
            }
        }
    }
}
