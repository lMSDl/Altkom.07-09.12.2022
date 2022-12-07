using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[NotMapped] //globalne pominięcie mapowania
    public class Address
    {
        //wg konwencji Id lub NazwaEncjiId jest kluczem głównym
        public int AddressId { get; set; }
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string ZipCode { get; set; } = "";
    }
}
