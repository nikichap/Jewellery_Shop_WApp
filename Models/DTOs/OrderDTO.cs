using Jewellery_Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public Order Item { get; set; }
        public DateTime OrderedOn { get; set; }
        public int Quantity { get; set; }
        public string CreatedBy { get; set; }

    }
}
