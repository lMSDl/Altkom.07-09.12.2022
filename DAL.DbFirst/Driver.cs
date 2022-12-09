using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class Driver
    {
        public Driver()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
