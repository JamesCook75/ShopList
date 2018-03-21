using ShopList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class ViewChecklistViewModel
    {
        public Checklist Checklist { get; set; }
        public IList<ChecklistItem> Items { get; set; }
    }
}
