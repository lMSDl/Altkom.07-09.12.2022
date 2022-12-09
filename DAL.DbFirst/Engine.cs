using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class Engine
    {
        public Engine()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public int Power { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
