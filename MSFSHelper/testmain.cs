using System.Xml.Serialization;
using MSFSHelper.Core.SimBrief.Models;

namespace MSFSHelper;

public class testmain
{
    public static OFP test()
    {
        HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("https://www.simbrief.com"),
        };

        var x = sharedClient.GetAsync("api/xml.fetcher.php?username=shinkson47").Result;
        var xml = x.Content.ReadAsStringAsync().Result;
        
        XmlSerializer serializer = new XmlSerializer(typeof(OFP));
        
        using (StringReader reader = new StringReader(xml))
        {
            var test = (OFP)serializer.Deserialize(reader);
            return test;
        }
    }
}