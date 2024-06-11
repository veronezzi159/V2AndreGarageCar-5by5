using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGarageDriver.Data
{
    public class AndreGarageDriverContext : DbContext
    {
        public AndreGarageDriverContext (DbContextOptions<AndreGarageDriverContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Driver> Driver { get; set; } = default!;
        public DbSet<Models.CNH> CNH { get; set; } = default!;
        public DbSet<Models.Category> Category { get; set; } = default!;
        public DbSet<Models.Person> Person { get; set; } = default!;
        public DbSet<Models.Financing> Financing { get; set; } = default!;
        public DbSet<Models.Insurance> Insurance { get; set; } = default!;
        public DbSet<Models.Client> Client { get; set; } = default!;
        public DbSet<Models.Dependant> Dependant { get; set; } = default!;
        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.FinancialPendency> Pendency { get; set; } = default!;
        public DbSet<Models.Sale> Sale { get; set; }    = default!;
        public DbSet<Models.Bank> Bank { get; set; } = default!;
        //employee
        public DbSet<Models.Employee> Employee { get; set; } = default!;
        //adress
        public DbSet<Models.Adress> Adress { get; set; } = default!;
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Driver>().ToTable("Driver");
            modelBuilder.Entity<Models.CNH>().ToTable("CNH");
            modelBuilder.Entity<Models.Category>().ToTable("Category");
            modelBuilder.Entity<Models.Person>().ToTable("Person");
            //Address
            modelBuilder.Entity<Models.Adress>().ToTable("Adress");
            modelBuilder.Entity<Models.Client>().ToTable("Client");
            //employee 
            modelBuilder.Entity<Models.Employee>().ToTable("Employee");
            modelBuilder.Entity<Models.Person>().HasKey(p => p.Document);
            //Financing
            modelBuilder.Entity<Models.Financing>().ToTable("Financing");
            modelBuilder.Entity<Models.Financing>()
                .HasOne(f => f.Sale);
            //Insurance 
            modelBuilder.Entity<Models.Insurance>().ToTable("Insurance");
            //Dependant
            modelBuilder.Entity<Models.Dependant>().ToTable("Dependant");
            //FinancialPendency
            modelBuilder.Entity<Models.FinancialPendency>().ToTable("Pendency");
            //Bank
            modelBuilder.Entity<Models.Bank>().ToTable("Bank");

                

        }
    }
}
