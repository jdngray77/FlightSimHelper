using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="fuel")]
public class Fuel { 

    [XmlElement(ElementName="taxi")] 
    public int Taxi { get; set; } 

    [XmlElement(ElementName="enroute_burn")] 
    public int EnrouteBurn { get; set; } 

    [XmlElement(ElementName="contingency")] 
    public int Contingency { get; set; } 

    [XmlElement(ElementName="alternate_burn")] 
    public int AlternateBurn { get; set; } 

    [XmlElement(ElementName="reserve")] 
    public int Reserve { get; set; } 

    [XmlElement(ElementName="etops")] 
    public int Etops { get; set; } 

    [XmlElement(ElementName="extra")] 
    public int Extra { get; set; } 

    [XmlElement(ElementName="extra_required")] 
    public int ExtraRequired { get; set; } 

    [XmlElement(ElementName="extra_optional")] 
    public int ExtraOptional { get; set; } 

    [XmlElement(ElementName="min_takeoff")] 
    public int MinTakeoff { get; set; } 

    [XmlElement(ElementName="plan_takeoff")] 
    public int PlanTakeoff { get; set; } 

    [XmlElement(ElementName="plan_ramp")] 
    public int PlanRamp { get; set; } 

    [XmlElement(ElementName="plan_landing")] 
    public int PlanLanding { get; set; } 

    [XmlElement(ElementName="avg_fuel_flow")] 
    public int AvgFuelFlow { get; set; } 

    [XmlElement(ElementName="max_tanks")] 
    public int MaxTanks { get; set; } 
}