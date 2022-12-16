using Microsoft.EntityFrameworkCore;
using NZWalks.api.Models.Domain;

namespace NZWalks.api.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }  // To Create Table of the Region Type Table Regions
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }


    }
}
