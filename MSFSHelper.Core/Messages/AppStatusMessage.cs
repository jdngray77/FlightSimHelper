using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MSFSHelper.Core.Messages
{
    internal class AppStatusMessage : ValueChangedMessage<string>
    {
        public AppStatusMessage(string value) : base(value)
        {
        }
    }
}