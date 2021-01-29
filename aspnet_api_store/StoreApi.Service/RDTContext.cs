using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreApi.Service.Models;

namespace StoreApi.Service
{
  public class RDTContext : DbContext
  {
    public DbSet<Author> Author { get; set; }
    public DbSet<Article> Article { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("");
      //CONNECTION TO AZURE
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Author>().HasKey(s => s.EntityId);
      builder.Entity<Article>().HasKey(c => c.EntityId);

      // builder.Entity<StarTrek>().HasData(
      //   new StarTrek()
      //   {
      //     EntityId = 1,
      //     Characters = new List<Character>()
      //     {
      //       new Character() { EntityId = 1, Name = "Capt. Picard" }
      //     }
      //   }
      // );
    }
  }
}