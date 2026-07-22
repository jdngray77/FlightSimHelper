using CommunityToolkit.Mvvm.ComponentModel;
using MSFSHelper.Core.Services.ViewMarkup;

namespace MSFSHelper.Core.ViewModels
{
    [ObservableObject]
    public partial class MarkupViewViewModel
    {
        private readonly MarkupRenderer markupRenderer;

        public MarkupViewViewModel(MarkupRenderer markupRenderer)
        {
            this.markupRenderer = markupRenderer;
        }

        [ObservableProperty]
        private string text;

        public async Task Render(string viewPath, Func<Task<String>> lazyData)
        {
            var viewMarkup = await File.ReadAllTextAsync(viewPath).ConfigureAwait(false);
            var data = File.ReadAllText("./dummySimBriefData.xml"); //await lazyData().ConfigureAwait(false);

            var DataSource = new XmlDataSource(data);
            Text = markupRenderer.Render(viewMarkup, DataSource);
        }
    }
}
