using LunarCalenderCrawler.Repository;
using LunarCalenderCrawler.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LunarCalenderCrawler.Service
{
    public class LunarService : ILunarService
    {
        private readonly ILunarRepository _lunarRepository;

        public LunarService(ILunarRepository lunarRepository)
        {
            this._lunarRepository = lunarRepository;
        }

        public IList<DateDto> Covert(string html)
        {
            var pattern = "<[^>]*>";
            var reg = new Regex(pattern);

            html = reg.Replace(html, "");
            var dayReg = @"^DayInfoA\[[d]\]";
            var a = new Regex(dayReg);
            return null;
        }

        public async Task<IList<DateDto>> GetCalenderAsync(int year, int month)
        {
            // 如果不指定月，打全部月份
            var startMonth = month == 0 ? 1 : month;
            var endMonth = month == 0 ? 12 : month;
            var dateList = new List<DateDto>();

            for (int i = startMonth; i <= endMonth; i++)
            {
                var mon = i;
                var html = await this._lunarRepository.GetHtmlAsync(year, mon);
                var date = this.Covert(html);
                dateList.AddRange(date);
            }

            return dateList;
        }
    }
}