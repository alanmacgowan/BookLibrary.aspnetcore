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
        
    }

}
