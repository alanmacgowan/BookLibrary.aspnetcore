﻿using BookLibrary.aspnetcore.Services.Implementations;
using BookLibrary.aspnetcore.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace BookLibrary.aspnetcore.UI.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection collection, IConfiguration configuration)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            var baseUrl = configuration.GetValue<string>("AppSettings:BaseUrl");

            collection.AddTransient<IBookService, BookService>(s => new BookService(baseUrl));
            collection.AddTransient<IAuthorService, AuthorService>(s => new AuthorService(baseUrl));
            collection.AddTransient<IPublisherService, PublisherService>(s => new PublisherService(baseUrl));
            collection.AddTransient<IDBService, DBService>(s => new DBService(baseUrl));

            return collection;
        }


    }
}
