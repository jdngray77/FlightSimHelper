using CommunityToolkit.Mvvm.Messaging;
using Figgle;
using MSFSHelper.Core.Messages;
using MSFSHelper.Core.Services.ViewMarkup.Model;
using MSFSHelper.Core.SimBrief.Models;
using System;
using System.Text;

namespace MSFSHelper.Core.Services.ViewMarkup
{
    public class MarkupRenderer
    {
        private IDataSource dataSource;
        private IMessenger messenger;

        public MarkupRenderer(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public string Render(string xmlView, IDataSource dataSource)
        {
            return Render(Serialization.Serialization.DeserializeFromXml<MarkupView>(xmlView), dataSource);
        }

        public string Render(MarkupView view, IDataSource dataSource)
        {
            this.dataSource = dataSource;

            var builder = new StringBuilder();
            RenderElement(view, builder, 0);
            return builder.ToString();
        }

        private void RenderElement(ViewElement element, StringBuilder builder, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);

            switch (element)
            {
                case Parent parent:
                    RenderParent(parent, builder, indentLevel);
                    break;

                case XmlDataView dataView:
                    RenderDataView(dataView, builder, indentLevel);
                    break;

                default:
                    break;
            }
        }

        private void RenderParent(Parent element, StringBuilder builder, int indentLevel)
        {
            foreach (var child in element.Children)
            {
                RenderElement(child, builder, indentLevel + 1);
            }
        }

        private void RenderDataView(XmlDataView element, StringBuilder builder, int indentLevel) 
        {
            string indent = new string(' ', indentLevel * 2);

            string[] data = null;
            string? paths = element.GetPaths();
            if (!string.IsNullOrEmpty(paths))
            {
                string[] pathArray = paths.Split(",").Where(it => !string.IsNullOrWhiteSpace(it)).ToArray();
                data = pathArray.Select(p => dataSource.GetString(p)).ToArray();
            }

            string unrenderedContent;

            FALLBACK:
            if ((data != null || data.Length == 0) && !string.IsNullOrEmpty(element.Content))
            {
                try
                {
                    unrenderedContent = string.Format(element.Content, data);
                } catch (Exception e)
                {
                    messenger.Send(new AppStatusMessage($"Data injection for view element failed: '{element.Content}'"));
                    goto FALLBACK;
                }
            } 
            else if (!string.IsNullOrEmpty(element.Content))
            {
                unrenderedContent = element.Content;
            } 
            else if (data != null)
            {
                unrenderedContent = String.Join(", ", data);
            }
            else
            {
                // No content to render.
                return;
            }

            switch (element)
            {   // TODO attrib to allow choosing of font?
                // TODO allow multiple colums / table?
                // TODO text justification left/right
                case H1 h1:
                    builder.AppendLine(FiggleFonts.Roman.Render(unrenderedContent));
                    break;

                case H2 h2:
                    builder.AppendLine(FiggleFonts.Doom.Render(unrenderedContent));
                    break;

                case H3 h3:
                    builder.AppendLine(FiggleFonts.Straight.Render(unrenderedContent));
                    break;

                case Paragraph paragraph:
                    builder.AppendLine(unrenderedContent);
                    break;
            }
        }
    }
}