using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGaragePurchase.Data
{
    public class AndreGaragePurchaseContext : DbContext
    {
        public AndreGaragePurchaseContext (DbContextOptions<AndreGaragePurchaseContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Purchase> Purchase { get; set; } = default!;
        public DbSet<Models.Car> Car { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Purchase>().ToTable("Purchase");
        }
    }
}
