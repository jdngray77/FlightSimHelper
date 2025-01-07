using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="weather")]
public class Weather { 

    [XmlElement(ElementName="orig_metar")] 
    public string OrigMetar { get; set; } 

    [XmlElement(ElementName="orig_taf")] 
    public string OrigTaf { get; set; } 

    [XmlElement(ElementName="dest_metar")] 
    public string DestMetar { get; set; } 

    [XmlElement(ElementName="dest_taf")] 
    public string DestTaf { get; set; } 

    [XmlElement(ElementName="altn_metar")] 
    public string AltnMetar { get; set; } 

    [XmlElement(ElementName="altn_taf")] 
    public string AltnTaf { get; set; } 

    [XmlElement(ElementName="toaltn_metar")] 
    public object ToaltnMetar { get; set; } 

    [XmlElement(ElementName="toaltn_taf")] 
    public object ToaltnTaf { get; set; } 

    [XmlElement(ElementName="eualtn_metar")] 
    public object EualtnMetar { get; set; } 

    [XmlElement(ElementName="eualtn_taf")] 
    public object EualtnTaf { get; set; } 

    [XmlElement(ElementName="etops_metar")] 
    public object EtopsMetar { get; set; } 

    [XmlElement(ElementName="etops_taf")] 
    public object EtopsTaf { get; set; } 
}