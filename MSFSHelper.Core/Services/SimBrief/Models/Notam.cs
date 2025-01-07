using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="notam")]
public class Notam { 

    [XmlElement(ElementName="source_id")] 
    public string SourceId { get; set; } 

    [XmlElement(ElementName="account_id")] 
    public string AccountId { get; set; } 

    [XmlElement(ElementName="notam_id")] 
    public string NotamId { get; set; } 

    [XmlElement(ElementName="location_id")] 
    public string LocationId { get; set; } 

    [XmlElement(ElementName="location_icao")] 
    public string LocationIcao { get; set; } 

    [XmlElement(ElementName="location_name")] 
    public string LocationName { get; set; } 

    [XmlElement(ElementName="location_type")] 
    public string LocationType { get; set; } 

    [XmlElement(ElementName="date_created")] 
    public string DateCreated { get; set; } 

    [XmlElement(ElementName="date_effective")] 
    public string DateEffective { get; set; } 

    [XmlElement(ElementName="date_expire")] 
    public string DateExpire { get; set; } 

    [XmlElement(ElementName="date_expire_is_estimated")] 
    public object DateExpireIsEstimated { get; set; } 

    [XmlElement(ElementName="date_modified")] 
    public string DateModified { get; set; } 

    [XmlElement(ElementName="notam_schedule")] 
    public object NotamSchedule { get; set; } 

    [XmlElement(ElementName="notam_html")] 
    public string NotamHtml { get; set; } 

    [XmlElement(ElementName="notam_text")] 
    public string NotamText { get; set; } 

    [XmlElement(ElementName="notam_raw")] 
    public string NotamRaw { get; set; } 

    [XmlElement(ElementName="notam_nrc")] 
    public string NotamNrc { get; set; } 

    [XmlElement(ElementName="notam_qcode")] 
    public string NotamQcode { get; set; } 

    [XmlElement(ElementName="notam_qcode_category")] 
    public string NotamQcodeCategory { get; set; } 

    [XmlElement(ElementName="notam_qcode_subject")] 
    public string NotamQcodeSubject { get; set; } 

    [XmlElement(ElementName="notam_qcode_status")] 
    public string NotamQcodeStatus { get; set; } 

    [XmlElement(ElementName="notam_is_obstacle")] 
    public object NotamIsObstacle { get; set; } 
}