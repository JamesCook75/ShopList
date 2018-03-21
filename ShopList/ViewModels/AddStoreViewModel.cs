using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class AddStoreViewModel
    {
        [Required]
        [Display(Name = "Store Name")]
        public string Name { get; set; }
    }
}
