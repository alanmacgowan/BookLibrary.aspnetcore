namespace BookLibrary.aspnetcore.UI.Features.Author
{
    using AutoMapper;
    using BookLibrary.aspnetcore.Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorViewModel>()
                .ForMember(vm => vm.AuthorName, map => map.MapFrom(b => (b.LastName + ", " + b.FirstName)));
            CreateMap<AuthorViewModel, Author>();

        }

    }
}
