using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="higher_ci")]
public class HigherCi { 

    [XmlElement(ElementName="time_enroute")] 
    public int TimeEnroute { get; set; } 

    [XmlElement(ElementName="time_difference")] 
    public int TimeDifference { get; set; } 

    [XmlElement(ElementName="enroute_burn")] 
    public int EnrouteBurn { get; set; } 

    [XmlElement(ElementName="burn_difference")] 
    public int BurnDifference { get; set; } 

    [XmlElement(ElementName="ramp_fuel")] 
    public int RampFuel { get; set; } 

    [XmlElement(ElementName="initial_fl")] 
    public int InitialFl { get; set; } 

    [XmlElement(ElementName="initial_tas")] 
    public int InitialTas { get; set; } 

    [XmlElement(ElementName="initial_mach")] 
    public double InitialMach { get; set; } 

    [XmlElement(ElementName="cost_index")] 
    public int CostIndex { get; set; } 
}