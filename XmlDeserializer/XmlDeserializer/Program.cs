using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deserialization.test
{
    public class Program
    {
        [XmlType("user")]
        public class User
        {
            [XmlElement("id")]
            public string Id { get; set; }
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("age")]
            public string Age { get; set; }
            [XmlElement("status")]
            public Status Status { get; set; }
        }
        [XmlType("status")]
        public class Status
        {
            [XmlElement("type")]
            public string Type { get; set; }
            [XmlElement("number")]
            public string Number { get; set; }
        }
        public static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
        static void Main(string[] args)
        {
            string xmlStr = @"
	                    <node1>
		                    <user>
			                    <id>1</id>
			                    <name>Adsa</name>
			                    <age>12</age>
                                <status>
                                    <type>1</type>
                                    <number>3</number>
                                </status>
		                    </user>
		                    <user>
			                    <id>2</id>
			                    <name>Bdsa</name>
			                    <age>13</age>
                                <status>
                                    <type>1</type>
                                    <number>3</number>
                                </status>
		                    </user>
		                    <user>
			                    <id>3</id>
			                    <name>Cdsa</name>
			                    <age>14</age>
                                <status>
                                    <type>1</type>
                                    <number>3</number>
                                </status>
		                    </user>
		                    <user>
			                    <id>4</id>
			                    <name>Ddsa</name>
			                    <age>15</age>
                                <status>
                                    <type>1</type>
                                    <number>3</number>
                                </status>
		                    </user>
	                    </node1>";


            List<User> users;
            using (var reader = GenerateStreamFromString(xmlStr))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<User>),
                    new XmlRootAttribute("node1"));
                users = (List<User>)deserializer.Deserialize(reader);
            }
        }
    }
}
