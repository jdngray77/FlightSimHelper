using Spectre.Console.Rendering;

namespace MSFSHelper.Views
{
    public interface IView
    {
        Renderable RenderableView { get; }
    }
}