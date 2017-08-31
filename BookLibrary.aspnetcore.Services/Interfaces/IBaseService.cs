using BookLibrary.aspnetcore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services.Interfaces
{
    public interface IBaseService<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Create(T book);
        Task<bool> Update(T book);
        Task<bool> Delete(int id);
    }
}
