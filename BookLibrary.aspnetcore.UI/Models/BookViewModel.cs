using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public decimal? Price { get; set; }
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
