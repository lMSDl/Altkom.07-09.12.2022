using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class SubComponent
    {
        public int Id { get; set; }
        public string StatusId { get; set; } = null!;
        public int ComponentId { get; set; }

        public virtual Component Component { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
    }
}
