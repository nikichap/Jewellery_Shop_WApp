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
    public class ItemController : Controller
    {
        private ItemService itemService;
        private UserManager<User> userManager;

        public ItemController(ItemService itemService, UserManager<User> userManager)
        {
            this.itemService = itemService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<ItemDTO> items = itemService.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            itemService.Create(item, user);

            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Edit(int id)
        {
            Item item = itemService.GetById(id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            itemService.Edit(item);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Item item = itemService.GetById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            itemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
