using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="alternate_navlog")]
public class AlternateNavlog { 

    [XmlElement(ElementName="fix")] 
    public List<Fix> Fix { get; set; } 
}