using BookLibrary.aspnetcore.UI.Features.Author;
using BookLibrary.aspnetcore.UI.Features.Publisher;
using System.Collections.Generic;

namespace BookLibrary.aspnetcore.UI.Features.Book
{
    public class BookEditViewModel : BookViewModel
    {
        public List<AuthorViewModel> Authors { get; set; }
        public List<PublisherViewModel> Publishers { get; set; }

    }
}
