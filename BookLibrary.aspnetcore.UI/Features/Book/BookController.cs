
namespace BookLibrary.aspnetcore.UI.Features.Book
{
    using AutoMapper;
    using BookLibrary.aspnetcore.Domain;
    using BookLibrary.aspnetcore.Services.Interfaces;
    using BookLibrary.aspnetcore.UI.Features.Author;
    using BookLibrary.aspnetcore.UI.Features.Publisher;
    using BookLibrary.aspnetcore.UI.Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookController : BaseController
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private IPublisherService _publisherService;

        public BookController(IMapper mapper, IBookService bookService,
                               IAuthorService authorService, IPublisherService publisherService) : base(mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IEnumerable<BookViewModel>> GetBooks()
        {
            var books = await _bookService.GetAll();
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var book = await _bookService.Get(id.Value);

            return View(_mapper.Map<Book, BookViewModel>(book));
        }

        // GET: Book/Create
        public async Task<IActionResult> Create()
        {
            var bookVM = new BookEditViewModel();
            bookVM.Authors = await GetAuthors();
            bookVM.Publishers = await GetPublishers();
            return View(bookVM);
        }

        // POST: Book/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookViewModel bookVM)
        {
            var created = await _bookService.Create(_mapper.Map<BookViewModel, Book>(bookVM));
            return created ? Ok() as ActionResult : BadRequest();
        }

        // GET: Book/Edit/5
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

        // POST: Book/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] BookViewModel bookVM)
        {
            var edited = await _bookService.Update(_mapper.Map<BookViewModel, Book>(bookVM));
            return edited ? Ok() as ActionResult : BadRequest();
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
