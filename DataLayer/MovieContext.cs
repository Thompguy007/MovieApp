using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<BestMatchResults> BestMatchResults { get; set; }  // Add this line

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map the BestMatchResult to the query results without creating a table
            modelBuilder.Entity<BestMatchResults>().HasNoKey();
        }
    }
}
