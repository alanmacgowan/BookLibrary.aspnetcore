using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.UI.Features.Book;
using System;
using System.Collections.Generic;

namespace BookLibrary.aspnetcore.UI.Features.Author
{
    public class AuthorViewModel
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }      
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<BookViewModel> Books { get; set; }
    }
}
