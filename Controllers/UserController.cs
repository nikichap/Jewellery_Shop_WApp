using Jewellery_Shop.Models.DTOs;
using Jewellery_Shop.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details()
        {
            User user = await userManager.GetUserAsync(User);

            UserDTO userDTO = new UserDTO();
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Username = user.UserName;
            userDTO.Email = user.Email;

            return View(userDTO);
        }
    }
}
