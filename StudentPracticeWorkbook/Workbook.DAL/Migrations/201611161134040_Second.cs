namespace Workbook.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            AlterColumn("dbo.Users", "DepartmentId", c => c.Guid());
            AlterColumn("dbo.Users", "RoleId", c => c.Guid());
            CreateIndex("dbo.Users", "DepartmentId");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            AlterColumn("dbo.Users", "RoleId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "DepartmentId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Users", "RoleId");
            CreateIndex("dbo.Users", "DepartmentId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
