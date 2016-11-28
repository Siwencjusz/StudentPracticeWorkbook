﻿using System.Data.Entity;
using Workbook.DAL.Entities;

namespace Workbook.DAL
{

    public class StudentWorkBookContext : DbContext
    {
        public StudentWorkBookContext()
            : base("StudentBook")
        {
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
    }
}
