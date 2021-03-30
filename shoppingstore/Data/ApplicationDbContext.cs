using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shoppingstore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace shoppingstore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            //builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Producer", NormalizedName = "PRODUCER" });
        }

        //public DbSet<ShoppingStoreEntities> ShoppingStoreEntities { get; set; }
        public DbSet<ShoppingCartItem>ShoppingCartItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public IEnumerable Users { get; internal set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }

}
