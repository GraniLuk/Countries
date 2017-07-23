using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Countries.Models
{
    [Serializable(),
     XmlType(AnonymousType = true), XmlRoot(Namespace = "", IsNullable = false)]
    public class Countries
    {
        public Countries()
        {
                
        }
        [XmlElement(nameof(Country))]
        public Country[] Country { get; set; }

        public int FindCountryIndexById(int id)
        {
            return Array.FindIndex(Country, row => row.Id == id);
        }

        public static Countries Load(string filePath)
        {
            var deserializer = new XmlSerializer(typeof(Countries), new XmlRootAttribute(nameof(Countries)));
            using (var stream = new StreamReader(filePath))
            {
                return deserializer.Deserialize(stream) as Countries;
            }
           
        }

        public static void Save(string filePath, Countries countries)
        {
            var serializer = new XmlSerializer(typeof(Countries), new XmlRootAttribute(nameof(Countries)));
            using (var sww = new StreamWriter(filePath))
            {
                using (var writer = XmlWriter.Create(sww))
                {
                    serializer.Serialize(writer, countries);
                }
            }

        }
    }
}