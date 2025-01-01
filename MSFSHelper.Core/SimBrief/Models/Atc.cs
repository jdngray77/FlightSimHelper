using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="atc")]
public class Atc { 

    [XmlElement(ElementName="flightplan_text")] 
    public string FlightplanText { get; set; } 

    [XmlElement(ElementName="route")] 
    public string Route { get; set; } 

    [XmlElement(ElementName="route_ifps")] 
    public string RouteIfps { get; set; } 

    [XmlElement(ElementName="callsign")] 
    public string Callsign { get; set; } 

    [XmlElement(ElementName="initial_spd")] 
    public int InitialSpd { get; set; } 

    [XmlElement(ElementName="initial_spd_unit")] 
    public string InitialSpdUnit { get; set; } 

    [XmlElement(ElementName="initial_alt")] 
    public int InitialAlt { get; set; } 

    [XmlElement(ElementName="initial_alt_unit")] 
    public string InitialAltUnit { get; set; } 

    [XmlElement(ElementName="section18")] 
    public string Section18 { get; set; } 

    [XmlElement(ElementName="fir_orig")] 
    public string FirOrig { get; set; } 

    [XmlElement(ElementName="fir_dest")] 
    public string FirDest { get; set; } 

    [XmlElement(ElementName="fir_altn")] 
    public string FirAltn { get; set; } 

    [XmlElement(ElementName="fir_etops")] 
    public object FirEtops { get; set; } 

    [XmlElement(ElementName="fir_enroute")] 
    public object FirEnroute { get; set; } 
}