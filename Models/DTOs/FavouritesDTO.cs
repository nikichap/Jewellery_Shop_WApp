using Jewellery_Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.DTOs
{
    public class FavouritesDTO
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        //public int ItemId { get; set; }
        public string CreatedBy { get; set; }
        public string UserEmail { get; set; }

    }
}
