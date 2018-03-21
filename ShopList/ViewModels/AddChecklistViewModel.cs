using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class AddChecklistViewModel
    {
        [Required]
        [Display(Name = "Shopping List")]
        public string Name { get; set; }
    }
}
