using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LunarCalenderCrawler.Repository
{
    public class LunarRepository : ILunarRepository
    {
        private readonly HttpClient _httpClient;

        public LunarRepository(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string> GetHtmlAsync(int year, int month)
        {
            //建立 HttpClient
            var url = "https://fate.windada.com/cgi-bin/calendar";

            var formContent = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("FUNC", "Basic"),
                 new KeyValuePair<string, string>("Year", year.ToString()),
                 new KeyValuePair<string, string>("Month", month.ToString())
            });

            var response = await this._httpClient.PostAsync(url, formContent);

            var html = await response.Content.ReadAsStringAsync();

            return html;
        }
    }
}