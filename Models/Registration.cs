using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Registration : Entity
    {
        public string Number { get; set; } = "";

        public Vehicle? Vehicle { get; set; }
    }
}
