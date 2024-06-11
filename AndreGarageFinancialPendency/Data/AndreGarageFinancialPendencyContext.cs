using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGarageFinancialPendency.Data
{
    public class AndreGarageFinancialPendencyContext : DbContext
    {
        public AndreGarageFinancialPendencyContext (DbContextOptions<AndreGarageFinancialPendencyContext> options)
            : base(options)
        {
        }

        public DbSet<Models.FinancialPendency> FinancialPendency { get; set; } = default!;
        public DbSet<Models.Client> Client { get; set; } = default!;
        public DbSet<Models.Person> Person { get; set; } = default!;
        public DbSet<Models.Adress> Adress { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.FinancialPendency>().ToTable("FinancialPendency");
            modelBuilder.Entity<Models.Client>().ToTable("Client");
            modelBuilder.Entity<Models.Person>().ToTable("Person");
            modelBuilder.Entity<Models.Adress>().ToTable("Adress");
        }
    }
}
