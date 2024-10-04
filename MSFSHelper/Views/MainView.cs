using Spectre.Console;
using Spectre.Console.Rendering;

namespace MSFSHelper.Views
{
    internal class MainView : View
    {
        private Layout DetailsPane()
        {
            return new Layout("Left");
        }

        private static Layout ProgramPane()
        {
            return new Layout("Right");
        }

        protected override Renderable BuildView()
        {
            return new Table();
        }
    }
}
