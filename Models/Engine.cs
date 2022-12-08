using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Engine : Entity
    {
        public int Power { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
