using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Models;
using NUnit.Framework;
using Countries = Countries.Models.Countries;

namespace Countries.Tests
{
    [TestFixture]
    class CountriesSaveTests
    {
        private string _fileName;
        [SetUp]
        public void SetUp()
        {
            var testPath = TestContext.CurrentContext.TestDirectory;
            _fileName = Path.Combine(testPath, "SaveListOfCountries.xml");

        }
        [Test]
        public void SaveModelToFile()
        {
            var countries = new Models.Countries
            {
                Country = new[]
                {
                    new Country() {Id = 1, Name = "Poland", Details = new List<Detail>(){ new Detail(){Name = "Capitol",Value = "Warsaw"}}},
                    new Country() {Id = 2, Name = "England", Details = new List<Detail>(){ new Detail(){Name = "Capitol",Value = "London"}}}
                }
            };

            Models.Countries.Save(_fileName, countries);

            var loadedModel = Models.Countries.Load(_fileName);
            Assert.AreEqual("Warsaw",loadedModel.Country.FirstOrDefault().Details.FirstOrDefault().Value);
        }
    }
}
