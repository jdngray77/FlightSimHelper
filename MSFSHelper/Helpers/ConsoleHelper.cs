﻿using Spectre.Console;

namespace MSFSHelper.Helpers
{
    internal static class ConsoleHelper
    {
        public static string Red(this string str)
        {
            return str.Colored(Color.Red1);
        }

        public static string Green(this string str)
        {
            return str.Colored(Color.Green1);
        }

        public static string Colored(this string str, Color color)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return $"[{color}]{str}[/]";
        }

        public static string Bold(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            if (str.StartsWith("[bold]"))
            {
                return str;
            }

            return $"[bold]{str}[/]";
        }

    }
}
