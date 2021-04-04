using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HouseRentingSystem.Data
{
    public partial class Images
    {
        [Key]
        public int Imgid { get; set; }
        public byte[] Img { get; set; }
        public int Adid { get; set; }
    }
}
