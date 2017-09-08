using BookLibrary.aspnetcore.Services.Interfaces;
using System;
using System.Net.Http;

namespace BookLibrary.aspnetcore.Services.Implementations
{
    public class DBService : IDBService
    {
        private string _baseUrl;

        public DBService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public void InitDB()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = client.GetAsync("api/db/");
            }
        }
    }
}
