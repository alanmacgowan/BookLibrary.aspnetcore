using System.ComponentModel.DataAnnotations;

namespace BookLibrary.aspnetcore.UI.Features.Publisher
{
    public class PublisherViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
