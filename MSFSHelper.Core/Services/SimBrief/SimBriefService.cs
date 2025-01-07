using CommunityToolkit.Mvvm.Messaging;
using MSFSHelper.Core.Messages;
using MSFSHelper.Core.SimBrief.Models;
using System.Xml;

namespace MSFSHelper.Core.Services.SimBrief
{
    public sealed class SimBriefService
    {
        // TODO make configurable
        private const string url = "https://www.simbrief.com/api/xml.fetcher.php?username={0}";

        private readonly IMessenger messenger;

        private OFP? CachedFlightPlan = null;

        private string? CachedFlightPlanRaw = null;

        public SimBriefService(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void InvalidateFlightPlanCache()
        {
            CachedFlightPlan = null;
        }

        public async Task<OFP> GetFlightPlan(string userid, bool forceFetch = false)
        {
            if (CachedFlightPlan != null && !forceFetch)
            {
                return CachedFlightPlan;
            }

            var x = await FetchFlightPlanFromRemote(userid);
            CachedFlightPlan = x.Item1;
            CachedFlightPlanRaw = x.Item2;
            return CachedFlightPlan;
        }

        public async Task<string> GetFlightPlanXml(string userid, bool forceFetch = false)
        {
            if (string.IsNullOrEmpty(CachedFlightPlanRaw) && !forceFetch)
            {
                return CachedFlightPlanRaw!;
            }


            await GetFlightPlan(userid, forceFetch);
            return CachedFlightPlanRaw!;
        }

        private async Task<(OFP, string)> FetchFlightPlanFromRemote(string userid)
        {
            using (HttpClient client = new HttpClient())
            {
                // Make the HTTP GET request
                string uri = string.Format(url, userid);
                HttpResponseMessage response = await client.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    string serverMessage = string.Empty;
                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(await response.Content.ReadAsStringAsync());
                        serverMessage = xmlDoc.SelectSingleNode("//OFP/fetch/status")?.InnerText;
                    }
                    catch (Exception)
                    {
                        // ignored.
                    }

                    messenger.Send(new AppStatusMessage($"Failed to obtain flight plan!\n"+
                                    $"{serverMessage}"));
                }

                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                string xmlContent = await response.Content.ReadAsStringAsync();

                // Deserialize
                OFP data = Serialization.Serialization.DeserializeFromXml<OFP>(xmlContent);

                messenger.Send(new AppStatusMessage($"Obtained Flight Plan {Environment.NewLine}" +
                                                    $"'{data.ApiParams.Orig}' -> '{data.ApiParams.Dest}'\n" +
                                                    $"{data.ApiParams.Cpt}"));

                return (data, xmlContent);
            }
        }
    }
}
