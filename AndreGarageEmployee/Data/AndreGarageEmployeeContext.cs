using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGarageEmployee.Data
{
    public class AndreGarageEmployeeContext : DbContext
    {
        public AndreGarageEmployeeContext (DbContextOptions<AndreGarageEmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Employee> Employee { get; set; } = default!;
        public DbSet<Models.Person> Person { get; set; } = default!;
        public DbSet<Models.Position> Position { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Employee>().ToTable("Employee");
            modelBuilder.Entity<Models.Person>().ToTable("Person");
            modelBuilder.Entity<Models.Person>().HasKey(p => p.Document);
            modelBuilder.Entity<Models.Position>().ToTable("Position");
        }

       
    }
}
