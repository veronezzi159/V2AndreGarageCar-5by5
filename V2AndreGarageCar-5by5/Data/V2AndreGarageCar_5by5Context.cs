using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace V2AndreGarageCar_5by5.Data
{
    public class V2AndreGarageCar_5by5Context : DbContext
    {
        public V2AndreGarageCar_5by5Context (DbContextOptions<V2AndreGarageCar_5by5Context> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
    }
}
