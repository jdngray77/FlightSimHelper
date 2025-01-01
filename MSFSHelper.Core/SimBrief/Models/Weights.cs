using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="weights")]
public class Weights { 

    [XmlElement(ElementName="oew")] 
    public int Oew { get; set; } 

    [XmlElement(ElementName="pax_count")] 
    public int PaxCount { get; set; } 

    [XmlElement(ElementName="bag_count")] 
    public int BagCount { get; set; } 

    [XmlElement(ElementName="pax_count_actual")] 
    public int PaxCountActual { get; set; } 

    [XmlElement(ElementName="bag_count_actual")] 
    public int BagCountActual { get; set; } 

    [XmlElement(ElementName="pax_weight")] 
    public int PaxWeight { get; set; } 

    [XmlElement(ElementName="bag_weight")] 
    public int BagWeight { get; set; } 

    [XmlElement(ElementName="freight_added")] 
    public int FreightAdded { get; set; } 

    [XmlElement(ElementName="cargo")] 
    public int Cargo { get; set; } 

    [XmlElement(ElementName="payload")] 
    public int Payload { get; set; } 

    [XmlElement(ElementName="est_zfw")] 
    public int EstZfw { get; set; } 

    [XmlElement(ElementName="max_zfw")] 
    public int MaxZfw { get; set; } 

    [XmlElement(ElementName="est_tow")] 
    public int EstTow { get; set; } 

    [XmlElement(ElementName="max_tow")] 
    public int MaxTow { get; set; } 

    [XmlElement(ElementName="max_tow_struct")] 
    public int MaxTowStruct { get; set; } 

    [XmlElement(ElementName="tow_limit_code")] 
    public string TowLimitCode { get; set; } 

    [XmlElement(ElementName="est_ldw")] 
    public int EstLdw { get; set; } 

    [XmlElement(ElementName="max_ldw")] 
    public int MaxLdw { get; set; } 

    [XmlElement(ElementName="est_ramp")] 
    public int EstRamp { get; set; } 
}