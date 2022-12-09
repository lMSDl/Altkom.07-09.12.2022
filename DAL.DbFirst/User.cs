using System;
using System.Collections.Generic;

namespace DAL.DbFirst
{
    public partial class User
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserType { get; set; } = null!;
    }
}
