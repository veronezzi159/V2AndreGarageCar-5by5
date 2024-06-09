using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGarageJob.Data
{
    public class AndreGarageJobContext : DbContext
    {
        public AndreGarageJobContext (DbContextOptions<AndreGarageJobContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Job> Job { get; set; } = default!;
    }
}
