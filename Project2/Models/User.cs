using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    public class User
    {
        public int Id { get; set; }      // Unique number for each user
        public string Name { get; set; } // User's name
        public string Email { get; set; } // User's email
        public string Password { get; set; } // User's password
    }

}