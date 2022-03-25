using Jewellery_Shop.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.DTOs
{
    public class OrderDTO : Controller
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime OrderedFor { get; set; }
        public decimal FullPrice { get; set; }
    }
}