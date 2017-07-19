﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;

namespace Countries.Models
{
    public class Country
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Field> Fields { get; set; } = new List<Field>();

        public XDocument doc { get; set; }

        public Country()
        {

        }

        public Country(int countryId)
        {
            Fields = LoadCountriesFromXml(countryId);
        }

        private List<Field> LoadCountriesFromXml(int countryId)
        {
            doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/Content/ListOfCountries.xml"));
      //      doc.Load(HttpContext.Current.Server.MapPath(HttpContext.Current.Server.MapPath("~/ListOfCountries.xml")));

            var fieldsToAdd = new List<Field>();

            var country = doc.Root
               .Descendants("Country")
               .SingleOrDefault(e => (int)e.Element("Id") == countryId);

            this.Name = country.Element("Name").Value;
            //  var country = root.SelectSingleNode("descendant::Country[@bk:Id='1']", nsmgr);

            foreach (var childNode in country.Elements())
            {
                if (childNode.Name.ToString() != "Id" && childNode.Name.ToString() != "Name")
                {


                    fieldsToAdd.Add(new Field() { Name = childNode.Name.ToString(), Value = childNode.Value });
                }
            }
            
            return fieldsToAdd;

        }
    }

    public class Field
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}