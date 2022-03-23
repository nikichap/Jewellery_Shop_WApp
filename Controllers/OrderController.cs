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
        private OrderService OrderService;
        private UserManager<User> userManager;

        public OrderController(OrderService OrderService, UserManager<User> userManager)
        {
            this.OrderService = OrderService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<OrderDTO> Orders = OrderService.GetAll();
            return View(Orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order Order)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            OrderService.Create(Order, user);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Order Order = OrderService.GetById(id);

            return View(Order);
        }
        public IActionResult Delete(int id)
        {
            Order Order = OrderService.GetById(id);
            return View(Order);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            OrderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
