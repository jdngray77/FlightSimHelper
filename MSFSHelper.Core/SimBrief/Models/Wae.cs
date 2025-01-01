using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="wae")]
public class Wae { 

    [XmlElement(ElementName="name")] 
    public string Name { get; set; } 

    [XmlElement(ElementName="link")] 
    public string Link { get; set; } 
}