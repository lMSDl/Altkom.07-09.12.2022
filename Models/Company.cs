using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[Table("Companies")]
    public class Company : Entity
    {
        public string Name { get; set; } = "";
        public Address? Address { get; set; }
    }
}
