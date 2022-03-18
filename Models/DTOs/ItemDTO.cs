using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int QuantityAvailable { get; set; }
        public string CreatedBy { get; set; }
    }
}
