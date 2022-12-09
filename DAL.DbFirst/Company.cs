using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CompanyType { get; set; } = null!;
        public int? NumberOfEmployees { get; set; }
    }
}
