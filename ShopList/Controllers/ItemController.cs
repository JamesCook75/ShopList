using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopList.Data;
using ShopList.Models;
using ShopList.ViewModels;

namespace ShopList.Controllers 
{
    public class ItemController : Controller
    {
        private ShopListDbContext context;

        public ItemController(ShopListDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Item> items = context.Items.Include(i => i.Store).ToList();
            ViewBag.title = "All Items";
            return View(items);
        }

        public IActionResult Add()
        {
            AddItemViewModel addItemViewModel = new AddItemViewModel(context.Stores.ToList());
            return View(addItemViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddItemViewModel addItemViewModel)
        {
            if (ModelState.IsValid)
            {
                ItemStore newStore = context.Stores.Single(s => s.ID == addItemViewModel.StoreID);

                Item newItem = new Item
                {
                    Name = addItemViewModel.Name,
                    Description = addItemViewModel.Description,
                    Price = addItemViewModel.Price,
                    Store = newStore
                };

                context.Items.Add(newItem);
                context.SaveChanges();

                return Redirect("/Item");
            }

            return View(addItemViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Items";
            ViewBag.items = context.Items.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] itemIds)
        {
            foreach (int itemId in itemIds)
            {
                Item theItem = context.Items.Single(i => i.ID == itemId);
                context.Items.Remove(theItem);
            }

            context.SaveChanges();

            return Redirect("/Item");
        }

        public IActionResult Store(int id)
        {
            if (id == 0) { return Redirect("/Store"); }

            ItemStore theStore = context.Stores.Include(s => s.Items).Single(s => s.ID == id);

            ViewBag.title = "Items at " + theStore.Name;
            return View("Index", theStore.Items);
        }
    }
}