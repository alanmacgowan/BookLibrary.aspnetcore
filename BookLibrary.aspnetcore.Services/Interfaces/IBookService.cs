using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services
{
    public interface IBookService : IBaseService<Book>
    {

    }
}
