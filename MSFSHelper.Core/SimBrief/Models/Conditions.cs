using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="conditions")]
public class Conditions { 

    [XmlElement(ElementName="airport_icao")] 
    public string AirportIcao { get; set; } 

    [XmlElement(ElementName="planned_runway")] 
    public string PlannedRunway { get; set; } 

    [XmlElement(ElementName="planned_weight")] 
    public int PlannedWeight { get; set; } 

    [XmlElement(ElementName="wind_direction")] 
    public int WindDirection { get; set; } 

    [XmlElement(ElementName="wind_speed")] 
    public int WindSpeed { get; set; } 

    [XmlElement(ElementName="temperature")] 
    public int Temperature { get; set; } 

    [XmlElement(ElementName="altimeter")] 
    public double Altimeter { get; set; } 

    [XmlElement(ElementName="surface_condition")] 
    public string SurfaceCondition { get; set; } 

    [XmlElement(ElementName="flap_setting")] 
    public string FlapSetting { get; set; } 
}