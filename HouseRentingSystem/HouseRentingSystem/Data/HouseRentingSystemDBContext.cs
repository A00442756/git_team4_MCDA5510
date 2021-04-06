﻿using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Data
{
    public class HouseRentingSystemDBContext : DbContext
    {
        public HouseRentingSystemDBContext(DbContextOptions<HouseRentingSystemDBContext> options)
            : base(options)
        { 
        
        }
        public DbSet<Advertisements> Advertisements { get; set; }
        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<CreditCards> CreditCards { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<StarLists> StarLists { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<AdvertisementGallery> AdvertisementGallery { get; set; }
    }
}