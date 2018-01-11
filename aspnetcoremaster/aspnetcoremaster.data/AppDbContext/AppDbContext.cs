using aspnetcoremaster.core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcoremaster.data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<ProductModel> Product { get; set; }

    }
}
