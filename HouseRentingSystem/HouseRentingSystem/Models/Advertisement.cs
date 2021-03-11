using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentingSystem.Models
{
    public class Advertisement
    {
        [Required,Key]
        public int AdId { get; set; }
        public String Title { get; set; }
        
        public String Description { get; set; }
        public String StreetName { get; set; }
        public String StreetNumber { get; set; }
    }
}
