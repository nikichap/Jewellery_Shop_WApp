using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.Entities
{
    public class ItemReview
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
    }
}
