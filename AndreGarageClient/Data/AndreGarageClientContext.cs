using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGarageClient.Data
{
    public class AndreGarageClientContext : DbContext
    {
        public AndreGarageClientContext (DbContextOptions<AndreGarageClientContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Client> Client { get; set; } = default!;
        public DbSet<Models.Person> Person { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Client>().ToTable("Client");
            modelBuilder.Entity<Models.Person>().ToTable("Person");
            modelBuilder.Entity<Models.Person>().HasKey(p => p.Document);
        }
    }
}
