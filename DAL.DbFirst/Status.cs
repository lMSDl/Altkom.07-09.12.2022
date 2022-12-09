using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class Status
    {
        public Status()
        {
            SubComponents = new HashSet<SubComponent>();
        }

        public string Id { get; set; } = null!;

        public virtual ICollection<SubComponent> SubComponents { get; set; }
    }
}
