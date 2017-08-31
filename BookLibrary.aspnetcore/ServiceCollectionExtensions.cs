using BookLibrary.aspnetcore.Services;
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

            collection.AddTransient<IBookService, BookService>(s => new BookService(config.GetValue<string>("AppSettings:BaseUrl")));

            return collection;
        }
    }
}
