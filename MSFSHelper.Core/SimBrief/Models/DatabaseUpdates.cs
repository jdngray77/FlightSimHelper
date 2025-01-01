using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="database_updates")]
public class DatabaseUpdates { 

    [XmlElement(ElementName="metar_taf")] 
    public int MetarTaf { get; set; } 

    [XmlElement(ElementName="winds")] 
    public int Winds { get; set; } 

    [XmlElement(ElementName="sigwx")] 
    public int Sigwx { get; set; } 

    [XmlElement(ElementName="sigmet")] 
    public int Sigmet { get; set; } 

    [XmlElement(ElementName="notams")] 
    public int Notams { get; set; } 

    [XmlElement(ElementName="tracks")] 
    public int Tracks { get; set; } 
}