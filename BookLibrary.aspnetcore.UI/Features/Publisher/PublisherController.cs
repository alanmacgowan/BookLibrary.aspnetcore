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

        public PublisherController(IPublisherService publisherService) : base()
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
            return Mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherViewModel>>(publishers);
        }

        // GET: Publisher/Create
        public async Task<IActionResult> Create()
        {
            return View(new PublisherViewModel());
        }

        // POST: Publisher/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PublisherViewModel publisherVM)
        {
            var created = await _publisherService.Create(publisherVM.MapTo<Publisher>());
            return created ? Ok() as ActionResult : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var deleted = await _publisherService.Delete(id);
            return deleted ? Ok() as ActionResult : BadRequest();
        }

        // GET: Publisher/Edit/5
        [HttpGet("Publisher/Edit/{id}")]
        public async Task<IActionResult> Edit(Publisher publisher)
        {
            return View(publisher.MapTo<PublisherViewModel>());
        }

        // POST: Publisher/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] PublisherViewModel publisherVM)
        {
            var edited = await _publisherService.Update(publisherVM.MapTo<Publisher>());
            return edited ? Ok() as ActionResult : BadRequest();
        }

    }

}
