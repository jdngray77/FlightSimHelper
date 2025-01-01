using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="tfd")]
public class Tfd { 

    [XmlElement(ElementName="name")] 
    public string Name { get; set; } 

    [XmlElement(ElementName="link")] 
    public string Link { get; set; } 
}