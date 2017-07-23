using Countries.Models;
using NUnit.Framework;

namespace Countries.Tests
{
    [TestFixture]
    internal class CountriesFindTests
    {
        [Test]
        public void FindCountryIndexById_Return0()
        {
            var countries = new Models.Countries
            {
                Country = new[]
                {
                    new Country() {Id = 1, Name = "Poland"},
                    new Country() {Id = 2, Name = "England"}
                }
            };

            var result = countries.FindCountryIndexById(1);

            Assert.AreEqual(0, result);        
        }
    }
}
