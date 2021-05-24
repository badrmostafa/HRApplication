namespace HRApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateArmyTechTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CareerFields",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthGovernorateId = c.Int(nullable: false),
                        BirthNeighborhoodId = c.Int(nullable: false),
                        CareerFieldId = c.Int(),
                        Address = c.String(),
                        CompanyJobId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CareerFields", t => t.CareerFieldId)
                .ForeignKey("dbo.CompanyJobs", t => t.CompanyJobId)
                .ForeignKey("dbo.Governorates", t => t.BirthGovernorateId, cascadeDelete: true)
                .ForeignKey("dbo.Neighborhoods", t => t.BirthNeighborhoodId, cascadeDelete: true)
                .Index(t => t.BirthGovernorateId)
                .Index(t => t.BirthNeighborhoodId)
                .Index(t => t.CareerFieldId)
                .Index(t => t.CompanyJobId);
            
            CreateTable(
                "dbo.CompanyJobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        JobArrangement = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeQualifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QualificationId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.QualificationId, cascadeDelete: true)
                .Index(t => t.QualificationId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Governorates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Neighborhoods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GovernorateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Governorates", t => t.GovernorateId, cascadeDelete: false)
                .Index(t => t.GovernorateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "BirthNeighborhoodId", "dbo.Neighborhoods");
            DropForeignKey("dbo.Employees", "BirthGovernorateId", "dbo.Governorates");
            DropForeignKey("dbo.Neighborhoods", "GovernorateId", "dbo.Governorates");
            DropForeignKey("dbo.EmployeeQualifications", "QualificationId", "dbo.Qualifications");
            DropForeignKey("dbo.EmployeeQualifications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CompanyJobId", "dbo.CompanyJobs");
            DropForeignKey("dbo.Employees", "CareerFieldId", "dbo.CareerFields");
            DropIndex("dbo.Neighborhoods", new[] { "GovernorateId" });
            DropIndex("dbo.EmployeeQualifications", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeQualifications", new[] { "QualificationId" });
            DropIndex("dbo.Employees", new[] { "CompanyJobId" });
            DropIndex("dbo.Employees", new[] { "CareerFieldId" });
            DropIndex("dbo.Employees", new[] { "BirthNeighborhoodId" });
            DropIndex("dbo.Employees", new[] { "BirthGovernorateId" });
            DropTable("dbo.Neighborhoods");
            DropTable("dbo.Governorates");
            DropTable("dbo.Qualifications");
            DropTable("dbo.EmployeeQualifications");
            DropTable("dbo.CompanyJobs");
            DropTable("dbo.Employees");
            DropTable("dbo.CareerFields");
        }
    }
}
