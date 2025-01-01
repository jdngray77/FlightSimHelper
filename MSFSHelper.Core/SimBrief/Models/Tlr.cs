using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="tlr")]
public class Tlr { 

    [XmlElement(ElementName="takeoff")] 
    public Takeoff Takeoff { get; set; } 

    [XmlElement(ElementName="landing")] 
    public Landing Landing { get; set; } 
}