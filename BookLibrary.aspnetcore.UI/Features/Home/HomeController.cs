using BookLibrary.aspnetcore.Services.Interfaces;
using BookLibrary.aspnetcore.UI.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Generic;
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IEnumerable<ChartDataViewModel> GetChartData()
        {
            var result = new List<ChartDataViewModel>
            {
                new ChartDataViewModel(2002, 1),
                new ChartDataViewModel(2003, 11),
                new ChartDataViewModel(2004, 3),
                new ChartDataViewModel(2005, 4),
                new ChartDataViewModel(2006, 0),
                new ChartDataViewModel(2007, 0),
                new ChartDataViewModel(2008, 7),
                new ChartDataViewModel(2009, 0),
                new ChartDataViewModel(2010, 3)
            };
            return result;
        }

    }
}
