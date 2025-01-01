using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="images")]
public class Images { 

    [XmlElement(ElementName="directory")] 
    public string Directory { get; set; } 

    [XmlElement(ElementName="map")] 
    public List<Map> Map { get; set; } 
}