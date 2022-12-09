using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class Registration
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Vehicle? Vehicle { get; set; }
    }
}
