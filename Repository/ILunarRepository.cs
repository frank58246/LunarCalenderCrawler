using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalenderCrawler.Repository
{
    public interface ILunarRepository
    {
        /// <summary>
        /// 取得指定年月日的農民曆網頁
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        Task<string> GetHtmlAsync(int year, int month, int day);
    }
}