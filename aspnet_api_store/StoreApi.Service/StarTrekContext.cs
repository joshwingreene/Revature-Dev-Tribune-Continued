using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreApi.Service.Models;

namespace StoreApi.Service
{
  public class StarTrekContext : DbContext
  {
    public DbSet<StarTrek> StarTreks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("connection sting");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<StarTrek>().HasKey(s => s.EntityId);
      builder.Entity<Character>().HasKey(c => c.EntityId);

      builder.Entity<StarTrek>().HasData(
        new StarTrek()
        {
          EntityId = 1,
          Characters = new List<Character>()
          {
            new Character() { EntityId = 1, Name = "Capt. Picard" }
          }
        }
      );
    }
  }
}