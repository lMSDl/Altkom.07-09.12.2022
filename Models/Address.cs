using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[NotMapped] //globalne pominięcie mapowania
    //[Index(nameof(ZipCode), Name = "Index_ZipCode" )]
    //[Index(nameof(Street), nameof(City), IsUnique = true)]
    public class Address
    {
        //wg konwencji Id lub NazwaEncjiId jest kluczem głównym
        public int AddressId { get; set; }
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string ZipCode { get; set; } = "";
    }
}
