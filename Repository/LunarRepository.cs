using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalenderCrawler.Repository
{
    public class LunarRepository : ILunarRepository
    {
        public async Task<string> GetHtmlAsync(int year, int month, int day)
        {
            throw new NotImplementedException();
        }
    }
}