using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="text")]
public class Text { 

    [XmlElement(ElementName="nat_tracks")] 
    public object NatTracks { get; set; } 

    [XmlElement(ElementName="tlr_section")] 
    public string TlrSection { get; set; } 

    [XmlElement(ElementName="plan_html")] 
    public string PlanHtml { get; set; } 
}