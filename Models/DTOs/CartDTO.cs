using Jewellery_Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }

    }
}
