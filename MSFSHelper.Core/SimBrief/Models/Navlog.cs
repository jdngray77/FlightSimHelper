using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="navlog")]
public class Navlog { 

    [XmlElement(ElementName="fix")] 
    public List<Fix> Fix { get; set; } 
}