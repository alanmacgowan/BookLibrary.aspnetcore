using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services.Interfaces;

namespace BookLibrary.aspnetcore.Services.Implementations
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public AuthorService(string baseUrl) : base(baseUrl, "api/Authors/")
        {
        }
    }
}
