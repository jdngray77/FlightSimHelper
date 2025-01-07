using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MSFSHelper.Core.Services.SimBrief;
using MSFSHelper.Core.SimBrief.Models;

namespace MSFSHelper.Core.ViewModels.Plan
{
    [ObservableObject]
    public partial class OFPViewModel : IRecipient<OFP>
    {
        [ObservableProperty]
        private OFP oFP;

        public OFPViewModel(IMessenger messenger, SimBriefService simBrief)
        {
            messenger.Register<OFP>(this);
        }

        public void Receive(OFP message)
        {
            this.OFP = message;
        }
    }
}
