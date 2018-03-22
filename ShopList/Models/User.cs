using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Models
{
    public class User
    {
        public int UserId = 1;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Joined { get; set; }
        static private int nextId = 1;

        public User()
        {
            UserId = nextId;
            Joined = DateTime.Now;
            nextId++;
        }
    }

}
