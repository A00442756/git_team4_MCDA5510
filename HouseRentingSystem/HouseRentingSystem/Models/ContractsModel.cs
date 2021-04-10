using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Models
{
    public partial class ContractsModel
    {
        [Key]
        public int Contractid { get; set; }
        public string HouseownerName { get; set; }
        public string TenantName { get; set; }
        public DateTime Startdate { get; set; }
        public int Adid { get; set; }
        public int Monthlyrent { get; set; }
    }
}
