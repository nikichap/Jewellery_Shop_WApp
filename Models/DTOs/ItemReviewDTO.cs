using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.DTOs
{
    public class ItemReviewDTO
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public string WrittenBy { get; set; }
        public ItemDTO Item { get; set; } 
    }
}
