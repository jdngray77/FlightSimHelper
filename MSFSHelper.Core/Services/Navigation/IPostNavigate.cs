namespace MSFSHelper.Core.Services.Navigation
{
    public interface IPostNavigate
    {
        Task AfterNavigatingTo(Dictionary<string, object> data);
    }
}
