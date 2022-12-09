using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
    }
}
