using LunarCalenderCrawler.Repository;
using LunarCalenderCrawler.Service.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            // 去掉html的標籤
            var pattern = "<[^>]*>";
            var reg = new Regex(pattern);
            html = reg.Replace(html, "");

            // 取得每一天的日期
            var dayReg = @"DayInfoA\[\d+\]='【陽曆】(?<son>\d+年\d+月\d+日)" +
                                    @"[^日]*【農曆】(?<lunar>\d+年\d+月\d+日)";

            var dateList = new List<DateDto>();

            var oneDateReg = new Regex(dayReg);
            var matches = oneDateReg.Matches(html);
            foreach (Match match in matches)
            {
                // 取得陽曆和農曆的日期
                var son = match.Groups["son"].Value
                    .Replace("年", "-").Replace("月", "-").Replace("日", "");

                var lunar = match.Groups["lunar"].Value
                    .Replace("年", "-").Replace("月", "-").Replace("日", "");

                var sonDate = DateTime.Parse(son);
                var lunarDate = DateTime.Parse(lunar);
                var oneDayDto = new DateDto()
                {
                    Year = sonDate.Year,
                    Month = sonDate.Month,
                    Day = sonDate.Day,
                    Week = (int)sonDate.DayOfWeek,
                    LunarYear = lunarDate.Year,
                    LunarMonth = lunarDate.Month,
                    LunarDay = lunarDate.Day
                };

                dateList.Add(oneDayDto);
            }

            return dateList;
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