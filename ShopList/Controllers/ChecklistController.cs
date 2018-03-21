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
    public class ChecklistController : Controller
    {
        private readonly ShopListDbContext context;

        public ChecklistController(ShopListDbContext dbcontext)
        {
            context = dbcontext;
        }

        public IActionResult Index()
        {
            List<Checklist> checklists = context.Checklists.ToList();
            return View(checklists);
        }

        public IActionResult Add()
        {
            AddChecklistViewModel addChecklistViewModel = new AddChecklistViewModel();
            return View(addChecklistViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddChecklistViewModel addChecklistViewModel)
        {
            if (ModelState.IsValid)
            {
                Checklist newChecklist = new Checklist { Name = addChecklistViewModel.Name };
                context.Checklists.Add(newChecklist);
                context.SaveChanges();
                return Redirect("/Checklist/ViewChecklist/" + newChecklist.ID);
                
            }
            return View(addChecklistViewModel);
        }

        public IActionResult Remove()
        {
            return View();
        }

        public IActionResult ViewCheckList(int id)
        {
            List<ChecklistItem> items = context.ChecklistItems.Include(i => i.Item.Store).Where(c => c.ChecklistID == id).ToList();

            Checklist checklist = context.Checklists.Single(c => c.ID == id);

            ViewChecklistViewModel viewChecklistViewModel = new ViewChecklistViewModel
            {
                Checklist = checklist,
                Items = items
            };

            return View(viewChecklistViewModel);
        }

        public IActionResult AddItem(int id)
        {
            Checklist checklist = context.Checklists.Single(c => c.ID == id);
            IList<Item> items = context.Items.Include(i => i.Store).ToList(); 
            AddChecklistItemViewModel addChecklistItemViewModel = new AddChecklistItemViewModel(checklist, items);
            return View(addChecklistItemViewModel);
        }

        [HttpPost]
        public IActionResult AddItem(AddChecklistItemViewModel addChecklistItemViewModel)
        {
            if (ModelState.IsValid)
            {
                IList<ChecklistItem> existingItems = context.ChecklistItems
                    .Where(ci => ci.ItemID == addChecklistItemViewModel.ItemID)
                    .Where(ci => ci.ChecklistID == addChecklistItemViewModel.ChecklistID).ToList();

                if (existingItems.Count == 0)
                {
                    ChecklistItem checklistItem = new ChecklistItem
                    {
                        Checklist = context.Checklists.Single(cl => cl.ID == addChecklistItemViewModel.ChecklistID),
                        Item = context.Items.Single(i => i.ID == addChecklistItemViewModel.ItemID)
                    };
                    context.ChecklistItems.Add(checklistItem);
                    context.SaveChanges();
                }

                return Redirect("/Checklist/ViewChecklist/" + addChecklistItemViewModel.ChecklistID);
            }
            return View();
        }

        public IActionResult RemoveItem(int checklistId, int itemId)
        {
            ChecklistItem checklistItem = context.ChecklistItems.Single(cl => cl.ItemID == itemId && cl.ChecklistID == checklistId);
            context.ChecklistItems.Remove(checklistItem);
            

            context.SaveChanges();
            

            return Redirect("/Checklist/ViewChecklist/" + checklistId);

        }



        
    }
}