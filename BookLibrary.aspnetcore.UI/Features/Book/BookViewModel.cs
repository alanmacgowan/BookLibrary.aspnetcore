using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.aspnetcore.UI.Features.Book
{
    public class BookViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public string Language { get; set; }
        public string Price { get; set; } = "0";
        public string ISBN { get; set; }
        public string Category { get; set; }
        public int? Pages { get; set; }
        public int PublisherID { get; set; }
        [Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }
        public int AuthorID { get; set; }
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
    }
}
