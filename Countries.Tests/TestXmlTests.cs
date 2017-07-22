using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Countries.Tests
{
    class TestXmlTests
    {
        private string _fileName;
        [SetUp]
        public void SetUp()
        {
            var testPath = TestContext.CurrentContext.TestDirectory;
            _fileName = Path.Combine(testPath, "test.xml");

        }
        [Test]
        public void LoadModelFromXmlTest()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Settings), new XmlRootAttribute("settings"));
            Settings objectValue = (Settings)deserializer.Deserialize(new StreamReader(_fileName));

            Assert.IsNotNull(objectValue.calculator);
            Assert.IsNotNull(objectValue.features);

        }
        [Test]
        public void LoadModelFromXmlTestCheckFeatures()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Settings), new XmlRootAttribute("settings"));
            Settings objectValue = (Settings)deserializer.Deserialize(new StreamReader(_fileName));

            var firstFeature = objectValue.features.FirstOrDefault();

            Assert.AreEqual("HAZ", firstFeature.Name);


        }

    }
    [XmlRoot("settings")]
    public class Settings
    {
        [XmlElement("calculator")]
        public Calculator calculator { get; set; }

        [XmlArray("features")]
        [XmlArrayItem("feature")]
        public List<Feature> features { get; set; }
    }

    public class Calculator
    {
        [XmlAttribute]
        public string display { get; set; }
    }

    public class Feature
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string description { get; set; }
    }
}

