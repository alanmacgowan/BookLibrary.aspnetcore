namespace BookLibrary.aspnetcore.UI.Features.Publisher
{
    using AutoMapper;
    using BookLibrary.aspnetcore.Domain;
    using BookLibrary.aspnetcore.UI.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Publisher, PublisherViewModel>().ReverseMap(); ;
        }

    }
}
