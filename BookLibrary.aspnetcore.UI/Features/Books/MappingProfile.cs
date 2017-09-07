using AutoMapper;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.UI.Models;

namespace BookLibrary.aspnetcore.UI.Features.Books
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookEditViewModel, Book>();
            CreateMap<BookViewModel, Book>();

            CreateMap<Book, BookEditViewModel>();
            CreateMap<Book, BookViewModel>()
                .ForMember(vm => vm.AuthorName, map => map.MapFrom(b => (b.Author.LastName + ", " + b.Author.FirstName)))
                .ForMember(vm => vm.PublisherName, map => map.MapFrom(b => b.Publisher.Name));

            CreateMap<AuthorViewModel, Author>();
            CreateMap<PublisherViewModel, Publisher>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Publisher, PublisherViewModel>();
        }

    }
}
