
namespace MSFSHelper.NewViews
{
    public abstract class View
    {
        public virtual Task OnWillShow() { return Task.CompletedTask; }
        public virtual Task OnWillUnshow() { return Task.CompletedTask; }

        public abstract Task Render();
    }
}
