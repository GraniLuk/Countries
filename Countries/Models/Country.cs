using System;
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


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Countries
    {

        private CountriesCountry[] countryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Country")]
        public CountriesCountry[] Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CountriesCountry
    {

        private byte idField;

        private string nameField;

        private string capitalField;

        private string currencyField;

        /// <remarks/>
        public byte Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Capital
        {
            get
            {
                return this.capitalField;
            }
            set
            {
                this.capitalField = value;
            }
        }

        /// <remarks/>
        public string Currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }
    }


}