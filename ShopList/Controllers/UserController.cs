using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopList.Models;
using ShopList.ViewModels;

namespace ShopList.Controllers
{
    public class UserController : Controller
    {
        private 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(User newUser)
        {
            return View()
        }
    }
}