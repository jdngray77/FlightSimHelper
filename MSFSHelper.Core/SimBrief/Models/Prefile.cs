using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="prefile")]
public class Prefile { 

    [XmlElement(ElementName="vatsim")] 
    public Vatsim Vatsim { get; set; } 

    [XmlElement(ElementName="ivao")] 
    public Ivao Ivao { get; set; } 

    [XmlElement(ElementName="pilotedge")] 
    public Pilotedge Pilotedge { get; set; } 

    [XmlElement(ElementName="poscon")] 
    public Poscon Poscon { get; set; } 
}