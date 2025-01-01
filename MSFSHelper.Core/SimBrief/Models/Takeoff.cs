using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="takeoff")]
public class Takeoff { 

    [XmlElement(ElementName="conditions")] 
    public Conditions Conditions { get; set; } 

    [XmlElement(ElementName="runway")] 
    public List<Runway> Runway { get; set; } 
}