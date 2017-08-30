using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Domain
{
    public enum Gender
    {
        Male, Female, Other
    }

    public class Author
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
