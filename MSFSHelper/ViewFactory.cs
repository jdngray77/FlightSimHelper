using Avalonia;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using MSFSHelper.Core.Services.Navigation;
using MSFSHelper.Core.Services.ViewMarkup.Model;
using MSFSHelper.Views.Consolonia;

namespace MSFSHelper
{
    internal class ViewFactory
    {
        private readonly Dictionary<ERoutes, Lazy<Control>> Views;

        private IServiceProvider serviceProvider = ConsoloniaApp.Current!.DI;

        public ViewFactory()
        {
            Views = new Dictionary<ERoutes, Lazy<Control>>
            {
                { ERoutes.MarkupView, new Lazy<Control>(LoadView<Views.Consolonia.MarkupView>) },
            };
        }

        public Control GetView(ERoutes route)
        {
            if (!Views.ContainsKey(route))
            {
                throw new Exception($"No view for route '{route}'");
            }

            return Views.GetValueOrDefault(route)!.Value;
        }

        private Control LoadView<T>()
            where T : Control 
        {
            return serviceProvider.GetRequiredService<T>();
        }

    }
}
