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
    [Serializable(),
     XmlType(AnonymousType = true), XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Countries
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(nameof(Country))]
        public Country[] Country { get; set; }

    }

    /// <remarks/>
    [Serializable(),
     XmlType(AnonymousType = true)]
    public class Country
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        [XmlArray(nameof(Details))]
        [XmlArrayItem(nameof(Detail))]
        public List<Detail> Details { get; set; } = new List<Detail>();
    }

    public class Detail
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
    }
}