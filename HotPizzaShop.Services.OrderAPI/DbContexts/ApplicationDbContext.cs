using HotPizzaShop.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotPizzaShop.Services.OrderAPI.DbContexts
{
  
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            public DbSet<OrderHeader> OrderHeader { get; set; }
            public DbSet<OrderDetails> OrderDetails { get; set; }


        }
    
}
