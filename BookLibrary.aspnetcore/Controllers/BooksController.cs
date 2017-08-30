using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Controllers
{
    public class BooksController : Controller
    {
        string Baseurl = "http://localhost:5000/";

        private readonly IMapper _mapper;
        public BooksController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = new List<Book>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = await client.GetAsync("api/Books");
                if (response.IsSuccessStatusCode)
                {
                    books = await response.Content.ReadAsAsync<List<Book>>();
                }
                return View(_mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books));
            }
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
                client.BaseAddress = new Uri(Baseurl);

                var response = await client.GetAsync("api/Books/" + id);
                if (response.IsSuccessStatusCode)
                {
                    book = await response.Content.ReadAsAsync<Book>();
                }
                return View(_mapper.Map<Book, BookViewModel>(book));
            }
        }

        //// GET: Books/Create
        public IActionResult Create()
        {
            //ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "ID");
            //ViewData["PublisherID"] = new SelectList(_context.Publishers, "ID", "ID");
            return View();
        }

        //// POST: Books/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,PublishDate,Language,Price,ISBN,Category,Pages,PublisherID,AuthorID")] BookViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    var response = await client.PostAsJsonAsync("api/Books/", _mapper.Map<BookViewModel, Book>(bookVM));
                    if (!response.IsSuccessStatusCode)
                    {
                        View(bookVM);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            //ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "ID", book.AuthorID);
            //ViewData["PublisherID"] = new SelectList(_context.Publishers, "ID", "ID", book.PublisherID);
            return View(bookVM);
        }

        //// GET: Books/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Books.SingleOrDefaultAsync(m => m.ID == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "ID", book.AuthorID);
        //    ViewData["PublisherID"] = new SelectList(_context.Publishers, "ID", "ID", book.PublisherID);
        //    return View(book);
        //}

        //// POST: Books/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,PublishDate,Language,Price,ISBN,Category,Pages,PublisherID,AuthorID")] Book book)
        //{
        //    if (id != book.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(book);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookExists(book.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "ID", book.AuthorID);
        //    ViewData["PublisherID"] = new SelectList(_context.Publishers, "ID", "ID", book.PublisherID);
        //    return View(book);
        //}

        //// GET: Books/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Books
        //        .Include(b => b.Author)
        //        .Include(b => b.Publisher)
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}

        //// POST: Books/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var book = await _context.Books.SingleOrDefaultAsync(m => m.ID == id);
        //    _context.Books.Remove(book);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BookExists(int id)
        //{
        //    return _context.Books.Any(e => e.ID == id);
        //}
    }
}
