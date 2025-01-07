using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="aircraft")]
public class Aircraft { 

    [XmlElement(ElementName="icaocode")] 
    public string Icaocode { get; set; } 

    [XmlElement(ElementName="iatacode")] 
    public object Iatacode { get; set; } 

    [XmlElement(ElementName="base_type")] 
    public string BaseType { get; set; } 

    [XmlElement(ElementName="icao_code")] 
    public string IcaoCode { get; set; } 

    [XmlElement(ElementName="iata_code")] 
    public object IataCode { get; set; } 

    [XmlElement(ElementName="name")] 
    public string Name { get; set; } 

    [XmlElement(ElementName="reg")] 
    public string Reg { get; set; } 

    [XmlElement(ElementName="fin")] 
    public object Fin { get; set; } 

    [XmlElement(ElementName="selcal")] 
    public string Selcal { get; set; } 

    [XmlElement(ElementName="equip")] 
    public string Equip { get; set; } 

    [XmlElement(ElementName="fuelfact")] 
    public int Fuelfact { get; set; } 

    [XmlElement(ElementName="fuelfactor")] 
    public int Fuelfactor { get; set; } 

    [XmlElement(ElementName="max_passengers")] 
    public int MaxPassengers { get; set; } 

    [XmlElement(ElementName="supports_tlr")] 
    public int SupportsTlr { get; set; } 

    [XmlElement(ElementName="internal_id")] 
    public string InternalId { get; set; } 

    [XmlElement(ElementName="is_custom")] 
    public int IsCustom { get; set; } 
}