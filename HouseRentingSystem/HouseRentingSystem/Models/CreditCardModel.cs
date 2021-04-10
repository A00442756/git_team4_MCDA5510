using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    
    public partial class CreditCardModel
    {
        [Key]
        public int Cid { get; set; }
        public int Userid { get; set; }
        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Please enter the credit card number")]
        public string Cardnumber { get; set; }
        [Display(Name = "Card Type")]
        public string Cardtype { get; set; }
        [Display(Name = "Expiry Year")]
        [Required(ErrorMessage = "Please enter the expiry year on the credit card")]
        public string Expireyear { get; set; }
        [Display(Name = "Expiry Month")]
        [Required(ErrorMessage = "Please enter the expiry month on the credit card")]
        public string Expiremonth { get; set; }
        [Display(Name = "Name on Credit Card")]
        [Required(ErrorMessage = "Please enter the name on the credit card")]
        public string CardHolderName { get; set; }
        public int adid { get; set; }
    }

    public class CreditCardValidator : AbstractValidator<CreditCardModel>
    {
        public CreditCardValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Cardnumber)
                .Matches(@"^5[1|2|3|4|5]").WithMessage("MasterCard card number must begin with 51 to 55")
                .Length(16).WithMessage("MasterCard card number must be 16 digits")
                .When(x => x.Cardtype == "MasterCard");
            RuleFor(x => x.Cardnumber)
                .Matches(@"^4").WithMessage("Visa card number must begin with 4")
                .Length(16).WithMessage("Visa card number must be 16 digits")
                .When(x => x.Cardtype == "Visa");
            RuleFor(x => x.Cardnumber)
                .Matches(@"^[34|37]").WithMessage("American Express card number must begin with 34 or 37")
                .Length(15).WithMessage("American Express card number must be 15 digits")
                .When(x => x.Cardtype == "American Express");
            RuleFor(x => x.Cardnumber)
                .Matches(@"[0-9]{1,}").WithMessage("Credit card number must consist of only digits");
            RuleFor(x => x.CardHolderName)
                .Matches(@"^[^(;|:|!|@|#|$|%|^|*|+|?|\|/|<|>|1|2|3|4|5|6|7|8|9|0)]{1,}")
                .WithMessage("Card holder name must not include any of ; : ! @ # $ % ^ * + ? \\ / < > 1 2 3 4 5 6 7 8 9 0");
            RuleFor(x => x.Expireyear).NotEqual("Select year").WithMessage("Please select card expiry year");
            RuleFor(x => x.Expiremonth).NotEqual("Select month").WithMessage("Please select card expiry month");
            RuleFor(x => x.Cardtype).NotEqual("Select card type").WithMessage("Please select a card type");
        }
    }
}

