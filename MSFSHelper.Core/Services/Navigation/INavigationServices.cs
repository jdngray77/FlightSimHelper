namespace MSFSHelper.Core.Services.Navigation
{
    public interface INavigationServices
    {
        public Task GotoAsync(ERoutes route, Dictionary<string, object>? data = null);
    }
}
