using HouseRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRentingSystem.Models;

namespace HouseRentingSystem.Repository
{
    public class AdvertisementRepository
    {
        private readonly HouseRentingSystemDBContext _context = null;

        public AdvertisementRepository(HouseRentingSystemDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAdvertisement(AdvertisementModel model)
        {
            var newAdvertisement = new Advertisements()
            {
                Userid = model.Userid,
                Ondisplay = true,
                Title = model.Title,
                Country = model.Country,
                Province = model.Province,
                City = model.City,
                Streetname = model.Streetname,
                Streetnum = model.Streetnum,
                Bedroomsnum = model.Bedroomsnum,
                Bathroomsnum = model.Bathroomsnum,
                Hydro = model.Hydro,
                Heat = model.Heat,
                Water = model.Water,
                Internet = model.Internet,
                Parkingnum = model.Parkingnum,
                Agreementtype = model.Agreementtype,
                Moveindate = model.Moveindate,
                Petfriendly = model.Petfriendly,
                Size = model.Size,
                Furnished = model.Furnished,
                Laundry = model.Laundry,
                Dishwasher = model.Dishwasher,
                Fridge = model.Fridge,
                Airconditioning = model.Airconditioning,
                Smokingpermit = model.Smokingpermit,
                Postdate = DateTime.UtcNow
            };

            await _context.Advertisements.AddAsync(newAdvertisement);
            await _context.SaveChangesAsync();

            return newAdvertisement.Adid;
        }
    }
}
