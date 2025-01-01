using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="xfm")]
public class Xfm { 

    [XmlElement(ElementName="name")] 
    public string Name { get; set; } 

    [XmlElement(ElementName="link")] 
    public string Link { get; set; } 
}