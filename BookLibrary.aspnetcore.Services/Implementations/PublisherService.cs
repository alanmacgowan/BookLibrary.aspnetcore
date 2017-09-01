using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services.Interfaces;

namespace BookLibrary.aspnetcore.Services.Implementations
{
    public class PublisherService : BaseService<Publisher>, IPublisherService
    {
        public PublisherService(string baseUrl) : base(baseUrl, "api/Publishers/")
        {
        }
    }
}
