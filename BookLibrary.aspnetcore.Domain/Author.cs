using System;
using System.Collections.Generic;

namespace BookLibrary.aspnetcore.Domain
{
    public enum Gender
    {
        Male, Female, Other
    }

    public class Author : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
