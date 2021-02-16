using ASP.NET_MVC_uppgift.Data;
using ASP.NET_MVC_uppgift.Models;
using ASP.NET_MVC_uppgift.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_MVC_uppgift.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Users = await _identityService.GetAllUsersWithRolesAsync();
            ViewBag.Roles = _identityService.GetAllRoles();

            return View();
        }

        public IActionResult Create()
        {
            //Hämtar tomt formulär
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            var user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            await _identityService.CreateNewUserAsync(user, model.Password);

            return RedirectToAction("Index");
        }
    }
}