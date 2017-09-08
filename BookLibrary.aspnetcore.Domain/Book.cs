using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.aspnetcore.Domain
{
    public class Book : BaseEntity
    {
        [Required]
        [StringLength(70)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        [DataType(DataType.Currency)]
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
