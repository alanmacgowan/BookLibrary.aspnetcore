using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Infrastructure
{
    public static class MapperConfiguration
    {

        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Features.Author.MappingProfile>();
                cfg.AddProfile<Features.Book.MappingProfile>();
                cfg.AddProfile<Features.Publisher.MappingProfile>();
            });
        }

    }
}
