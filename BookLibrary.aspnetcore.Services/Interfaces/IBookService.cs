using BookLibrary.aspnetcore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> Get(int id);
        Task<bool> Create(Book book);
        Task<bool> Update(Book book);
        Task<bool> Delete(int id);
    }
}
