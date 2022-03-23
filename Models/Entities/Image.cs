using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.Entities
{
    public class Image
    {
        public int ImageId { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
    }
}
