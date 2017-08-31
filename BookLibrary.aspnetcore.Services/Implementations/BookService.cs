using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookLibrary.aspnetcore.Domain;
using System.Net.Http;
using BookLibrary.aspnetcore.Services.Implementations;
using BookLibrary.aspnetcore.Services.Interfaces;

namespace BookLibrary.aspnetcore.Services
{
    public class BookService : BaseService<Book>, IBookService
    {

        public BookService(string baseUrl) : base(baseUrl, "api/Books/")
        {
        }

    }
}
