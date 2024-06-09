using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGarageCarJob.Data
{
    public class AndreGarageCarJobContext : DbContext
    {
        public AndreGarageCarJobContext (DbContextOptions<AndreGarageCarJobContext> options)
            : base(options)
        {
        }

        public DbSet<Models.CarJob> CarJob { get; set; } = default!;
        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.Job> Job { get; set; } = default!;
        
    }
}
