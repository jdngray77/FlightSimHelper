using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="fetch")]
public class Fetch { 

	[XmlElement(ElementName="userid")] 
	public int Userid { get; set; } 

	[XmlElement(ElementName="static_id")] 
	public object StaticId { get; set; } 

	[XmlElement(ElementName="status")] 
	public string Status { get; set; } 

	[XmlElement(ElementName="time")] 
	public double Time { get; set; } 
}