using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    public partial class HouseRentingSystemDBContext : DbContext
    {
        public HouseRentingSystemDBContext()
        {
        }
        public IConfiguration Configuration { get; }

        public HouseRentingSystemDBContext(DbContextOptions<HouseRentingSystemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertisements> Advertisements { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<CreditCards> CreditCards { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<StarLists> StarLists { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //read connectionstring from configuration, which is appsetting.json
                //var defaultcon = Configuration.GetConnectionString("DefaultConnection");
                //optionsBuilder.UseSqlServer(defaultcon);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisements>(entity =>
            {
                entity.HasKey(e => new { e.Adid, e.Userid });

                entity.ToTable("advertisements");

                entity.Property(e => e.Adid).HasColumnName("adid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Agreementtype)
                    .IsRequired()
                    .HasColumnName("agreementtype")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Airconditioning).HasColumnName("airconditioning");

                entity.Property(e => e.Bathroomsnum).HasColumnName("bathroomsnum");

                entity.Property(e => e.Bedroomsnum).HasColumnName("bedroomsnum");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dishwasher).HasColumnName("dishwasher");

                entity.Property(e => e.Fridge).HasColumnName("fridge");

                entity.Property(e => e.Furnished).HasColumnName("furnished");

                entity.Property(e => e.Heat).HasColumnName("heat");

                entity.Property(e => e.Hydro).HasColumnName("hydro");

                entity.Property(e => e.Internet).HasColumnName("internet");

                entity.Property(e => e.Laundry).HasColumnName("laundry");

                entity.Property(e => e.Moveindate)
                    .HasColumnName("moveindate")
                    .HasColumnType("date");

                entity.Property(e => e.Ondisplay).HasColumnName("ondisplay");

                entity.Property(e => e.Parkingnum).HasColumnName("parkingnum");

                entity.Property(e => e.Petfriendly).HasColumnName("petfriendly");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Smokingpermit).HasColumnName("smokingpermit");

                entity.Property(e => e.Streetname)
                    .IsRequired()
                    .HasColumnName("streetname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Streetnum)
                    .IsRequired()
                    .HasColumnName("streetnum")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Water).HasColumnName("water");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.Contractid);

                entity.ToTable("contracts");

                entity.Property(e => e.Contractid)
                    .HasColumnName("contractid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adid).HasColumnName("adid");

                entity.Property(e => e.Deal).HasColumnName("deal");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Houseownerid).HasColumnName("houseownerid");

                entity.Property(e => e.Monthlyrent).HasColumnName("monthlyrent");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.Tenantid).HasColumnName("tenantid");
            });

            modelBuilder.Entity<CreditCards>(entity =>
            {
                entity.HasKey(e => new { e.Cid, e.Userid })
                    .HasName("PK_creditcards");

                entity.ToTable("credit_cards");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Cardnumber)
                    .IsRequired()
                    .HasColumnName("cardnumber")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cardtype)
                    .IsRequired()
                    .HasColumnName("cardtype")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Expiremonth)
                    .IsRequired()
                    .HasColumnName("expiremonth")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Expireyear)
                    .IsRequired()
                    .HasColumnName("expireyear")
                    .HasMaxLength(4)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("images");

                entity.Property(e => e.Adid).HasColumnName("adid");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasColumnName("img")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<StarLists>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Adid });

                entity.ToTable("star_lists");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Adid).HasColumnName("adid");

                entity.Property(e => e.Stardate)
                    .HasColumnName("stardate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Emailaddress)
                    .IsRequired()
                    .HasColumnName("emailaddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasColumnName("phonenumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
