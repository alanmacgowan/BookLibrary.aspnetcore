using BookLibrary.aspnetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Models
{
    public class AuthorViewModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<BookViewModel> Books { get; set; }
    }
}
