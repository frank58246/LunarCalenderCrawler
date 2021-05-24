using LunarCalenderCrawler.Service.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace LunarCalenderCoverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("請輸入年份");
            var year = Console.ReadLine();
            var filePath = $"{year}.json";
            if (File.Exists(filePath).Equals(false))
            {
                Console.WriteLine("指定檔案不存在");
                Console.ReadKey();
                return;
            }

            var json = File.ReadAllText(filePath);
            var dateList = JsonConvert
                .DeserializeObject<List<DateDto>>(json);

            var destination = $"E:\\{year}.csv";

            using (var file = new StreamWriter(destination))
            {
                foreach (var item in dateList)
                {
                    file.WriteLine(item.ToString());
                }
            }
            Console.WriteLine($"已經寫入{destination}");
            Console.ReadKey();
        }
    }
}