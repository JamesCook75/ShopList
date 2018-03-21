using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Item> Items { get; set; }
    }
}
