using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    public partial class Users
    {
        public int Userid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phonenumber { get; set; }
        public string Emailaddress { get; set; }
        public string Password { get; set; }
    }
}
