using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGarageSale.Data
{
    public class AndreGarageSaleContext : DbContext
    {
        public AndreGarageSaleContext (DbContextOptions<AndreGarageSaleContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Sale> Sale { get; set; } = default!;
        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.Employee> Employee { get; set; } = default!;
        public DbSet<Models.Client> Client { get; set; } = default!;
        public DbSet<Models.Payment> Payment { get; set; } = default!;
        
        //public DbSet<Models.Adress> Adress { get; set; } = default!;
        //public DbSet<Models.Person> Person { get; set; } = default!;
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Sale>().ToTable("Sale");
        }
    }
}
