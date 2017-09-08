namespace BookLibrary.aspnetcore.UI.Features.Publisher
{
    using AutoMapper;
    using BookLibrary.aspnetcore.Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Publisher, PublisherViewModel>().ReverseMap();
        }

    }
}
