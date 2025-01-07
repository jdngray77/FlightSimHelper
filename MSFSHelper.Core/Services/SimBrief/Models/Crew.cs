using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="crew")]
public class Crew { 

    [XmlElement(ElementName="pilot_id")] 
    public int PilotId { get; set; } 

    [XmlElement(ElementName="cpt")] 
    public string Cpt { get; set; } 

    [XmlElement(ElementName="fo")] 
    public string Fo { get; set; } 

    [XmlElement(ElementName="dx")] 
    public string Dx { get; set; } 

    [XmlElement(ElementName="pu")] 
    public string Pu { get; set; } 

    [XmlElement(ElementName="fa")] 
    public List<string> Fa { get; set; } 
}