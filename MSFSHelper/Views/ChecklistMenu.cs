using MSFSHelper.Core.Checklists;
using Spectre.Console;

namespace MSFSHelper.NewViews
{
    /// <summary>
    /// Shows a prompt where a user can select between many checklists.
    /// </summary>
    internal class ChecklistMenu : View
    {
        public List<Checklist> checklists;

        public ChecklistMenu(List<Checklist> checklists)
        {
            this.checklists = checklists;
        }

        public ChecklistMenu(params Checklist[] checklists)
        {
            this.checklists = checklists.ToList();
        }

        public override async Task Render()
        {
            var prompt = new SelectionPrompt<Checklist>()
             {
                Converter = it => it.Name
            };

            prompt
                .EnableSearch()
                .Title("Choose a Checklist")
                .PageSize(10)
                .AddChoices(checklists);

            Checklist list = AnsiConsole.Prompt(prompt);

            await AnsiConsole.Status()
                .Spinner(ConsoleScreen.GetSpinner())
                .StartAsync(ConsoleScreen.GetStatusText(),
                async ctx =>
                {
                    await ConsoleScreen.Current.AddScreen(new ChecklistView(list));
                }).ConfigureAwait(false);
        }
    }
}
