using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    public partial class StarListModel
    {
        public int Userid { get; set; }
        public int Adid { get; set; }
        public DateTime Stardate { get; set; }
    }
}
