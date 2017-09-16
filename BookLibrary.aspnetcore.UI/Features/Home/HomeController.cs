using BookLibrary.aspnetcore.Services.Interfaces;
using BookLibrary.aspnetcore.UI.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI.Features.Home
{
    public class HomeController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private IPublisherService _publisherService;
        private readonly IUrlHelper urlHelper;

        public HomeController(IBookService bookService, IAuthorService authorService, 
                              IPublisherService publisherService, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor) 
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        public async Task<IActionResult> Index()
        {
            var dashboardVM = new DashboardViewModel
            {
                BooksPanel = new DashboardPanelViewModel
                {
                    Title = "Books",
                    Value = await _bookService.GetCount(),
                    ColorCssClass = "panel-primary",
                    IconCssClass = "fa-book",
                    Url = urlHelper.Action("Index", "Book")
                },
                AuthorsPanel = new DashboardPanelViewModel
                {
                    Title = "Authors",
                    Value = await _authorService.GetCount(),
                    ColorCssClass = "panel-green",
                    IconCssClass = "fa-user",
                    Url = urlHelper.Action("Index", "Author")
                },
                PublishersPanel = new DashboardPanelViewModel
                {
                    Title = "Publishers",
                    Value = await _publisherService.GetCount(),
                    ColorCssClass = "panel-red",
                    IconCssClass = "fa-building",
                    Url = urlHelper.Action("Index", "Publisher")
                },
            };
            return View(dashboardVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
