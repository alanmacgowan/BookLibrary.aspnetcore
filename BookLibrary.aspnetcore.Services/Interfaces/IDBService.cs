using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services.Interfaces
{
    public interface IDBService
    {
        Task<bool> InitDB();
    }
}
