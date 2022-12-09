using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public decimal Pesel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? FullName { get; set; }

        public virtual Educator? Educator { get; set; }
        public virtual Student? Student { get; set; }
    }
}
