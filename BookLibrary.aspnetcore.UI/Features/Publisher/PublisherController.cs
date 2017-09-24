namespace BookLibrary.aspnetcore.UI.Features.Publisher
{
    using AutoMapper;
    using BookLibrary.aspnetcore.Domain;
    using BookLibrary.aspnetcore.Services.Interfaces;
    using BookLibrary.aspnetcore.UI.Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PublisherController : BaseController
    {

        private IPublisherService _publisherService;

        public PublisherController(IMapper mapper, IPublisherService publisherService) : base(mapper)
        {
            _publisherService = publisherService;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IEnumerable<PublisherViewModel>> GetPublishers()
        {
            var publishers = await _publisherService.GetAll();
            return _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherViewModel>>(publishers);
        }

        // GET: Publisher/Create
        public async Task<IActionResult> Create()
        {
            var publisherVM = new PublisherViewModel();
            return View(publisherVM);
        }

        // POST: Publisher/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PublisherViewModel publisherVM)
        {
            var created = await _publisherService.Create(_mapper.Map<PublisherViewModel, Publisher>(publisherVM));
            return created ? Ok() as ActionResult : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var deleted = await _publisherService.Delete(id);
            return deleted ? Ok() as ActionResult : BadRequest();
        }

    }

}
