using System.Xml;

namespace MSFSHelper.Core.Services.ViewMarkup
{
    public class XmlDataSource : IDataSource
    {
        private readonly string xmlData;

        private readonly XmlDocument document;

        public XmlDataSource(string xmlData)
        {
            this.xmlData = xmlData;

            document = new XmlDocument();
            document.LoadXml(xmlData);
        }

        public string GetString(string path)
        {
            var node = document.SelectSingleNode(path);
            return node?.InnerText ?? string.Empty;
        }
    }
}
