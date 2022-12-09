using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Drivers = new HashSet<Driver>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? RegistrationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? EngineId { get; set; }

        public virtual Engine? Engine { get; set; }
        public virtual Registration? Registration { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
