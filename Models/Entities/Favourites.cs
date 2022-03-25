using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.Entities
{
    public class Favourites
    {
        public int Id { get; set; }
        public string Item { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
