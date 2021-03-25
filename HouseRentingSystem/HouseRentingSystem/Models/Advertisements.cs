using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    public partial class Advertisements
    {
        public int Adid { get; set; }
        public int Userid { get; set; }
        public bool Ondisplay { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Streetname { get; set; }
        public string Streetnum { get; set; }
        public int Bedroomsnum { get; set; }
        public int Bathroomsnum { get; set; }
        public bool Hydro { get; set; }
        public bool Heat { get; set; }
        public bool Water { get; set; }
        public bool Internet { get; set; }
        public int Parkingnum { get; set; }
        public string Agreementtype { get; set; }
        public DateTime Moveindate { get; set; }
        public bool Petfriendly { get; set; }
        public int Size { get; set; }
        public bool Furnished { get; set; }
        public bool Laundry { get; set; }
        public bool Dishwasher { get; set; }
        public bool Fridge { get; set; }
        public bool Airconditioning { get; set; }
        public bool Smokingpermit { get; set; }
    }
}
