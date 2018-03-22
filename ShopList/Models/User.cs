using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
        //public DateTime Joined { get; set; }

        //public User()
        //{
        //    Joined = DateTime.Now;
        //}
    }

}
