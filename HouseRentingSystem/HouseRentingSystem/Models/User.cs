using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmailAddress { get; set; }
        public String PhoneNumber { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}
