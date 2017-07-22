using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Countries.Models
{
    /// <remarks/>
    [SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("Name"),
     XmlTypeAttribute(AnonymousType = true), XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class CountriesList
    {
        /// <remarks/>
        [XmlArray("CountriesList")]
        [XmlArrayItem("Country")]
        public List<Country> Countries { get; set; }
    }

    /// <remarks/>
    [SerializableAttribute(), System.ComponentModel.DesignerCategoryAttribute("Name"),
     XmlTypeAttribute(AnonymousType = true)]
    public class Country
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        [XmlArray("Details")]
        [XmlArrayItem("Detail")]
        public List<Detail> Details { get; set; }
    }

    public class Detail
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
    }
}