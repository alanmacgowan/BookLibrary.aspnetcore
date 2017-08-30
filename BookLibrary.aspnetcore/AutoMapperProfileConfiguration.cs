using AutoMapper;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<BookEditViewModel, Book>();
            CreateMap<BookViewModel, Book>();
            CreateMap<AuthorViewModel, Author>();
            CreateMap<PublisherViewModel, Publisher>();

            CreateMap<Book, BookEditViewModel>();
            CreateMap<Book, BookViewModel>()
                .ForMember(vm => vm.AuthorName, map => map.MapFrom(b => (b.Author.LastName + ", " + b.Author.FirstName)))
                .ForMember(vm => vm.PublisherName, map => map.MapFrom(b => b.Publisher.Name ));

            CreateMap<Author, AuthorViewModel>();
            CreateMap<Publisher, PublisherViewModel>();

        }
    }
}
