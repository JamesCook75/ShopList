using Microsoft.AspNetCore.Mvc.Rendering;
using ShopList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopList.ViewModels
{
    public class IndexViewModel
    {
        public string Name { get; set; }

        public List<SelectListItem> Stores { get; set; }

        public IndexViewModel() { }

        public IndexViewModel(IEnumerable<ItemStore> stores)
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
