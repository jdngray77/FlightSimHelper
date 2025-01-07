using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="bucket")]
public class Bucket { 

    [XmlElement(ElementName="label")] 
    public string Label { get; set; } 

    [XmlElement(ElementName="fuel")] 
    public int Fuel { get; set; } 

    [XmlElement(ElementName="time")] 
    public int Time { get; set; } 

    [XmlElement(ElementName="required")] 
    public string Required { get; set; } 
}