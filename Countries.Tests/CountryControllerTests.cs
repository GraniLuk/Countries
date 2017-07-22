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
    public class CountryControllerTests
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
            var countries = LoadCountries(_fileName);
            Assert.IsNotNull(countries);
        }
        [Test]
        public void LoadCountriesCheckCountriesList()
        {
            var countries = LoadCountries(_fileName);
            var poland = countries.Country.FirstOrDefault(x => x.Name == "Poland");
            Assert.IsNotNull(poland);
        }

        [Test]
        public void LoadCountriesCheckCountryDetailsNotNull()
        {
            var countries = LoadCountries(_fileName);
            var poland = countries.Country.FirstOrDefault(x => x.Name == "Poland");
            Assert.NotZero(poland.Details.Count);
        }

        public static Models.Countries LoadCountries(string filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Models.Countries), new XmlRootAttribute("Countries"));
            return deserializer.Deserialize(new StreamReader(filePath)) as Models.Countries;
        }


    }
}
