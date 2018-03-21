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
    public class StoreController : Controller
    {
        private readonly ShopListDbContext context;
        
        public StoreController(ShopListDbContext dBContext)
        {
            context = dBContext;
        }

        public IActionResult Index()
        {
            if (context.Stores.Count() == 0)
            {
                Store publix = new Store();
                Store walmart = new Store();
                Store homedepot = new Store();
                Store target = new Store();

                publix.Name = "Publix";
                context.Stores.Add(publix);
                walmart.Name = "Wal-Mart";
                context.Stores.Add(walmart);
                homedepot.Name = "Home Depot";
                context.Stores.Add(homedepot);
                target.Name = "Target";
                context.Stores.Add(target);
                context.SaveChanges();
            }

            List<Store> stores = context.Stores.ToList();

            return View(stores);
        }

        public IActionResult Add()
        {
            AddStoreViewModel addStoreViewModel = new AddStoreViewModel();
            return View(addStoreViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddStoreViewModel addStoreViewModel)
        {
            if (ModelState.IsValid)
            {
                Store newStore = new Store
                {
                    Name = addStoreViewModel.Name,

                };

                context.Stores.Add(newStore);
                context.SaveChanges();

                return Redirect("/Store");
            }

            return View(addStoreViewModel);
        }
    }
}