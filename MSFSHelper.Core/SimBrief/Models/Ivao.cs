using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="ivao")]
public class Ivao { 

    [XmlElement(ElementName="name")] 
    public string Name { get; set; } 

    [XmlElement(ElementName="site")] 
    public string Site { get; set; } 

    [XmlElement(ElementName="link")] 
    public string Link { get; set; } 

    [XmlElement(ElementName="form")] 
    public string Form { get; set; } 
}