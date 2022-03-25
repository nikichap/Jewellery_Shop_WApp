using Jewellery_Shop.Models.DTOs;
using Jewellery_Shop.Models.Entities;
using Jewellery_Shop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Controllers
{
    public class OrderController : Controller
    {
        private OrderService orderService;
        private UserManager<User> userManager;

        public OrderController(OrderService orderService, UserManager<User> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }
    }
}
