
namespace MSFSHelper.NewViews
{
    public abstract class View
    {
        public virtual Task OnShown() { return Task.CompletedTask; }
        public virtual Task OnNoLongerShown() { return Task.CompletedTask; }

        public abstract Task Render();
    }
}
