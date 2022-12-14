using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Person : Entity
    {
        //[Column("Name")]
        public string FirstName { get; set; } = "";
        //[MaxLength(15)]
        [MinLength(10)]
        //[Required]
        public string? LastName { get; set; } = "Kowalski";

        public string FullName { get; }// => $"{FirstName} {LastName}";

        //public DateTime? BirthDate { get; set; }
        //[Column(TypeName = "decimal(11,0)")]
        public ulong PESEL { get; set; }


        //[NotMapped] //lokalne wyłączenie mapowania
        public Address? Address { get; set; }
    }
}