using BookLibrary.aspnetcore.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services.Implementations
{
    public class DBService : IDBService
    {
        private string _baseUrl;

        public DBService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<bool> InitDB()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.GetAsync("api/db/");
                return response.IsSuccessStatusCode;
            }
        }
    }
}
