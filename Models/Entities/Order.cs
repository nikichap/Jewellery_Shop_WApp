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
        public DateTime OrderDate { get; set; }
        
        [ForeignKey("User")]
        public int UserId {get; set;}

        [ForeignKey("Cart")]
        public string CartId { get; set; }

        public decimal FullPrice { get; set; }
    }
}
