using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="params")]
public class Params { 

    [XmlElement(ElementName="request_id")] 
    public int RequestId { get; set; } 

    [XmlElement(ElementName="sequence_id")] 
    public string SequenceId { get; set; } 

    [XmlElement(ElementName="static_id")] 
    public object StaticId { get; set; } 

    [XmlElement(ElementName="user_id")] 
    public int UserId { get; set; } 

    [XmlElement(ElementName="time_generated")] 
    public int TimeGenerated { get; set; } 

    [XmlElement(ElementName="xml_file")] 
    public string XmlFile { get; set; } 

    [XmlElement(ElementName="ofp_layout")] 
    public string OfpLayout { get; set; } 

    [XmlElement(ElementName="airac")] 
    public int Airac { get; set; } 

    [XmlElement(ElementName="units")] 
    public string Units { get; set; } 
}