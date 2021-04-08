using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using FluentValidation.AspNetCore;
using FluentValidation;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    /// <summary>
    /// Provides conditional validation based on related property value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class RequiredIfAttribute : ValidationAttribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the other property name that will be used during validation.
        /// </summary>
        /// <value>
        /// The other property name.
        /// </value>
        public string OtherProperty { get; private set; }

        /// <summary>
        /// Gets or sets the display name of the other property.
        /// </summary>
        /// <value>
        /// The display name of the other property.
        /// </value>
        public string OtherPropertyDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the other property value that will be relevant for validation.
        /// </summary>
        /// <value>
        /// The other property value.
        /// </value>
        public object OtherPropertyValue { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether other property's value should match or differ from provided other property's value (default is <c>false</c>).
        /// </summary>
        /// <value>
        ///   <c>true</c> if other property's value validation should be inverted; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// How this works
        /// - true: validated property is required when other property doesn't equal provided value
        /// - false: validated property is required when other property matches provided value
        /// </remarks>
        public bool IsInverted { get; set; }

        /// <summary>
        /// Gets a value that indicates whether the attribute requires validation context.
        /// </summary>
        /// <returns><c>true</c> if the attribute requires validation context; otherwise, <c>false</c>.</returns>
        public override bool RequiresValidationContext => true;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredIfAttribute"/> class.
        /// </summary>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="otherPropertyValue">The other property value.</param>
        public RequiredIfAttribute(string otherProperty, object otherPropertyValue)
            : base("'{0}' is required because '{1}' has a value {3}'{2}'.")
        {
            this.OtherProperty = otherProperty;
            this.OtherPropertyValue = otherPropertyValue;
            this.IsInverted = false;
        }

        #endregion

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>
        /// An instance of the formatted error message.
        /// </returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                base.ErrorMessageString,
                name,
                this.OtherPropertyDisplayName ?? this.OtherProperty,
                this.OtherPropertyValue,
                this.IsInverted ? "other than " : "of ");
        }

        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            PropertyInfo otherProperty = validationContext.ObjectType.GetProperty(this.OtherProperty);
            if (otherProperty == null)
            {
                return new ValidationResult(
                    string.Format(CultureInfo.CurrentCulture, "Could not find a property named '{0}'.", this.OtherProperty));
            }

            object otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

            // check if this value is actually required and validate it
            if ((this.IsInverted || !object.Equals(otherValue, this.OtherPropertyValue)) &&
                (!this.IsInverted || object.Equals(otherValue, this.OtherPropertyValue)))
                return ValidationResult.Success;
            if (value == null)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            // additional check for strings so they're not empty
            string val = value as string;
            if (val != null && val.Trim().Length == 0)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
    public partial class CreditCardModel
    {
        [Key]
        public int Cid { get; set; }
        public int Userid { get; set; }
        [Required(ErrorMessage = "Please enter the credit card number")]
        public string Cardnumber { get; set; }
        public string Cardtype { get; set; }
        [Required(ErrorMessage = "Please enter the expiry year on the credit card")]
        public string Expireyear { get; set; }
        [Required(ErrorMessage = "Please enter the expiry month on the credit card")]
        public string Expiremonth { get; set; }
        [Required(ErrorMessage = "Please enter the name on the credit card")]
        public string CardHolderName { get; set; }
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

