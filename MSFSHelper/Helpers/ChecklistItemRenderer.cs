using MSFSHelper.Core.Checklists.ChecklistItems;
using Spectre.Console;

namespace MSFSHelper.ViewHelpers
{
    public class ChecklistItemRenderer
    {
        public Markup StyleText(
            string text,
            ChecklistEntry checklistItem,
            bool isUserHighlighted)
        {
            Style style = Style.Plain;

            if (checklistItem is InformationalChecklistItem)
            {

            }
            else if (checklistItem is StateMonitorChecklistItem smc)
            {
                Color c = smc.State == ChecklistItemState.Checked ?
                    isUserHighlighted ? Color.Green1 : Color.Green4
                    :
                    isUserHighlighted ? Color.Red1 : Color.DarkRed;

                style = new Style(foreground: c);
            }
            else
            {

            }

            return new Markup(text, style);
        }
    }
}
