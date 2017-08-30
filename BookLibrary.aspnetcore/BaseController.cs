using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.UI
{
    public class BaseController : Controller
    {
        protected readonly string _baseUrl;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _configuration;

        public BaseController(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
            _baseUrl = _configuration.GetValue<string>("AppSettings:BaseUrl");
        }
    }
}
