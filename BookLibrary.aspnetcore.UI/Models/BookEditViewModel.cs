using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Models
{
    public class BookEditViewModel : BookViewModel
    {
        public List<AuthorViewModel> Authors { get; set; }
        public List<PublisherViewModel> Publishers { get; set; }

    }
}
