using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.UI;
using BookLibrary.aspnetcore.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Controllers
{
    public class BooksController : BaseController
    {

        public BooksController(IMapper mapper, IConfiguration configuration) : base(mapper, configuration)
        {
        }

        // GET: Books
        public async Task<IActionResult> Index()
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

            return View(_mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books));
       }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

            return View(_mapper.Map<Book, BookViewModel>(book));
       }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var bookVM = new BookEditViewModel();
            bookVM.Authors = await GetAuthors();
            bookVM.Publishers = await GetPublishers();
            return View(bookVM);
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    var response = await client.PostAsJsonAsync("api/Books/", _mapper.Map<BookViewModel, Book>(bookVM));
                    if (!response.IsSuccessStatusCode)
                    {
                        View(bookVM);
                    }
                }

                return RedirectToAction(nameof(Index));
           }

            return View(bookVM);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

            var bookVM = _mapper.Map<Book, BookEditViewModel>(book);
            bookVM.Authors = await GetAuthors();
            bookVM.Publishers = await GetPublishers();
            return View(bookVM);
       }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookViewModel bookVM)
        {
            if (id != bookVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    var response = await client.PutAsJsonAsync("api/Books/" + id, _mapper.Map<BookViewModel, Book>(bookVM));
                    if (!response.IsSuccessStatusCode)
                    {
                        View(bookVM);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(bookVM);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

            return View(_mapper.Map<Book, BookViewModel>(book));
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.DeleteAsync("api/Books/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<List<AuthorViewModel>> GetAuthors()
        {
            var authors = new List<Author>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.GetAsync("api/Authors");
                if (response.IsSuccessStatusCode)
                {
                    authors = await response.Content.ReadAsAsync<List<Author>>();
                }
                return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorViewModel>>(authors).ToList();
            }
        }

        private async Task<List<PublisherViewModel>> GetPublishers()
        {
            var publishers = new List<Publisher>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.GetAsync("api/Publishers");
                if (response.IsSuccessStatusCode)
                {
                    publishers = await response.Content.ReadAsAsync<List<Publisher>>();
                }
                return _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherViewModel>>(publishers).ToList();
            }
        }

    }
}
