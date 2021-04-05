using HouseRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRentingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Repository
{
    public class AdvertisementRepository
    {
        private readonly HouseRentingSystemDBContext _context = null;

        public AdvertisementRepository(HouseRentingSystemDBContext context)
        {
            _context = context;
        }

        public async Task<List<AdvertisementModel>> GetAdvertisementsByUserID(int UserID)
        {
            List<AdvertisementModel> adModelList = new List<AdvertisementModel>();
            var advertisements = await _context.Advertisements.Where(x => x.Userid == UserID).ToListAsync();
            if (advertisements?.Any()==true)
            {
                foreach (var advertisement in advertisements)
                {
                    adModelList.Add(new AdvertisementModel()
                    {
                        Userid = advertisement.Userid,
                        Ondisplay = advertisement.Ondisplay,
                        Title = advertisement.Title,
                        Country = advertisement.Country,
                        Province = advertisement.Province,
                        City = advertisement.City,
                        Streetname = advertisement.Streetname,
                        Streetnum = advertisement.Streetnum,
                        Bedroomsnum = advertisement.Bedroomsnum,
                        Bathroomsnum = advertisement.Bathroomsnum,
                        Hydro = advertisement.Hydro,
                        Heat = advertisement.Heat,
                        Water = advertisement.Water,
                        Internet = advertisement.Internet,
                        Parkingnum = advertisement.Parkingnum,
                        Agreementtype = advertisement.Agreementtype,
                        Moveindate = advertisement.Moveindate,
                        Petfriendly = advertisement.Petfriendly,
                        Size = advertisement.Size,
                        Furnished = advertisement.Furnished,
                        Laundry = advertisement.Laundry,
                        Dishwasher = advertisement.Dishwasher,
                        Fridge = advertisement.Fridge,
                        Airconditioning = advertisement.Airconditioning,
                        Smokingpermit = advertisement.Smokingpermit,
                        Postdate = advertisement.Postdate
                    });
                }
            }

            return adModelList;
        }

        public async Task<List<AdvertisementModel>> GetAllAdvertisement()
        {
            var advertisements = new List<AdvertisementModel>();
            var allAdvertisements = await _context.Advertisements.ToListAsync();
            if (allAdvertisements?.Any()==true)
            {
                foreach (var advertisement in allAdvertisements)
                {
                    advertisements.Add(new AdvertisementModel()
                    {
                        Userid = advertisement.Userid,
                        Ondisplay = advertisement.Ondisplay,
                        Title = advertisement.Title,
                        Country = advertisement.Country,
                        Province = advertisement.Province,
                        City = advertisement.City,
                        Streetname = advertisement.Streetname,
                        Streetnum = advertisement.Streetnum,
                        Bedroomsnum = advertisement.Bedroomsnum,
                        Bathroomsnum = advertisement.Bathroomsnum,
                        Hydro = advertisement.Hydro,
                        Heat = advertisement.Heat,
                        Water = advertisement.Water,
                        Internet = advertisement.Internet,
                        Parkingnum = advertisement.Parkingnum,
                        Agreementtype = advertisement.Agreementtype,
                        Moveindate = advertisement.Moveindate,
                        Petfriendly = advertisement.Petfriendly,
                        Size = advertisement.Size,
                        Furnished = advertisement.Furnished,
                        Laundry = advertisement.Laundry,
                        Dishwasher = advertisement.Dishwasher,
                        Fridge = advertisement.Fridge,
                        Airconditioning = advertisement.Airconditioning,
                        Smokingpermit = advertisement.Smokingpermit,
                        Postdate = advertisement.Postdate
                    });
                }
            }

            return advertisements;
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
