using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
    }
}
