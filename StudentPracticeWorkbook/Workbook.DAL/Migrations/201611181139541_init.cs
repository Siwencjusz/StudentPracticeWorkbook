namespace Workbook.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookNotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Note = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        WorkBookId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkBooks", t => t.WorkBookId, cascadeDelete: true)
                .Index(t => t.WorkBookId);
            
            CreateTable(
                "dbo.WorkBooks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DocumentUrl = c.String(),
                        CompanyId = c.Guid(),
                        EmployeeId = c.Guid(),
                        StudentId = c.Guid(),
                        DepartmentId = c.Guid(),
                        GradeCompany = c.Int(),
                        GradeDepartment = c.Int(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.CompanyId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Users", t => t.EmployeeId)
                .ForeignKey("dbo.Users", t => t.StudentId)
                .Index(t => t.CompanyId)
                .Index(t => t.EmployeeId)
                .Index(t => t.StudentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        HashPassword = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DetailInformation = c.String(),
                        DepartmentId = c.Guid(),
                        RoleId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookNotes", "WorkBookId", "dbo.WorkBooks");
            DropForeignKey("dbo.WorkBooks", "StudentId", "dbo.Users");
            DropForeignKey("dbo.WorkBooks", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.WorkBooks", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.WorkBooks", "CompanyId", "dbo.Users");
            DropForeignKey("dbo.WorkBooks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.WorkBooks", new[] { "User_Id" });
            DropIndex("dbo.WorkBooks", new[] { "DepartmentId" });
            DropIndex("dbo.WorkBooks", new[] { "StudentId" });
            DropIndex("dbo.WorkBooks", new[] { "EmployeeId" });
            DropIndex("dbo.WorkBooks", new[] { "CompanyId" });
            DropIndex("dbo.BookNotes", new[] { "WorkBookId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Departments");
            DropTable("dbo.Users");
            DropTable("dbo.WorkBooks");
            DropTable("dbo.BookNotes");
        }
    }
}
