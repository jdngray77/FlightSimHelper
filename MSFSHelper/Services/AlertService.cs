using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Consolonia.Controls;
using MSFSHelper.Core.Services;

namespace MSFSHelper.Services;

public class AlertService : IAlertService
{
    public async Task<bool> ShowAlertAsync(
        string message,
        string title,
        string yesButtonText = "Yes",
        string noButtonText = "No")
    {
        var tcs = new TaskCompletionSource<bool>();

        Window dialog = null;
        dialog = new Window
        {
            Width = 40,
            Height = 10,
            Title = "Confirm",
            Content = new StackPanel
            {
                Spacing = 1,
                Children =
                {
                    new TextBlock { Text = message },

                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Spacing = 2,
                        Children =
                        {
                            CreateButton(yesButtonText, true),
                            CreateButton(noButtonText, false)
                        }
                    }
                }
            }
        };

        Button CreateButton(string text, bool result)
        {
            var button = new Button { Content = text };
            button.Click += (_, _) =>
            {
                tcs.TrySetResult(result);
                dialog.Close();
            };
            return button;
        }

        dialog.Show();

        return await tcs.Task.ConfigureAwait(false);
    }

    public async Task ShowAlertAsync(
        string message,
        string title,
        string ackButton = "Ok")
    {
        var tcs = new TaskCompletionSource();

        Window dialog = null;
        dialog = new Window
        {
            Width = 40,
            Height = 10,
            Title = "Confirm",
            Content = new StackPanel
            {
                Spacing = 1,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Children =
                {
                    new TextBlock { Text = message },

                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Spacing = 2,
                        Children =
                        {
                            CreateButton(ackButton),
                        }
                    }
                }
            }
        };

        Button CreateButton(string text)
        {
            var button = new Button { Content = text };
            button.Click += (_, _) =>
            {
                tcs.TrySetResult();
                dialog.Close();
            };
            return button;
        }

        dialog.Show();

        await tcs.Task.ConfigureAwait(false);
    }
}