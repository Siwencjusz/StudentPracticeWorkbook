using System.Data.Entity;
using Workbook.DAL.Entities;
using Workbook = Workbook.DAL.Entities.Workbook;

namespace Workbook.DAL
{

    public class StudentWorkBookContext : DbContext
    {
        public StudentWorkBookContext()
            : base("StudentBook")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public static StudentWorkBookContext Create()
        {
            return new StudentWorkBookContext();
        }
        public DbSet<Entities.Workbook> WorkBooks { get; set; }
        public DbSet<Entities.Department> Departments { get; set; }
        public DbSet<Entities.Role> Roles { get; set; }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<BookNote> BookNotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entities.Workbook>()
                .HasOptional(n => n.Employee)
                .WithMany(n=>n.ManagedWorkBooks)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Entities.Workbook>()
                .HasOptional(n => n.Student)
                .WithMany(n => n.OwnWorkBooks)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entities.Workbook>()
                .HasOptional(n => n.Company)
                .WithMany(n => n.ManagedWorkBooks)
                .WillCascadeOnDelete(true);

            //modelBuilder.Entity<BookNote>()
            //    .HasRequired(n => n.Workbook)
            //    .WithMany(n => n.Noteses)
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<BackLog>()
            //    .HasOptional(n => n.Project)
            //    .WithMany(n => n.BackLogs)
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<DeveloperTask>()
            //    .HasOptional(n => n.BackLog)
            //    .WithMany(n => n.Tasks)
            //    .WillCascadeOnDelete(true);

        }
    }
}
