using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ChoosenItem { get; set; } 
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        //public decimal FullPrice { get; set; }

        [ForeignKey("Item")]
        //public int QuantityAvailable { get; set; }
        public int IdItem { get; set; }
        public Item Item { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
