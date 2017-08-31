using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookLibrary.aspnetcore.Domain;
using System.Net.Http;

namespace BookLibrary.aspnetcore.Services
{
    public class BookService : IBookService
    {
        string _baseUrl;

        public BookService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<bool> Create(Book book)
        {
            var result = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.PostAsJsonAsync("api/Books/", book);
                if (!response.IsSuccessStatusCode)
                {
                    result = true;
                }
            }
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.DeleteAsync("api/Books/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    result = true;
                }
            }
            return result;
        }

        public async Task<Book> Get(int id)
        {
            var book = new Book();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.GetAsync("api/Books/" + id);
                if (response.IsSuccessStatusCode)
                {
                    book = await response.Content.ReadAsAsync<Book>();
                }
            }
            return book;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var books = new List<Book>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.GetAsync("api/Books");
                if (response.IsSuccessStatusCode)
                {
                    books = await response.Content.ReadAsAsync<List<Book>>();
                }
            }
            return books;
        }

        public async Task<bool> Update(Book book)
        {
            var result = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.PutAsJsonAsync("api/Books/" + book.ID, book);
                if (!response.IsSuccessStatusCode)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
