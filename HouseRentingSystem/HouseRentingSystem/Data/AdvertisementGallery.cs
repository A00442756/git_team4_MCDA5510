using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data
{
    public class AdvertisementGallery
    {
        public int Id { get; set; }
        public int AdvertisementAdid { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Advertisements Advertisement { get; set; }
    }
}
