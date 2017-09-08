namespace BookLibrary.aspnetcore.UI.Features.Book
{
    using AutoMapper;
    using BookLibrary.aspnetcore.Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookEditViewModel>().ReverseMap();
            CreateMap<BookViewModel, Book>();
            CreateMap<Book, BookViewModel>()
                .ForMember(vm => vm.AuthorName, map => map.MapFrom(b => (b.Author.LastName + ", " + b.Author.FirstName)))
                .ForMember(vm => vm.PublisherName, map => map.MapFrom(b => b.Publisher.Name));
        }

    }
}
