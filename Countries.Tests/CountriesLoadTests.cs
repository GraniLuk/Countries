using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Countries;
using Countries.Controllers;


namespace Countries.Tests
{

    [TestFixture]
    public class CountriesLoadTests
    {
        private string _fileName;
        [SetUp]
        public void SetUp()
        {
            var testPath = TestContext.CurrentContext.TestDirectory;
            _fileName = Path.Combine(testPath, "ListOfCountries.xml");

        }
        [Test]
        public void LoadCountriesTest()
        {
            var countries = Models.Countries.Load(_fileName);
            Assert.IsNotNull(countries);
        }
        [Test]
        public void LoadCountriesCheckCountriesList()
        {
            var countries = Models.Countries.Load(_fileName);
            var poland = countries.Country.FirstOrDefault(x => x.Name == "Poland");
            Assert.IsNotNull(poland);
        }

        [Test]
        public void LoadCountriesCheckCountryDetailsNotNull()
        {
            var countries = Models.Countries.Load(_fileName);
            var poland = countries.Country.FirstOrDefault(x => x.Name == "Poland");
            Assert.NotZero(poland.Details.Count);
        }
        [Test]
        public void ForEachCountryDisplayName()
        {
            var countries = Models.Countries.Load(_fileName);

            foreach (var country in countries.Country)
            {
                Assert.IsNotNull(country.Name);
            }
        }

    }
}
