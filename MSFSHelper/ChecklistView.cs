using MSFSHelper.Core;
using MSFSHelper.Core.Checklists;
using Spectre.Console;

namespace MSFSHelper
{
    internal class ChecklistView
    {
        const int maxItems = 13;
        private static ChecklistItemRenderer renderer = new ChecklistItemRenderer();

        public static void RenderChecklist(Checklist checklist)
        {
            AnsiConsole.Clear();

            Table table = new Table();
            table.AddColumn("Name")
                .AddColumn("Action")
                .AddColumn("Complete");

            var next = checklist.IsComplete ? checklist.Items.Last() : checklist.Next();
            int nonEndIndex = Math.Max(0, checklist.Items.IndexOf(next) - (maxItems / 2));
            int fromIndex = Math.Min(nonEndIndex, ((checklist.Items.Count) - maxItems));

            // Limit number taken so it does not over run the end of the array
            int items = Math.Min(checklist.Items.Count - fromIndex, maxItems);

            if (fromIndex > 0)
            {
                table.AddRow("...", "...", "...");
                fromIndex++;
            }

            if (fromIndex < checklist.Items.Count - maxItems)
            {
                items--;
            }

            foreach (var item in checklist.Items.Take(fromIndex .. (fromIndex + items)))
            {
                Color color;
                string stateString;
                bool isActive = item == next;

                //if (item.State == Core.Checklists.ChecklistItems.ChecklistItemState.Uncheckable)
                //{
                //    color = item.Check ? Color.Orange3 : Color.White;
                //    stateString = item.Check ? "CHECK" : string.Empty;
                //}
                //else
                //{
                //    color = item.ConditionMet.Value ? Color.Green4 : Color.DarkRed;
                //    stateString = item.ConditionMet.Value ? "✓" : "X";
                //}

                table.AddRow(
                    renderer.StyleText((isActive ? "> " : string.Empty) + item.Name, item, isActive),
                    renderer.StyleText(item.Action, item, isActive),
                    renderer.StyleText(item.State.ToString(), item, isActive));

                    // StyleRow(isActive, item, color, (isActive & !item.ConditionMet == true ? "> " : string.Empty) + item.name),
                    // StyleRow(isActive, item, color, item.action),
                    // StyleRow(isActive, item, color, stateString));
            }

            if (fromIndex < checklist.Items.Count - maxItems)
            {
                table.AddRow("...", "...", "...");
            }
            else
            {
                Color color = checklist.IsComplete ? Color.Green1 : Color.Green4;
                table.AddRow($"[bold {color.ToMarkup()} underline]END[/]", $"[bold {color.ToMarkup()} underline]✓✓✓[/]", $"[bold {color.ToMarkup()} underline]✓✓✓[/]");
            }


            string StyleRow(bool isActive, ChecklistItem item, Color color, string row)
            {
                return (isActive & !item.ConditionMet == true ? $"[red1 underline]" : $"[{color.ToMarkup()}]") + row + "[/]";
            }

            AnsiConsole.Write(table);

            //var nextItem = checklist.Next();

            //if (nextItem == null || nextItem.NoAutoUpdate)
            //{
            //    return;
            //}

            //AnsiConsole.Status()
            //    .StartAsync($"Next : {nextItem.name} .. {nextItem.action}", async ctx =>
            //    {
            //        // Update the status and spinner
            //        ctx.Spinner(Spinner.Known.SimpleDots);
            //        ctx.SpinnerStyle(Style.Parse("orange1"));

            //        while (!nextItem.ConditionMet!.Value)
            //        {
            //            await Task.Delay(1000).ConfigureAwait(false);
            //        }
            //    });


        }
    }
}
