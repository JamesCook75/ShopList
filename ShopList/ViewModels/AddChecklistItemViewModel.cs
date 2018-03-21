using Microsoft.AspNetCore.Mvc.Rendering;
using ShopList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class AddChecklistItemViewModel
    {
        [Display(Name = "Item")]
        public int ItemID { get; set; }
        public int ChecklistID { get; set; }

        public Checklist Checklist { get; set; }
        public List<SelectListItem> Items { get; set; }

        public AddChecklistItemViewModel() { }

        public AddChecklistItemViewModel(Checklist checklist, IEnumerable<Item> items)
        {
            Items = new List<SelectListItem>();
            Checklist = checklist;

            foreach (var item in items)
            {
                Items.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name
                });
            }
        }

    }
}
