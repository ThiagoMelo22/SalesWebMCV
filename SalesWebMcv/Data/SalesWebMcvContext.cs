using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMcv.Models
{
    public class SalesWebMcvContext : DbContext
    {
        public SalesWebMcvContext (DbContextOptions<SalesWebMcvContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMcv.Models.Department> Department { get; set; } = default!;
    }
}
