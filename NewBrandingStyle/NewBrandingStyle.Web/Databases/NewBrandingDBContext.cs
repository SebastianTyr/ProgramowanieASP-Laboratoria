using System;
using Microsoft.EntityFrameworkCore;
using NewBrandingStyle.Web.Entities;

namespace NewBrandingStyle.Web.Databases
{
    public class NewBrandingDBContext : DbContext
    {
        public NewBrandingDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ItemEntity> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ItemEntity>().Property(x => x.Id).IsRequired();
            builder.Entity<ItemEntity>().Property(x => x.Name).HasColumnType("varchar");
            builder.Entity<ItemEntity>().Property(x => x.Description).HasColumnType("varchar");
            builder.Entity<ItemEntity>().Property(x => x.IsVisible).HasColumnType("bit");
        }
    }
}
