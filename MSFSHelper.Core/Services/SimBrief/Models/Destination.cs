using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="destination")]
public class Destination { 

    [XmlElement(ElementName="icao_code")] 
    public string IcaoCode { get; set; } 

    [XmlElement(ElementName="iata_code")] 
    public string IataCode { get; set; } 

    [XmlElement(ElementName="faa_code")] 
    public object FaaCode { get; set; } 

    [XmlElement(ElementName="icao_region")] 
    public string IcaoRegion { get; set; } 

    [XmlElement(ElementName="elevation")] 
    public int Elevation { get; set; } 

    [XmlElement(ElementName="pos_lat")] 
    public double PosLat { get; set; } 

    [XmlElement(ElementName="pos_long")] 
    public double PosLong { get; set; } 

    [XmlElement(ElementName="name")] 
    public string Name { get; set; } 

    [XmlElement(ElementName="timezone")] 
    public int Timezone { get; set; } 

    [XmlElement(ElementName="plan_rwy")] 
    public string PlanRwy { get; set; } 

    [XmlElement(ElementName="trans_alt")] 
    public int TransAlt { get; set; } 

    [XmlElement(ElementName="trans_level")] 
    public int TransLevel { get; set; } 

    [XmlElement(ElementName="metar")] 
    public string Metar { get; set; } 

    [XmlElement(ElementName="metar_time")] 
    public DateTime MetarTime { get; set; } 

    [XmlElement(ElementName="metar_category")] 
    public string MetarCategory { get; set; } 

    [XmlElement(ElementName="metar_visibility")] 
    public int MetarVisibility { get; set; } 

    [XmlElement(ElementName="metar_ceiling")] 
    public int MetarCeiling { get; set; } 

    [XmlElement(ElementName="taf")] 
    public string Taf { get; set; } 

    [XmlElement(ElementName="taf_time")] 
    public DateTime TafTime { get; set; } 

    [XmlElement(ElementName="atis")] 
    public Atis Atis { get; set; } 

    [XmlElement(ElementName="notam")] 
    public List<Notam> Notam { get; set; } 
}