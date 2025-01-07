using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="OFP")]
public class OFP { 

    [XmlElement(ElementName="fetch")] 
    public Fetch Fetch { get; set; } 

    [XmlElement(ElementName="params")] 
    public Params Params { get; set; } 

    [XmlElement(ElementName="general")] 
    public General General { get; set; } 

    [XmlElement(ElementName="origin")] 
    public Origin Origin { get; set; } 

    [XmlElement(ElementName="destination")] 
    public Destination Destination { get; set; } 

    [XmlElement(ElementName="alternate")] 
    public Alternate Alternate { get; set; } 

    [XmlElement(ElementName="alternate_navlog")] 
    public AlternateNavlog AlternateNavlog { get; set; } 

    [XmlElement(ElementName="takeoff_altn")] 
    public object TakeoffAltn { get; set; } 

    [XmlElement(ElementName="enroute_altn")] 
    public object EnrouteAltn { get; set; } 

    [XmlElement(ElementName="navlog")] 
    public Navlog Navlog { get; set; } 

    [XmlElement(ElementName="etops")] 
    public object Etops { get; set; } 

    [XmlElement(ElementName="tlr")] 
    public Tlr Tlr { get; set; } 

    [XmlElement(ElementName="atc")] 
    public Atc Atc { get; set; } 

    [XmlElement(ElementName="aircraft")] 
    public Aircraft Aircraft { get; set; } 

    [XmlElement(ElementName="fuel")] 
    public Fuel Fuel { get; set; } 

    [XmlElement(ElementName="fuel_extra")] 
    public FuelExtra FuelExtra { get; set; } 

    [XmlElement(ElementName="times")] 
    public Times Times { get; set; } 

    [XmlElement(ElementName="weights")] 
    public Weights Weights { get; set; } 

    [XmlElement(ElementName="impacts")] 
    public Impacts Impacts { get; set; } 

    [XmlElement(ElementName="crew")] 
    public Crew Crew { get; set; } 

    [XmlElement(ElementName="notams")] 
    public Notams Notams { get; set; } 

    [XmlElement(ElementName="weather")] 
    public Weather Weather { get; set; } 

    [XmlElement(ElementName="sigmets")] 
    public object Sigmets { get; set; } 

    [XmlElement(ElementName="text")] 
    public Text Text { get; set; } 

    [XmlElement(ElementName="tracks")] 
    public object Tracks { get; set; } 

    [XmlElement(ElementName="database_updates")] 
    public DatabaseUpdates DatabaseUpdates { get; set; } 

    [XmlElement(ElementName="files")] 
    public Files Files { get; set; } 

    [XmlElement(ElementName="fms_downloads")] 
    public FmsDownloads FmsDownloads { get; set; } 

    [XmlElement(ElementName="images")] 
    public Images Images { get; set; } 

    [XmlElement(ElementName="links")] 
    public Links Links { get; set; } 

    [XmlElement(ElementName="prefile")] 
    public Prefile Prefile { get; set; } 

    [XmlElement(ElementName="vatsim_prefile")] 
    public string VatsimPrefile { get; set; } 

    [XmlElement(ElementName="ivao_prefile")] 
    public string IvaoPrefile { get; set; } 

    [XmlElement(ElementName="pilotedge_prefile")] 
    public string PilotedgePrefile { get; set; } 

    [XmlElement(ElementName="poscon_prefile")] 
    public string PosconPrefile { get; set; } 

    [XmlElement(ElementName="map_data")] 
    public string MapData { get; set; } 

    [XmlElement(ElementName="api_params")] 
    public ApiParams ApiParams { get; set; } 
}