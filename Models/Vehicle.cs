using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vehicle : Entity
    {
        public string Name { get; set; } = "";

        //public int RegistrationId { get; set; }
        public Registration? Registration { get; set; }
        public Engine? Engine {get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
    }
}
