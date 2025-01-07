using MSFSHelper.Core.Services.Navigation;

namespace MSFSHelper.Core.ViewModels
{
    public class MarkupMenuItemViewModel : MenuItemViewModel
    {
        public string MarkupViewPath { get; set; }
        public Func<Task<string>> MarkupDataSource { get; set; }


        public MarkupMenuItemViewModel(
            string markupViewName,
            Func<Task<string>> markupDataSource,
            string name)
            : base(name, ERoutes.MarkupView)
        {
            this.MarkupViewPath = markupViewName;
            this.MarkupDataSource = markupDataSource;
        }
    }
}
