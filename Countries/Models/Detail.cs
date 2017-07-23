using System.Xml.Serialization;

namespace Countries.Models
{
    public class Detail
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
    }
}