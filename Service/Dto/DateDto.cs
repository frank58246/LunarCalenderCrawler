using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalenderCrawler.Service.Dto
{
    public class DateDto
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public int Week { get; set; }

        public int LunarYear { get; set; }

        public int LunarMonth { get; set; }

        public int LunarDay { get; set; }

        public DateDto(int year, int month, int day,
            int lunarYear, int lunarMonth, int lunarDay)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.LunarYear = lunarYear;
            this.LunarMonth = lunarMonth;
            this.LunarDay = lunarDay;
        }
    }
}