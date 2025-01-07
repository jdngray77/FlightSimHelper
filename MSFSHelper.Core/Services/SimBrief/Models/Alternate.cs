using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="alternate")]
public class Alternate { 

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

    [XmlElement(ElementName="cruise_altitude")] 
    public int CruiseAltitude { get; set; } 

    [XmlElement(ElementName="distance")] 
    public int Distance { get; set; } 

    [XmlElement(ElementName="gc_distance")] 
    public int GcDistance { get; set; } 

    [XmlElement(ElementName="air_distance")] 
    public int AirDistance { get; set; } 

    [XmlElement(ElementName="track_true")] 
    public int TrackTrue { get; set; } 

    [XmlElement(ElementName="track_mag")] 
    public int TrackMag { get; set; } 

    [XmlElement(ElementName="tas")] 
    public int Tas { get; set; } 

    [XmlElement(ElementName="gs")] 
    public int Gs { get; set; } 

    [XmlElement(ElementName="avg_wind_comp")] 
    public string AvgWindComp { get; set; } 

    [XmlElement(ElementName="avg_wind_dir")] 
    public int AvgWindDir { get; set; } 

    [XmlElement(ElementName="avg_wind_spd")] 
    public int AvgWindSpd { get; set; } 

    [XmlElement(ElementName="avg_tropopause")] 
    public int AvgTropopause { get; set; } 

    [XmlElement(ElementName="avg_tdv")] 
    public string AvgTdv { get; set; } 

    [XmlElement(ElementName="ete")] 
    public int Ete { get; set; } 

    [XmlElement(ElementName="burn")] 
    public int Burn { get; set; } 

    [XmlElement(ElementName="route")] 
    public string Route { get; set; } 

    [XmlElement(ElementName="route_ifps")] 
    public string RouteIfps { get; set; } 

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
    public object Atis { get; set; } 

    [XmlElement(ElementName="notam")] 
    public List<Notam> Notam { get; set; } 
}