using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Models
{
    public class ChecklistItem
    {
        public int ChecklistID { get; set; }
        public Checklist Checklist { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}
