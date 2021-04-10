using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace HouseRentingSystem.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [RegularExpression(@"[^;:!@#$%^*+?\/<>1234567890]+", ErrorMessage = "First name must not include any of ; : ! @ # $ % ^ * + ? \\ / < > 1 2 3 4 5 6 7 8 9 0")]
        public string FirstName { get; set; }

        [RegularExpression(@"[^;:!@#$%^*+?\/<>1234567890]+", ErrorMessage = "Last name must not include any of ; : ! @ # $ % ^ * + ? \\ / < > 1 2 3 4 5 6 7 8 9 0")]
        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }

        [Key]
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

}
