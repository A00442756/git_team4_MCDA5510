using Microsoft.EntityFrameworkCore;
using HouseRentingSystem.Models;

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
        public DbSet<StarLists> StarLists { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<AdvertisementGallery> AdvertisementGallery { get; set; }
        public DbSet<HouseRentingSystem.Models.CreditCardModel> CreditCardModel { get; set; }
    }
}
