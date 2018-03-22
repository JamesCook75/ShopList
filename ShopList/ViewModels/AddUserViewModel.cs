using ShopList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        public string Username { get; set; }

        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[MinLength(6, ErrorMessage = "Minumum of 6 characters")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[CompareAttribute("Password", ErrorMessage = "Passwords don't match")]
        //[Display(Name = "Verify Password")]
        public string Verify { get; set; }

        //public AddUserViewModel(string username, string email, string password)
        //{
        //    User newUser = new User
        //    {
        //        Username = username,
        //        Email = email,
        //        Password = password
        //    };

        //}
    }
}
