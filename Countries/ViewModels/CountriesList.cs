using Countries.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace Countries.ViewModels
{
    public class CountriesList
    {
        public List<Country> Countries { get; set; } = new List<Country>();
        public CountriesList()
        {
            Countries = LoadCountriesFromXml();
        }

        private List<Country> LoadCountriesFromXml()
        {
            XmlDocument doc = new XmlDocument();
            var path = "ListOfCountries.xml";
            doc.Load(HttpContext.Current.Server.MapPath("~/Content/ListOfCountries.xml"));

            var fieldsToAdd = new List<Country>();

            foreach (XmlNode node in doc.SelectNodes("/Countries/Country"))
            {

                fieldsToAdd.Add(new Country() {
                    Name = node["Name"].InnerText 
                   ,Id = Convert.ToInt32(node["Id"].InnerText)
                });
            }
            return fieldsToAdd;

        }

    }
}