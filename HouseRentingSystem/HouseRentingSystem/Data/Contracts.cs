using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Data
{
    public partial class Contracts
    {
        [Key]
        public int Contractid { get; set; }
        public int CreditCardId { get; set; }
        public int Houseownerid { get; set; }
        public string HouseownerName { get; set; }
        public int Tenantid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Adid { get; set; }
        public bool? Deal { get; set; }
        public int Monthlyrent { get; set; }
    }
}
