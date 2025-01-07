using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="distance_dry")]
public class DistanceDry { 

    [XmlElement(ElementName="weight")] 
    public int Weight { get; set; } 

    [XmlElement(ElementName="flap_setting")] 
    public string FlapSetting { get; set; } 

    [XmlElement(ElementName="brake_setting")] 
    public string BrakeSetting { get; set; } 

    [XmlElement(ElementName="reverser_credit")] 
    public string ReverserCredit { get; set; } 

    [XmlElement(ElementName="speeds_vref")] 
    public int SpeedsVref { get; set; } 

    [XmlElement(ElementName="actual_distance")] 
    public int ActualDistance { get; set; } 

    [XmlElement(ElementName="factored_distance")] 
    public int FactoredDistance { get; set; } 
}