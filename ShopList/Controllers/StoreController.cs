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


            List<ItemStore> stores = context.Stores.ToList();

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
                ItemStore newStore = new ItemStore
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