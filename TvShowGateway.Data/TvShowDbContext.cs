using Microsoft.EntityFrameworkCore;
using TvShowGateway.Data.Model;

namespace TvShowGateway.Data
{
    public class TvShowDbContext: DbContext
    {
        public virtual DbSet<TvShow> TvShows { get; set; }

        public virtual DbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
