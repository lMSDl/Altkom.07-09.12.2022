﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Components
{
    public class Component
    {
        public int Id { get; set; }
        public IEnumerable<SubComponent> SubComponents { get; set; }
    }
}
