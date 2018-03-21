using Microsoft.AspNetCore.Mvc.Rendering;
using ShopList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class AddItemViewModel
    {
        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        [Required]
        [Display(Name = "Store")]
        public int StoreID { get; set; }

        public List<SelectListItem> Stores { get; set; }

        public AddItemViewModel() { }

        public AddItemViewModel(IEnumerable<ItemStore> stores)
        {
            Stores = new List<SelectListItem>();

            foreach (ItemStore store in stores)
            {
                Stores.Add(new SelectListItem
                {
                    Value = (store.ID).ToString(),
                    Text = store.Name
                });
            }
        }


    }
}
