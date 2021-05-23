using LunarCalenderCrawler.Repository;
using LunarCalenderCrawler.Service;
using LunarCalenderCrawler.Service.Dto;
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
        private ILunarService _lunarService;

        public CalenderController(ILunarService lunarService)
        {
            this._lunarService = lunarService;
        }

        [HttpGet]
        public IEnumerable<DateDto> Get(int year, int month)
        {
            var dateList = this._lunarService.GetCalenderAsync(year, month)
                .GetAwaiter().GetResult();

            return dateList;
        }
    }
}