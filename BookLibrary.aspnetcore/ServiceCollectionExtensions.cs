using BookLibrary.aspnetcore.Services.Implementations;
using BookLibrary.aspnetcore.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookLibrary.aspnetcore.UI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection collection, IConfiguration config)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (config == null) throw new ArgumentNullException(nameof(config));

            var baseUrl = config.GetValue<string>("AppSettings:BaseUrl");

            collection.AddTransient<IBookService, BookService>(s => new BookService(baseUrl));
            collection.AddTransient<IAuthorService, AuthorService>(s => new AuthorService(baseUrl));
            collection.AddTransient<IPublisherService, PublisherService>(s => new PublisherService(baseUrl));

            return collection;
        }
    }
}
