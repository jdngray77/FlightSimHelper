using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="files")]
public class Files { 

    [XmlElement(ElementName="directory")] 
    public string Directory { get; set; } 

    [XmlElement(ElementName="pdf")] 
    public Pdf Pdf { get; set; } 

    [XmlElement(ElementName="file")] 
    public List<File> File { get; set; } 
}