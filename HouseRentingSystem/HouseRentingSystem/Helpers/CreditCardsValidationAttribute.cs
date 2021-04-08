using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.Globalization;

namespace HouseRentingSystem.Helpers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CreditCardsValidationAttribute : ValidationAttribute
    {
/*        public CreditCardsValidationAttribute(string cardType) : base(SR.CompareAttribute_MustMatch)
        {
            CardType = cardType ?? throw new ArgumentNullException(nameof(cardType)); ;
        }
        public string CardType { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cardInfo = validationContext.ObjectType.GetRuntimeProperty(CardType);
            switch (cardInfo.ToString())
            {
                case "visa":
                    if (true)
                    {
                        //
                    }

                    ;
                    break;
                case "master":
                    if (true)
                    {
                        //
                    }

                    ;
                    break;
                default: 

                    break;
            }


            return new ValidationResult(ErrorMessage ?? "Credit Card# does not contain the desired value");
        }
    }

    //分界线
    public CompareAttribute(string otherProperty) : base(SR.CompareAttribute_MustMatch)
    {
        OtherProperty = otherProperty ?? throw new ArgumentNullException(nameof(otherProperty));
    }

    public string OtherProperty { get; }

    public string OtherPropertyDisplayName { get; internal set; }

    public override bool RequiresValidationContext => true;

    public override string FormatErrorMessage(string name) =>
        string.Format(
            CultureInfo.CurrentCulture, ErrorMessageString, name, OtherPropertyDisplayName ?? OtherProperty);

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);
        if (otherPropertyInfo == null)
        {
            return new ValidationResult(SR.Format(SR.CompareAttribute_UnknownProperty, OtherProperty));
        }
        if (otherPropertyInfo.GetIndexParameters().Any())
        {
            throw new ArgumentException(SR.Format(SR.Common_PropertyNotFound, validationContext.ObjectType.FullName, OtherProperty));
        }

        object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        if (!Equals(value, otherPropertyValue))
        {
            if (OtherPropertyDisplayName == null)
            {
                OtherPropertyDisplayName = GetDisplayNameForProperty(otherPropertyInfo);
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return null;
    }

    private string GetDisplayNameForProperty(PropertyInfo property)
    {
        var attributes = CustomAttributeExtensions.GetCustomAttributes(property, true);
        var display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
        if (display != null)
        {
            return display.GetName();
        }

        return OtherProperty;
    }*/
    }
}
