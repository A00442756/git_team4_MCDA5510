using HouseRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRentingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly HouseRentingSystemDBContext _context = null;

        public AdvertisementRepository(HouseRentingSystemDBContext context)
        {
            _context = context;
        }
        public async Task<List<AdvertisementModel>> GetStarListAdvertisementsByUserId(int UserID)
        {
            List<AdvertisementModel> adModelList = new List<AdvertisementModel>();
            var starList = _context.StarLists.Where(x => x.Userid == UserID).ToListAsync();
            List<int> adidList = new List<int>();
            foreach(var star in starList.Result)
            {
                adidList.Add(star.Adid);
            }
            var advertisements = await _context.Advertisements.Where(x => adidList.Contains(x.Adid) ).ToListAsync();
            if (advertisements?.Any() == true)
            {
                foreach (var advertisement in advertisements)
                {
                    var adg = _context.AdvertisementGallery.Where(x => x.AdvertisementAdid == advertisement.Adid).ToList();
                    adModelList.Add(new AdvertisementModel()
                    {
                        Adid = advertisement.Adid,
                        Userid = advertisement.Userid,
                        Rental = advertisement.Rental,
                        Ondisplay = advertisement.Ondisplay,
                        PostalCode = advertisement.PostalCode,
                        ContactPhoneNum = advertisement.ContactPhoneNum,
                        Title = advertisement.Title,
                        Description = advertisement.Description,
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
                        Postdate = advertisement.Postdate,
                        Gallery = adg != null ? adg.Select(g => new GalleryModel()
                        {
                            Id = g.Id,
                            URL = g.URL,
                            Name = g.Name
                        }).ToList() : null
                    });
                }
            }

            return adModelList;
        }

        public async Task<List<AdvertisementModel>> GetAdvertisementsByUserId(int UserID)
        {
            List<AdvertisementModel> adModelList = new List<AdvertisementModel>();
            var advertisements = await _context.Advertisements.Where(x => x.Userid == UserID).ToListAsync();
            if (advertisements?.Any() == true)
            {
                foreach (var advertisement in advertisements)
                {
                    var adg = _context.AdvertisementGallery.Where(x => x.AdvertisementAdid == advertisement.Adid)
                        .ToList();
                    adModelList.Add(new AdvertisementModel()
                    {
                        Adid = advertisement.Adid,
                        Userid = advertisement.Userid,
                        Rental = advertisement.Rental,
                        Ondisplay = advertisement.Ondisplay,
                        PostalCode = advertisement.PostalCode,
                        ContactPhoneNum = advertisement.ContactPhoneNum,
                        Title = advertisement.Title,
                        Description = advertisement.Description,
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
                        Postdate = advertisement.Postdate,
                        Gallery = adg != null ? adg.Select(g => new GalleryModel()
                        {
                            Id = g.Id,
                            URL = g.URL,
                            Name = g.Name
                        }).ToList() : null
                    });
                }
            }

            return adModelList;
        }

        public async Task<AdvertisementModel> GetAdvertisementByAdId(int AdId)
        {
            return await _context.Advertisements.Where(x => x.Adid == AdId)
                .Select(advertisement => new AdvertisementModel()
                {
                    Adid = advertisement.Adid,
                    Userid = advertisement.Userid,
                    Ondisplay = advertisement.Ondisplay,
                    PostalCode = advertisement.PostalCode,
                    ContactPhoneNum = advertisement.ContactPhoneNum,
                    Title = advertisement.Title,
                    Rental = advertisement.Rental,
                    Description = advertisement.Description,
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
                    Postdate = advertisement.Postdate,
                    Gallery = advertisement.AdvertisementGallery != null ? advertisement.AdvertisementGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        URL = g.URL,
                        Name = g.Name
                    }).ToList() : null
                }).FirstOrDefaultAsync();
        }

        public async Task<List<AdvertisementModel>> GetAllAdvertisementOndisplay()
        {
            var advertisements = new List<AdvertisementModel>();
            var allAdvertisements = await _context.Advertisements.Where(x=>x.Ondisplay==true).ToListAsync();
            if (allAdvertisements?.Any() == true)
            {
                foreach (var advertisement in allAdvertisements)
                {
                    var adg = _context.AdvertisementGallery.Where(x => x.AdvertisementAdid == advertisement.Adid)
                        .ToList();
                    advertisements.Add(new AdvertisementModel()
                    {
                        Adid = advertisement.Adid,
                        Userid = advertisement.Userid,
                        Ondisplay = advertisement.Ondisplay,
                        PostalCode = advertisement.PostalCode,
                        ContactPhoneNum = advertisement.ContactPhoneNum,
                        Title = advertisement.Title,
                        Rental = advertisement.Rental,
                        Description = advertisement.Description,
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
                        Postdate = advertisement.Postdate,
                        Gallery = adg != null ? adg.Select(g => new GalleryModel()
                        {
                            Id = g.Id,
                            URL = g.URL,
                            Name = g.Name
                        }).ToList() : null
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
                Rental = model.Rental,
                PostalCode = model.PostalCode,
                ContactPhoneNum = model.ContactPhoneNum,
                Title = model.Title,
                Description = model.Description,
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
            newAdvertisement.AdvertisementGallery = new List<AdvertisementGallery>();
            if (model.Gallery != null)
            {
                foreach (var file in model.Gallery)
                {
                    newAdvertisement.AdvertisementGallery.Add(new AdvertisementGallery()
                    {
                        URL = file.URL,
                        Name = file.Name
                    });
                }
            }


            await _context.Advertisements.AddAsync(newAdvertisement);
            await _context.SaveChangesAsync();

            return newAdvertisement.Adid;
        }

        public async Task<int> EditAdvertisement(AdvertisementModel model)
        {
            var newAdvertisement = new Advertisements()
            {
                Adid = model.Adid,
                Userid = model.Userid,
                Ondisplay = model.Ondisplay,
                Rental = model.Rental,
                PostalCode = model.PostalCode,
                ContactPhoneNum = model.ContactPhoneNum,
                Title = model.Title,
                Description = model.Description,
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
            _context.Update(newAdvertisement);
            await _context.SaveChangesAsync();
            return newAdvertisement.Adid;
        }
    }
}
