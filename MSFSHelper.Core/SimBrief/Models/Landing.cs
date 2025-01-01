using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="landing")]
public class Landing { 

    [XmlElement(ElementName="conditions")] 
    public Conditions Conditions { get; set; } 

    [XmlElement(ElementName="distance_dry")] 
    public DistanceDry DistanceDry { get; set; } 

    [XmlElement(ElementName="distance_wet")] 
    public DistanceWet DistanceWet { get; set; } 

    [XmlElement(ElementName="runway")] 
    public List<Runway> Runway { get; set; } 
}