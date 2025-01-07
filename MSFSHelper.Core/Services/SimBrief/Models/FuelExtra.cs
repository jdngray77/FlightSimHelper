using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="fuel_extra")]
public class FuelExtra { 

    [XmlElement(ElementName="bucket")] 
    public List<Bucket> Bucket { get; set; } 
}