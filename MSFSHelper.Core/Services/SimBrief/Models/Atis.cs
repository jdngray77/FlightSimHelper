using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="atis")]
public class Atis { 

    [XmlElement(ElementName="network")] 
    public string Network { get; set; } 

    [XmlElement(ElementName="issued")] 
    public DateTime Issued { get; set; } 

    [XmlElement(ElementName="letter")] 
    public string Letter { get; set; } 

    [XmlElement(ElementName="phonetic")] 
    public string Phonetic { get; set; } 

    [XmlElement(ElementName="type")] 
    public string Type { get; set; } 

    [XmlElement(ElementName="message")] 
    public string Message { get; set; } 
}