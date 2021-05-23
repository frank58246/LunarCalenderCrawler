using LunarCalenderCrawler.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalenderCrawler.Service
{
    public interface ILunarService
    {
        Task<IList<DateDto>> GetCalenderAsync(int year, int month);

        IList<DateDto> Covert(string html);
    }
}