using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopList.Data;
using ShopList.Models;
using ShopList.ViewModels;

namespace ShopList.Controllers
{
    public class UserController : Controller
    {
        private readonly ShopListDbContext context;

        public UserController(ShopListDbContext dbcontext)
        {
            context = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //TODO change first to single, and make sure usernames are unigue
                User theUser = context.Users.First(u => u.Username == loginViewModel.Username);
                if (theUser.Password == loginViewModel.Password) { return Redirect("/Checklist/Index"); }
            }

            return View(loginViewModel);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Username = addUserViewModel.Username,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                return Redirect("/User/Login");
            }

            return View(addUserViewModel);
            
        }
    }
}