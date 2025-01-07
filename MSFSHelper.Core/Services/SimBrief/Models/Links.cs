using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="links")]
public class Links { 

    [XmlElement(ElementName="skyvector")] 
    public string Skyvector { get; set; } 
}