using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="notamdrec")]
public class Notamdrec { 

    [XmlElement(ElementName="source_id")] 
    public string SourceId { get; set; } 

    [XmlElement(ElementName="account_id")] 
    public string AccountId { get; set; } 

    [XmlElement(ElementName="notam_id")] 
    public string NotamId { get; set; } 

    [XmlElement(ElementName="notam_part")] 
    public int NotamPart { get; set; } 

    [XmlElement(ElementName="cns_location_id")] 
    public string CnsLocationId { get; set; } 

    [XmlElement(ElementName="icao_id")] 
    public string IcaoId { get; set; } 

    [XmlElement(ElementName="icao_name")] 
    public string IcaoName { get; set; } 

    [XmlElement(ElementName="total_parts")] 
    public int TotalParts { get; set; } 

    [XmlElement(ElementName="notam_created_dtg")] 
    public double NotamCreatedDtg { get; set; } 

    [XmlElement(ElementName="notam_effective_dtg")] 
    public double NotamEffectiveDtg { get; set; } 

    [XmlElement(ElementName="notam_expire_dtg")] 
    public double NotamExpireDtg { get; set; } 

    [XmlElement(ElementName="notam_lastmod_dtg")] 
    public double NotamLastmodDtg { get; set; } 

    [XmlElement(ElementName="notam_inserted_dtg")] 
    public double NotamInsertedDtg { get; set; } 

    [XmlElement(ElementName="notam_text")] 
    public string NotamText { get; set; } 

    [XmlElement(ElementName="notam_report")] 
    public string NotamReport { get; set; } 

    [XmlElement(ElementName="notam_nrc")] 
    public string NotamNrc { get; set; } 

    [XmlElement(ElementName="notam_qcode")] 
    public string NotamQcode { get; set; } 
}