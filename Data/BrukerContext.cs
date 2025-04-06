using Microsoft.EntityFrameworkCore;
using TSDOblig1.Models;

namespace TSDOblig1.Data
{
    public class BrukerContext : DbContext
    {
        public BrukerContext(DbContextOptions<BrukerContext> options)
            : base(options)
        {
        }

        public DbSet<Bruker> Brukere { get; set; }
    }
}
