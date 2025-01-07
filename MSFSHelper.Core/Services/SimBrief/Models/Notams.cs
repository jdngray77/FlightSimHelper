using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="notams")]
public class Notams { 

    [XmlElement(ElementName="notamdrec")] 
    public List<Notamdrec> Notamdrec { get; set; } 

    [XmlElement(ElementName="rec-count")] 
    public int Reccount { get; set; } 
}