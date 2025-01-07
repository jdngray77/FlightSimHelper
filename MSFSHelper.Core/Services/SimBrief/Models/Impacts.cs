using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="impacts")]
public class Impacts { 

    [XmlElement(ElementName="minus_6000ft")] 
    public Minus6000ft Minus6000ft { get; set; } 

    [XmlElement(ElementName="minus_4000ft")] 
    public Minus4000ft Minus4000ft { get; set; } 

    [XmlElement(ElementName="minus_2000ft")] 
    public Minus2000ft Minus2000ft { get; set; } 

    [XmlElement(ElementName="plus_2000ft")] 
    public object Plus2000ft { get; set; } 

    [XmlElement(ElementName="plus_4000ft")] 
    public object Plus4000ft { get; set; } 

    [XmlElement(ElementName="plus_6000ft")] 
    public object Plus6000ft { get; set; } 

    [XmlElement(ElementName="higher_ci")] 
    public HigherCi HigherCi { get; set; } 

    [XmlElement(ElementName="lower_ci")] 
    public LowerCi LowerCi { get; set; } 

    [XmlElement(ElementName="zfw_plus_1000")] 
    public ZfwPlus1000 ZfwPlus1000 { get; set; } 

    [XmlElement(ElementName="zfw_minus_1000")] 
    public ZfwMinus1000 ZfwMinus1000 { get; set; } 
}