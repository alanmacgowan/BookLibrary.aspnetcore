using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public decimal? Price { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public int? Pages { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
