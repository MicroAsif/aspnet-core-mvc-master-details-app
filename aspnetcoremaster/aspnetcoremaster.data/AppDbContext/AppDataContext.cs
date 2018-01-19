using aspnetcoremaster.core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcoremaster.data.AppDbContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<InventoryModel> Inventory { get; set; }
        public DbSet<InventoryItemModel> InventoryItem { get; set; }

    }
}
