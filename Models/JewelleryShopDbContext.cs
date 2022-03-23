using Jewellery_Shop.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models
{
    public class JewelleryShopDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Favourites> Favourites { get; set; }

        public JewelleryShopDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
