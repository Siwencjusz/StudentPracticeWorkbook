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
            //Role[] roles = new[]
            //{
            //    new Role
            //    {
            //        Id = new Guid(),
            //        Name = AppRoles.Admin.ToString()
            //    },
            //    new Role
            //    {
            //        Id = new Guid(),
            //        Name = AppRoles.Firma.ToString()
            //    },
            //    new Role
            //    {
            //        Id = new Guid(),
            //        Name = AppRoles.Opiekun.ToString()
            //    },
            //    new Role
            //    {
            //        Id = new Guid(),
            //        Name = AppRoles.Student.ToString()
            //    }
            //};
            //context.Roles.AddOrUpdate(roles);
            //context.Users.AddOrUpdate(
            //    new User()
            //    {
            //        Id = new Guid(),
            //        Login = "user",
            //        HashPassword = "user",
            //        Email = "userMail",
            //        PhoneNumber = "666",
            //        Role = roles[0]
            //    }
            //);
            //
        }
    }
}
