using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using FluentValidation;
using Microsoft.AspNetCore.Http;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    public class AdvertisementModel
    {
        [Key] public int Adid { get; set; }
        public int Userid { get; set; }
        public bool Ondisplay { get; set; }

        [Display(Name = "Ad title")]
        //[StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your advertisement")]
        public string Title { get; set; }
        [Display(Name = "Postal code")]
        [Required]
        public string PostalCode { get; set; }
        [Display(Name = "Contact phone number")]
        [Required]
        public string ContactPhoneNum { get; set; }
        [Display(Name = "Price (CAD)")]
        [Required]
        public int Rental { get; set; }
        [Display(Name = "Write some description about your house/apartment")]
        [Required]
        public string Description { get; set; }

        [Required] public string Country { get; set; }
        [Display(Name = "Province / State")]
        [Required] 
        public string Province { get; set; }
        [Required] public string City { get; set; }

        [Display(Name = "Street name")]
        [Required]
        public string Streetname { get; set; }

        [Display(Name = "Street number")]
        [Required]
        public string Streetnum { get; set; }

        [Display(Name = "Number of bedrooms")]
        [Required]
        public int Bedroomsnum { get; set; }

        [Display(Name = "Number of bathrooms")]
        [Required]
        public int Bathroomsnum { get; set; }

        [Display(Name = "Select if the house/apartment provides hydro")]
        [Required]
        public bool Hydro { get; set; }

        [Display(Name = "Heater")]
        [Required]
        public bool Heat { get; set; }

        [Display(Name = "Water")]
        [Required]
        public bool Water { get; set; }

        [Display(Name = "Internet")]
        [Required]
        public bool Internet { get; set; }

        [Display(Name = "Number of parking spaces")]
        [Required]
        public int Parkingnum { get; set; }

        [Display(Name = "Agreement type")]
        [Required]
        public string Agreementtype { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Move-in date")]
        [Required] public DateTime Moveindate { get; set; }

        [Display(Name = "Pet friendly")]
        [Required]
        public bool Petfriendly { get; set; }
        [Display(Name = "House/Apartment size (sq ft)")]
        [Required] 
        public int Size { get; set; }
        public bool Furnished { get; set; }

        [Display(Name = "Laundry")]
        [Required]
        public bool Laundry { get; set; }

        [Display(Name = "Dishwasher")]
        [Required]
        public bool Dishwasher { get; set; }

        [Display(Name = "Refrigerator")]
        [Required]
        public bool Fridge { get; set; }

        [Display(Name = "Air conditioning")]
        [Required]
        public bool Airconditioning { get; set; }

        [Display(Name = "Smoking permitted")]
        [Required]
        public bool Smokingpermit { get; set; }
        
        public DateTime Postdate { get; set; }

        [Display(Name = "Choose the gallery images of the house/apartment")]
        //[Required(ErrorMessage = "Please upload at least one picture")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }
    }

    public class PostAdValidator : AbstractValidator<AdvertisementModel>
    {
        public PostAdValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Title)
                .MinimumLength(5).WithMessage("Title must be more than 5 characters")
                .MaximumLength(100).WithMessage("Title must not be more than 100 characters");

            RuleFor(x => x.Description)
                .MinimumLength(10).WithMessage("Description must be 10 or more characters");
            
            RuleFor(x => x.PostalCode)
                .Matches(@"(?i)^[ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ] ?\d[ABCEGHJKLMNPRSTVWXYZ]\d$").WithMessage("Enter a valid Canadian postal code")
                .When(x => x.Country == "Canada");
            
            RuleFor(x => x.PostalCode)
                .Matches(@"(^\d{5}$)|(^\d{5}-\d{4}$)").WithMessage("Enter a valid American postal code")
                .When(x => x.Country == "USA");

            RuleFor(x => x.ContactPhoneNum)
                .Matches(@"^\([2-9][\d]{2}\) [\d]{3}-[\d]{4}$").WithMessage("Enter a valid US/Canada phone number that follows the format (902) 123-1234");
            
            RuleFor(x => x.Province)
                .Matches(@"^[^(;|:|!|@|#|$|%|^|*|+|?|\|/|<|>|1|2|3|4|5|6|7|8|9|0)]{1,}")
                .WithMessage("Province must not include any of ; : ! @ # $ % ^ * + ? \\ / < > 1 2 3 4 5 6 7 8 9 0");

            RuleFor(x => x.City)
                .Matches(@"^[^(;|:|!|@|#|$|%|^|*|+|?|\|/|<|>|1|2|3|4|5|6|7|8|9|0)]{1,}")
                .WithMessage("City must not include any of ; : ! @ # $ % ^ * + ? \\ / < > 1 2 3 4 5 6 7 8 9 0");
            
            RuleFor(x => x.Moveindate)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Please enter a date today or greater");
            
            //RuleFor(x => x.Gallery)
            //    .NotEmpty().WithMessage("Please upload at least one picture");
        }
    }
}