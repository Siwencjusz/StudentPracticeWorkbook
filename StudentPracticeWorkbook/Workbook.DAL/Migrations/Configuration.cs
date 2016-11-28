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

            #region roles
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
            #endregion
            #region departments
            Department[] departments = new[]
            {
                new Department()
                {
                    Id = Guid.NewGuid(),
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
                    Name = "WNE"
                }
            };
            context.Departments.AddOrUpdate(
                departments
            );
            #endregion
            #region users
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
                    DepartmentId = departments[0].Id
                },
                new Student()
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
                new Company()
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
                new Employee()
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
            };
            context.Users.AddOrUpdate(users
            );
            #endregion
            #region workBooks
            Entities.Workbook[] workBooks = new[]
                {
                new Entities.Workbook()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = users[1].Id,
                    DepartmentId = departments[2].Id,
                    EmployeeId = users[3].Id
                  },
                new Entities.Workbook()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = users[1].Id,
                    DepartmentId = departments[1].Id,
                    EmployeeId = users[3].Id
                  }
                };
            context.WorkBooks.AddOrUpdate(workBooks);
            #endregion
        }
    }
}
