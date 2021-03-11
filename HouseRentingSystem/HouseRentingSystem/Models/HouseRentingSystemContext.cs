using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Models
{
    public class HouseRentingSystemContext : DbContext
    {
        
        public HouseRentingSystemContext(DbContextOptions<HouseRentingSystemContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("");
        //}

        public DbSet<Models.User> Users { get; set; }

        public DbSet<Models.Advertisement> Advertisements { get; set; }
    }
}
