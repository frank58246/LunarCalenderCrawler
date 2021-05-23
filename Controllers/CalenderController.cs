using LunarCalenderCrawler.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalenderCrawler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalenderController : ControllerBase
    {
        private ILunarRepository lunarRepository;

        public CalenderController(ILunarRepository lunarRepository)
        {
            this.lunarRepository = lunarRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var html = this.lunarRepository.GetHtmlAsync(1992, 5)
                .GetAwaiter().GetResult();

            return new List<string>() { html };
        }
    }
}