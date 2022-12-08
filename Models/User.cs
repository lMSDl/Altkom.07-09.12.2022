using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        //[Key]
        public string Username { get; set; } = "";
        public string Password {get; set;} = "";

        public UserType UserType { get; set; }



        public static IEnumerable<User> DEFAULT_USERS => new List<User>
        {
                new User { UserType = UserType.Admin, Username = "SuperAdmin", Password = "nimdA" },
                new User { UserType = UserType.User, Username = "User", Password = "resU" }
        };
    }
}
