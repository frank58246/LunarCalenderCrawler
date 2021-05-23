using LunarCalenderCrawler.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalenderCrawler.Service
{
    public interface ILunarService
    {
        IList<DateDto> GetCalenderAsync(int year, int month, int dat);
    }
}