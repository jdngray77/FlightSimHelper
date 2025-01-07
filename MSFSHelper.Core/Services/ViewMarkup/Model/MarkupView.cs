using System.Xml.Serialization;

namespace MSFSHelper.Core.Services.ViewMarkup.Model
{
    /// <summary>
    /// Root markup document.
    /// </summary>
    [XmlRoot("View")]
    public class MarkupView : Parent
    {
        [XmlAttribute]
        public string Renderer = "OFP";
    }

    /// <summary>
    /// Any element contained within the markup.
    /// </summary>
    public abstract class ViewElement
    {
    }

    /// <summary>
    /// An object which has children.
    /// </summary>
    public abstract class Parent : ViewElement
    {
        [XmlElement("h1", typeof(H1))]
        [XmlElement("h2", typeof(H2))]
        [XmlElement("h3", typeof(H3))]
        [XmlElement("Vertical", typeof(Vertical))]
        [XmlElement("p", typeof(Paragraph))]
        public List<ViewElement> Children { get; set; } = new List<ViewElement>();
    }

    /// <summary>
    /// An object used to display flight plan information
    /// </summary>
    public abstract class XmlDataView : ViewElement
    {
        [XmlText]
        public string Content {  get; set; }

        /// <summary>
        /// Comma delimited list of xml paths for data injection.
        /// </summary>
        [XmlAttribute]
        public string Paths { get; set; }

        [XmlAttribute]
        public string Path { get; set; }

        public string GetPaths()
        {
            return String.Join(",", Paths, Path);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("View")]
    public class View : Parent
    {
    }

    [XmlRoot("H1")]
    public class H1 : XmlDataView
    {
    }

    [XmlRoot("H2")]
    public class H2 : XmlDataView
    {
    }

    [XmlRoot("H3")]
    public class H3 : XmlDataView
    {
    }

    [XmlRoot("P")]
    public class Paragraph : XmlDataView
    {
    }

    [XmlRoot("Vertical")]
    public class Vertical : Parent
    {
    }

    // TODO list, border
}
