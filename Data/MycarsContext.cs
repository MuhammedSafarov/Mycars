using Mycars.Models;
using Microsoft.EntityFrameworkCore;

namespace Mycars.Data
{
    public class MycarsContext : DbContext
    {
        public MycarsContext(DbContextOptions<MycarsContext> opt) : base(opt)
        {
            
        }

        public DbSet<Brands> Brands { get; set; }
        public DbSet<Features> Features { get; set; }

    }
}