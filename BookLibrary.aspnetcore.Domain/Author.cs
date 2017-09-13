using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.aspnetcore.Domain
{
    public enum Gender
    {
        Male, Female, Other
    }

    public class Author : BaseEntity
    {
        [Required]
        [StringLength(70)]
        public string LastName { get; set; }
        [Required]
        [StringLength(70)]
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
