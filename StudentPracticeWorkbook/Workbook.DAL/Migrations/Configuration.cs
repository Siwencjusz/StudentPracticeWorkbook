using Workbook.Commons;
using Workbook.DAL.Entities;

namespace Workbook.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Workbook.DAL.StudentWorkBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Workbook.DAL.StudentWorkBookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            Role[] roles = new[]
            {
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = AppRoles.Admin.ToString()
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = AppRoles.Firma.ToString()
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = AppRoles.Opiekun.ToString()
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = AppRoles.Student.ToString()
                }
            };
            context.Roles.AddOrUpdate(roles);
            //context.Roles.AddOrUpdate(
            //    new Role()
            //    {
            //        Id= new Guid("AAE154BC-4F6B-4FDD-95D1-ECED015A4934"),
            //        Name = "Admin"
            //    }
            //);
            Department[] departments = new[]
            {
                new Department()
                {
                    Id = new Guid("AAE154BC-4F6B-4FDD-95D1-ECED015A4934"),
                    Name = "Admin"
                },
                new Department()
                {
                    Id = Guid.NewGuid(),
                    Name = "Wmii"
                },
                new Department()
                {
                    Id = Guid.NewGuid(),
                    Name = "WNT"
                },
                new Department()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rakologia"
                }
            };
            context.Departments.AddOrUpdate(
                departments
            );
            User[] users = new[]
            {

                new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "user",
                    Name = "admin",
                    LastName = "adm",
                    //user
                    HashPassword = "7hHLsZBS5AsHqsDKBgwj7g==",
                    Email = "userMail",
                    PhoneNumber = "666",
                    RoleId = roles[0].Id,
                    DepartmentId = new Guid("AAE154BC-4F6B-4FDD-95D1-ECED015A4934")
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "user1",
                    Name = "stud",
                    LastName = "adm",
                    //user
                    HashPassword = "7hHLsZBS5AsHqsDKBgwj7g==",
                    Email = "userMail",
                    PhoneNumber = "666",
                    RoleId = roles[3].Id,
                    DepartmentId = departments[1].Id
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "user2",
                    Name = "firma",
                    LastName = "adm",
                    //user
                    HashPassword = "7hHLsZBS5AsHqsDKBgwj7g==",
                    Email = "userMail",
                    PhoneNumber = "666",
                    RoleId = roles[1].Id,
                    DepartmentId = departments[1].Id
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "user3",
                    Name = "prowadzacy",
                    LastName = "adm",
                    //user
                    HashPassword = "7hHLsZBS5AsHqsDKBgwj7g==",
                    Email = "userMail",
                    PhoneNumber = "666",
                    RoleId = roles[2].Id,
                    DepartmentId = departments[1].Id
                }
                ,new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "stud",
                    Name = "stud",
                    LastName = "adm",
                    //user
                    HashPassword = "7hHLsZBS5AsHqsDKBgwj7g==",
                    Email = "userMail",
                    PhoneNumber = "666",
                    RoleId = roles[3].Id,
                    DepartmentId = departments[2].Id
                },new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "firma",
                    Name = "firma",
                    LastName = "adm",
                    //user
                    HashPassword = "7hHLsZBS5AsHqsDKBgwj7g==",
                    Email = "userMail",
                    PhoneNumber = "666",
                    RoleId = roles[1].Id,
                    DepartmentId = departments[2].Id
                },new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "prowadzacy",
                    Name = "prowadzacy",
                    LastName = "adm",
                    //user
                    HashPassword = "7hHLsZBS5AsHqsDKBgwj7g==",
                    Email = "userMail",
                    PhoneNumber = "666",
                    RoleId = roles[2].Id,
                    DepartmentId = departments[2].Id
                }
            };
            context.Users.AddOrUpdate(users
            );
            WorkBook[] workBooks = new[]
                {
                new WorkBook()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = users[5].Id,
                    DepartmentId = departments[2].Id,
                    EmployeeId = users.LastOrDefault().Id
                  },
                new WorkBook()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = users[3].Id,
                    DepartmentId = departments[1].Id,
                    EmployeeId = users[4].Id
                  }
                };
            context.WorkBooks.AddOrUpdate(workBooks);
        }
    }
}
