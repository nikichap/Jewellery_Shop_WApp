using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewellery_Shop.Models.DTOs;
using Jewellery_Shop.Models.Entities;
using Jewellery_Shop.Services;
using Microsoft.AspNetCore.Identity;

namespace Jewellery_Shop.Controllers
{
    public class FavouritesController : Controller
    {
        private FavouritesService favouritesService;
        private UserManager<User> userManager;

        public FavouritesController(FavouritesService favouritesService, UserManager<User> userManager) {
            this.userManager = userManager;
            this.favouritesService = favouritesService;
        }

        public IActionResult Index()
        {
            List<FavouritesDTO> favourites = favouritesService.GetAll();
            return View(favourites);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Favourites favourites)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            favouritesService.Create(favourites, user);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Favourites favourites = favouritesService.GetById(id);

            return View(favourites);
        }

        [HttpPost]
        public IActionResult Edit(Favourites favourites) {
            favouritesService.Edit(favourites);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Favourites favourites = favouritesService.GetById(id);

            return View(favourites);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            favouritesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
