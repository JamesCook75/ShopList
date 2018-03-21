using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ID { get; set; }
        public ItemStore Store { get; set; }
        public int StoreID { get; set; }
        public IList<ChecklistItem> ChecklistItem { get; set; }

    }
}
