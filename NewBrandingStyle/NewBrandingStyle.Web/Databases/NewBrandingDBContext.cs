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
        public DbSet<ProductsEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //fluent configuration
        }
    }
}
