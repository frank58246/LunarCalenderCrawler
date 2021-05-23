using Microsoft.VisualStudio.TestTools.UnitTesting;
using LunarCalenderCrawler.Service;
using System;
using System.Collections.Generic;
using System.Text;
using LunarCalenderCrawler.Repository;
using NSubstitute;
using LunarCalenderCrawler.Service.Dto;
using System.Threading.Tasks;
using FluentAssertions;
using System.IO;

namespace LunarCalenderCrawler.Service.Tests
{
    [TestClass()]
    public class LunarServiceTests
    {
        private readonly ILunarRepository _lunarRepository;

        public LunarServiceTests()
        {
            this._lunarRepository = Substitute.For<ILunarRepository>();
        }

        private LunarService GetSystemUndereTest()
        {
            return new LunarService(this._lunarRepository);
        }

        [TestMethod()]
        public void CovertTest()
        {
            // Arrange
            var sut = this.GetSystemUndereTest();
            var year = 1992;
            var month = 1;
            var html = this.GetHtml(year, month);
            var expected = new List<DateDto>()
            {
                new DateDto(1992,1,1,1991,11,27,3),
                new DateDto(1992,1,2,1991,11,28,4),
                new DateDto(1992,1,3,1991,11,29,5),
                new DateDto(1992,1,4,1991,11,30,6),
                new DateDto(1992,1,5,1991,12,1,0),
                new DateDto(1992,1,6,1991,12,2,1),
                new DateDto(1992,1,7,1991,12,3,2),
                new DateDto(1992,1,8,1991,12,4,3),
                new DateDto(1992,1,9,1991,12,5,4),
                new DateDto(1992,1,10,1991,12,6,5),
                new DateDto(1992,1,11,1991,12,7,6),
                new DateDto(1992,1,12,1991,12,8,0),
                new DateDto(1992,1,13,1991,12,9,1),
                new DateDto(1992,1,14,1991,12,10,2),
                new DateDto(1992,1,15,1991,12,11,3),
                new DateDto(1992,1,16,1991,12,12,4),
                new DateDto(1992,1,17,1991,12,13,5),
                new DateDto(1992,1,18,1991,12,14,6),
                new DateDto(1992,1,19,1991,12,15,0),
                new DateDto(1992,1,20,1991,12,16,1),
                new DateDto(1992,1,21,1991,12,17,2),
                new DateDto(1992,1,22,1991,12,18,3),
                new DateDto(1992,1,23,1991,12,19,4),
                new DateDto(1992,1,24,1991,12,20,5),
                new DateDto(1992,1,25,1991,12,21,6),
                new DateDto(1992,1,26,1991,12,22,0),
                new DateDto(1992,1,27,1991,12,23,1),
                new DateDto(1992,1,28,1991,12,24,2),
                new DateDto(1992,1,29,1991,12,25,3),
                new DateDto(1992,1,30,1991,12,26,4),
                new DateDto(1992,1,31,1991,12,27,5)
            };

            // Act
            var actual = sut.Covert(html);

            // Actual
            actual.Should().BeEquivalentTo(expected);
        }

        private string GetHtml(int year, int month)
        {
            var baseDir = "TestData";
            var fileName = $"calendar_{year}_{month:d2}.html";
            var path = Path.Combine(baseDir, fileName);

            if (File.Exists(path).Equals(false))
            {
                return string.Empty;
            }

            return File.ReadAllText(path);
        }
    }
}