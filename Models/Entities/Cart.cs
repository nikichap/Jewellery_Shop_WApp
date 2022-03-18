using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public Item Item { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
