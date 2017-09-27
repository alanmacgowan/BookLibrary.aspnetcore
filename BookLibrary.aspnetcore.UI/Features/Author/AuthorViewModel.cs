using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.UI.Features.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.aspnetcore.UI.Features.Author
{
    public class AuthorViewModel
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }      
        [Required]
        [StringLength(70)]
        public string LastName { get; set; }
        [Required]
        [StringLength(70)]
        public string FirstName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<BookViewModel> Books { get; set; }
    }
}
