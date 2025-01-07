using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="general")]
public class General { 

    [XmlElement(ElementName="release")] 
    public int Release { get; set; } 

    [XmlElement(ElementName="icao_airline")] 
    public object IcaoAirline { get; set; } 

    [XmlElement(ElementName="flight_number")] 
    public string FlightNumber { get; set; } 

    [XmlElement(ElementName="is_etops")] 
    public int IsEtops { get; set; } 

    [XmlElement(ElementName="dx_rmk")] 
    public List<string> DxRmk { get; set; } 

    [XmlElement(ElementName="sys_rmk")] 
    public object SysRmk { get; set; } 

    [XmlElement(ElementName="is_detailed_profile")] 
    public int IsDetailedProfile { get; set; } 

    [XmlElement(ElementName="cruise_profile")] 
    public string CruiseProfile { get; set; } 

    [XmlElement(ElementName="climb_profile")] 
    public string ClimbProfile { get; set; } 

    [XmlElement(ElementName="descent_profile")] 
    public string DescentProfile { get; set; } 

    [XmlElement(ElementName="alternate_profile")] 
    public string AlternateProfile { get; set; } 

    [XmlElement(ElementName="reserve_profile")] 
    public string ReserveProfile { get; set; } 

    [XmlElement(ElementName="costindex")] 
    public int Costindex { get; set; } 

    [XmlElement(ElementName="cont_rule")] 
    public string ContRule { get; set; } 

    [XmlElement(ElementName="initial_altitude")] 
    public int InitialAltitude { get; set; } 

    [XmlElement(ElementName="stepclimb_string")] 
    public string StepclimbString { get; set; } 

    [XmlElement(ElementName="avg_temp_dev")] 
    public int AvgTempDev { get; set; } 

    [XmlElement(ElementName="avg_tropopause")] 
    public int AvgTropopause { get; set; } 

    [XmlElement(ElementName="avg_wind_comp")] 
    public int AvgWindComp { get; set; } 

    [XmlElement(ElementName="avg_wind_dir")] 
    public int AvgWindDir { get; set; } 

    [XmlElement(ElementName="avg_wind_spd")] 
    public int AvgWindSpd { get; set; } 

    [XmlElement(ElementName="gc_distance")] 
    public int GcDistance { get; set; } 

    [XmlElement(ElementName="route_distance")] 
    public int RouteDistance { get; set; } 

    [XmlElement(ElementName="air_distance")] 
    public int AirDistance { get; set; } 

    [XmlElement(ElementName="total_burn")] 
    public int TotalBurn { get; set; } 

    [XmlElement(ElementName="cruise_tas")] 
    public int CruiseTas { get; set; } 

    [XmlElement(ElementName="cruise_mach")] 
    public double CruiseMach { get; set; } 

    [XmlElement(ElementName="passengers")] 
    public int Passengers { get; set; } 

    [XmlElement(ElementName="route")] 
    public string Route { get; set; } 

    [XmlElement(ElementName="route_ifps")] 
    public string RouteIfps { get; set; } 

    [XmlElement(ElementName="route_navigraph")] 
    public string RouteNavigraph { get; set; } 

    [XmlElement(ElementName="sid_ident")] 
    public string SidIdent { get; set; } 

    [XmlElement(ElementName="sid_trans")] 
    public object SidTrans { get; set; } 

    [XmlElement(ElementName="star_ident")] 
    public string StarIdent { get; set; } 

    [XmlElement(ElementName="star_trans")] 
    public object StarTrans { get; set; } 
}