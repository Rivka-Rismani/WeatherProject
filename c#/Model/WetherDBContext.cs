using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wether.Model
{
    public class WetherDBContext : DbContext
    {
        public WetherDBContext(DbContextOptions<WetherDBContext> options) : base(options)
        {
        }
        public virtual DbSet<FavoriteCities> FavoriteCities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FavoriteCities>().HasKey("CityId");
        }
    }
}
