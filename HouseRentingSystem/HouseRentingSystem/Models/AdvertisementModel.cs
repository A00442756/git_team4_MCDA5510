using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Http;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    public class AdvertisementModel
    {
        [Key]
        public int Adid { get; set; }
        public int Userid { get; set; }
        public bool Ondisplay { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your advertisement")]
        public string Title { get; set; }
        public string PostalCode { get; set; }
        public string ContactPhoneNum { get; set; }
        public int Rental { get; set; }
        [Display(Name = "write some description about your house/apartment")]
        [Required]
        public string Description { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Streetname { get; set; }
        public string Streetnum { get; set; }
        public int Bedroomsnum { get; set; }
        public int Bathroomsnum { get; set; }
        [Display(Name = "Choose if your house/apartment provide hydro ")]
        [Required]
        public bool Hydro { get; set; }
        [Display(Name = "Choose if your house/apartment provide heat ")]
        [Required]
        public bool Heat { get; set; }
        [Display(Name = "Choose if your house/apartment provide water ")]
        [Required]
        public bool Water { get; set; }
        [Display(Name = "Choose if your house/apartment provide Internet ")]
        [Required]
        public bool Internet { get; set; }
        public int Parkingnum { get; set; }
        public string Agreementtype { get; set; }
        public DateTime Moveindate { get; set; }
        [Display(Name = "Choose if your house/apartment permits pets")]
        [Required]
        public bool Petfriendly { get; set; }
        public int Size { get; set; }
        public bool Furnished { get; set; }
        [Display(Name = "Choose if your house/apartment provide laundry ")]
        [Required]
        public bool Laundry { get; set; }
        [Display(Name = "Choose if your house/apartment provide dishwasher ")]
        [Required]
        public bool Dishwasher { get; set; }
        [Display(Name = "Choose if your house/apartment provide fridge ")]
        [Required]
        public bool Fridge { get; set; }
        [Display(Name = "Choose if your house/apartment provide air-condition ")]
        [Required]
        public bool Airconditioning { get; set; }
        [Display(Name = "Choose if your house/apartment permits smoking")]
        [Required]
        public bool Smokingpermit { get; set; }
        public DateTime Postdate { get; set; }

        [Display(Name = "Choose the gallery images of your house/apartment")]
        //[Required]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }
    }
}
