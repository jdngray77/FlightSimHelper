using Spectre.Console;

namespace MSFSHelper.NewViews
{

    /// <summary>
    /// Primary manager for displaying stuff on screen,
    /// should be used instead of directly writing stuff
    /// to the console.
    /// </summary>
    public class ConsoleScreen
    {
        public static ConsoleScreen Current;

        /// <summary>
        /// The screen that will be displayed when no other screen is
        /// displayed.
        /// </summary>
        public View DefaultScreen { get; private init; }

        /// <summary>
        /// The current screen to display.
        /// 
        /// If is none, returns DefaultScreen.
        /// </summary>
        public View CurrentScreen 
        {
            get
            {
                return viewStack.Any() ? viewStack.Last() : DefaultScreen;
            }
        }

        private List<View> viewStack = new List<View>();

        public ConsoleScreen(View defaultScreen)
        {
            DefaultScreen = defaultScreen;
            Current = this;
        }

        /// <summary>
        /// Replaces the current screen, and removes all
        /// screens from the stack.
        /// </summary>
        public async Task SetScreen(View screen)
        {
            if (screen == CurrentScreen)
            {
                return;
            }

            View old = CurrentScreen;
            ClearStack();
            viewStack.Add(screen);
            Render();
            await OnScreenChanged(old, CurrentScreen).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a screen to the view stack, and displays it.
        /// 
        /// Removing the screen from the stack, or popping,
        /// will display the screen that was present prior to
        /// this screen being added.
        /// </summary>
        public async Task AddScreen(View screen)
        {
            if (screen == CurrentScreen)
            {
                return;
            }

            View old = CurrentScreen;
            viewStack.Add(screen);
            Render();
            await OnScreenChanged(old, CurrentScreen).ConfigureAwait(false);
        }

        /// <summary>
        /// Pops the topmost screen off of the view stack and
        /// returns to the screen that was displayed previously.
        /// </summary>
        public async Task Pop()
        {
            if (!viewStack.Any()) 
            {
                return;
            }

            View old = CurrentScreen;
            viewStack.Remove(viewStack.Last());
            Render();
            await OnScreenChanged(old, CurrentScreen).ConfigureAwait(false);
        }

        /// <summary>
        /// Pops all screens from the view stack, and
        /// displays the default screen.
        /// </summary>
        public async Task PopToDefault()
        {
            if (!viewStack.Any())
            {
                return;
            }


            View old = CurrentScreen;
            ClearStack();
            Render();
            await OnScreenChanged(old, CurrentScreen).ConfigureAwait(false);
        }

        private void ClearStack()
        {
            viewStack.Clear();
        }

        /// <summary>
        /// Re-renders all UI.
        /// Use sparingly, only when changes in UI are needed.
        /// </summary>
        public void Render()
        {
            AnsiConsole.Clear();
            CurrentScreen.Render();
        }

        private async Task OnScreenChanged(View oldScreen, View currentScreen)
        {
            await oldScreen.OnNoLongerShown().ConfigureAwait(false);
            await currentScreen.OnShown().ConfigureAwait(false);
        }
    }
}
