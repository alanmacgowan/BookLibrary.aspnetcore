namespace BookLibrary.aspnetcore.UI.Features.Author
{
    using AutoMapper;
    using BookLibrary.aspnetcore.Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorViewModel>().ReverseMap();
        }

    }
}
