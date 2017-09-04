using AutoMapper;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services.Interfaces;
using BookLibrary.aspnetcore.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Controllers
{
    public class BooksController : BaseController
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private IPublisherService _publisherService;

        public BooksController(IMapper mapper, IBookService bookService, 
                               IAuthorService authorService, IPublisherService publisherService) : base(mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAll();

            return View(_mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books));
       }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var book = await _bookService.Get(id.Value);

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
                var created = await _bookService.Create(_mapper.Map<BookViewModel, Book>(bookVM));

                if (!created)
                {
                    View(bookVM);
                }

                return RedirectToAction(nameof(Index));
           }

            return View(bookVM);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var book = await _bookService.Get(id.Value);

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
                var edited = await _bookService.Update(_mapper.Map<BookViewModel, Book>(bookVM));

                if (!edited)
                {
                    View(bookVM);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(bookVM);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var book = await _bookService.Get(id.Value);

            return View(_mapper.Map<Book, BookViewModel>(book));
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _bookService.Delete(id);

            if (!deleted)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deleted = await _bookService.Delete(id);

            return deleted ? Ok() as ActionResult : BadRequest();
        }

        private async Task<List<AuthorViewModel>> GetAuthors()
        {
            var authors = await _authorService.GetAll();

            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorViewModel>>(authors).ToList();
        }

        private async Task<List<PublisherViewModel>> GetPublishers()
        {
            var publishers = await _publisherService.GetAll();

            return _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherViewModel>>(publishers).ToList();
        }

    }

}
