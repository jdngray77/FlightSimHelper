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

        public static readonly IReadOnlyList<Spinner> spinners = new List<Spinner>()
        {
            Spinner.Known.Default,
            Spinner.Known.Ascii,
            Spinner.Known.Dots,
            Spinner.Known.Dots2,
            Spinner.Known.Dots3,
            Spinner.Known.Dots4,
            Spinner.Known.Dots5,
            Spinner.Known.Dots6,
            Spinner.Known.Dots7,
            Spinner.Known.Dots8,
            Spinner.Known.Dots9,
            Spinner.Known.Dots10,
            Spinner.Known.Dots11,
            Spinner.Known.Dots12,
            Spinner.Known.Dots8Bit,
            Spinner.Known.Line,
            Spinner.Known.Line2,
            Spinner.Known.Pipe,
            Spinner.Known.SimpleDots,
            Spinner.Known.SimpleDotsScrolling,
            Spinner.Known.Flip,
            Spinner.Known.Hamburger,
            Spinner.Known.Bounce,
            Spinner.Known.Triangle,
            Spinner.Known.Arc,
            Spinner.Known.SquareCorners,
            Spinner.Known.CircleQuarters,
            Spinner.Known.CircleHalves,
            Spinner.Known.Squish,
            Spinner.Known.Arrow,
            Spinner.Known.Arrow2,
            Spinner.Known.Arrow3,
            Spinner.Known.BouncingBar,
            Spinner.Known.BouncingBall,
            Spinner.Known.Material,
            Spinner.Known.Pong,
            Spinner.Known.Shark,
            Spinner.Known.Dqpb,
            Spinner.Known.Grenade,
            Spinner.Known.Point,
            Spinner.Known.Layer,
            Spinner.Known.BetaWave,
            Spinner.Known.Aesthetic
        };

        public static readonly IReadOnlyList<string> spinnerText = new List<string>()
        {
            "Beep beep boop haha im thinking!",
            "Bzzt! Calculating... hold tight!",
            "Thinking cap on... almost there!",
            "Crunching the numbers... beep bop!",
            "Boop! Just a moment, processing...",
            "Hold on, gears are turning...",
            "Zipping through data... nearly done!",
            "Brainstorming... beepity boop!",
            "Powering up... stay with me!",
            "Bleep bloop, cooking up some answers!",
            "Revving up... almost ready!",
            "Hold my wires... I got this!",
            "Brain freeze... defrosting now!",
            "Hang tight, I’m summoning the data spirits!",
            "Processing... or just staring blankly. You’ll never know!",
            "Beep bop... pretending to know what I’m doing!",
            "Hold up... gotta find my thinking socks!",
            "Calculating... with my imaginary abacus!",
            "Boop! Brewing knowledge... hope it’s not decaf!",
            "Revving up... in hamster-wheel mode!",
            "Brain cells engaged... even the lazy ones!"
        };

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
            await OnScreenChanged(old, CurrentScreen).ConfigureAwait(false);
            Render();
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
            await OnScreenChanged(old, CurrentScreen).ConfigureAwait(false);
            Render();
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
            await OnScreenChanged(old, CurrentScreen).ConfigureAwait(false);
            Render();
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
            await OnScreenChanged(old, CurrentScreen).ConfigureAwait(false);
            Render();
        }

        public static Spinner GetSpinner()
        {
            //return spinners[Random.Shared.Next(spinners.Count)];
            return Spinner.Known.Flip;
        }

        public static string GetStatusText()
        {
            return spinnerText[Random.Shared.Next(spinnerText.Count)];
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
            await oldScreen.OnWillUnshow().ConfigureAwait(false);
            await currentScreen.OnWillShow().ConfigureAwait(false);
        }
    }
}
