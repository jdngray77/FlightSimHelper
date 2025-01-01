using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="fix")]
public class Fix { 

    [XmlElement(ElementName="ident")] 
    public string Ident { get; set; } 

    [XmlElement(ElementName="name")] 
    public string Name { get; set; } 

    [XmlElement(ElementName="type")] 
    public string Type { get; set; } 

    [XmlElement(ElementName="icao_region")] 
    public string IcaoRegion { get; set; } 

    [XmlElement(ElementName="frequency")] 
    public object Frequency { get; set; } 

    [XmlElement(ElementName="pos_lat")] 
    public double PosLat { get; set; } 

    [XmlElement(ElementName="pos_long")] 
    public double PosLong { get; set; } 

    [XmlElement(ElementName="stage")] 
    public string Stage { get; set; } 

    [XmlElement(ElementName="via_airway")] 
    public string ViaAirway { get; set; } 

    [XmlElement(ElementName="is_sid_star")] 
    public int IsSidStar { get; set; } 

    [XmlElement(ElementName="distance")] 
    public int Distance { get; set; } 

    [XmlElement(ElementName="track_true")] 
    public int TrackTrue { get; set; } 

    [XmlElement(ElementName="track_mag")] 
    public int TrackMag { get; set; } 

    [XmlElement(ElementName="heading_true")] 
    public int HeadingTrue { get; set; } 

    [XmlElement(ElementName="heading_mag")] 
    public int HeadingMag { get; set; } 

    [XmlElement(ElementName="altitude_feet")] 
    public int AltitudeFeet { get; set; } 

    [XmlElement(ElementName="ind_airspeed")] 
    public int IndAirspeed { get; set; } 

    [XmlElement(ElementName="true_airspeed")] 
    public int TrueAirspeed { get; set; } 

    [XmlElement(ElementName="mach")] 
    public double Mach { get; set; } 

    [XmlElement(ElementName="mach_thousandths")] 
    public double MachThousandths { get; set; } 

    [XmlElement(ElementName="wind_component")] 
    public int WindComponent { get; set; } 

    [XmlElement(ElementName="groundspeed")] 
    public int Groundspeed { get; set; } 

    [XmlElement(ElementName="time_leg")] 
    public int TimeLeg { get; set; } 

    [XmlElement(ElementName="time_total")] 
    public int TimeTotal { get; set; } 

    [XmlElement(ElementName="fuel_flow")] 
    public int FuelFlow { get; set; } 

    [XmlElement(ElementName="fuel_leg")] 
    public int FuelLeg { get; set; } 

    [XmlElement(ElementName="fuel_totalused")] 
    public int FuelTotalused { get; set; } 

    [XmlElement(ElementName="fuel_min_onboard")] 
    public int FuelMinOnboard { get; set; } 

    [XmlElement(ElementName="fuel_plan_onboard")] 
    public int FuelPlanOnboard { get; set; } 

    [XmlElement(ElementName="oat")] 
    public int Oat { get; set; } 

    [XmlElement(ElementName="oat_isa_dev")] 
    public int OatIsaDev { get; set; } 

    [XmlElement(ElementName="wind_dir")] 
    public int WindDir { get; set; } 

    [XmlElement(ElementName="wind_spd")] 
    public int WindSpd { get; set; } 

    [XmlElement(ElementName="shear")] 
    public int Shear { get; set; } 

    [XmlElement(ElementName="tropopause_feet")] 
    public int TropopauseFeet { get; set; } 

    [XmlElement(ElementName="ground_height")] 
    public int GroundHeight { get; set; } 

    [XmlElement(ElementName="fir")] 
    public string Fir { get; set; } 

    [XmlElement(ElementName="fir_units")] 
    public string FirUnits { get; set; } 

    [XmlElement(ElementName="fir_valid_levels")] 
    public string FirValidLevels { get; set; } 

    [XmlElement(ElementName="mora")] 
    public int Mora { get; set; } 

    [XmlElement(ElementName="wind_data")] 
    public WindData WindData { get; set; } 

    [XmlElement(ElementName="fir_crossing")] 
    public object FirCrossing { get; set; } 
}