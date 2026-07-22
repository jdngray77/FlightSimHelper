namespace MSFSHelper.Core.Services.Navigation
{
    public interface INavigateTo
    {
        Task AfterNavigatingTo(Dictionary<string, object> data);
    }
}
