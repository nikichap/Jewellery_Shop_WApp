using Jewellery_Shop.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models
{
    public class JewelleryShopDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
    }
}
