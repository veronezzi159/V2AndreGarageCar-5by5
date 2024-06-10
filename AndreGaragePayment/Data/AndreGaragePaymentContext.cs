using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGaragePayment.Data
{
    public class AndreGaragePaymentContext : DbContext
    {
        public AndreGaragePaymentContext (DbContextOptions<AndreGaragePaymentContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Payment> Payment { get; set; } = default!;
        public DbSet<Models.Card> Card { get; set; } = default!;
        public DbSet<Models.Boleto> Boleto { get; set; } = default!;
        public DbSet<Models.Pix> Pix { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Payment>().ToTable("Payment");
            modelBuilder.Entity<Models.Card>().ToTable("Card");
            modelBuilder.Entity<Models.Boleto>().ToTable("Boleto");
            modelBuilder.Entity<Models.Pix>().ToTable("Pix");
        }
        public DbSet<Models.PixType>? PixType { get; set; }
    }
}
