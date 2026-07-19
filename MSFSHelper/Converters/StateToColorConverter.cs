using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using MSFSHelper.Core.Checklists.ChecklistItems;
using Terminal.Gui;
using Color = Spectre.Console.Color;

namespace MSFSHelper.Converters;

public class StateToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var casted = (value is ChecklistItemState ? (ChecklistItemState)value : ChecklistItemState.Uncheckable);

        switch (casted)
        {
            case ChecklistItemState.Uncheckable:
            case ChecklistItemState.Skipped:
            default:
                return Brushes.Gray;
            
            case ChecklistItemState.Checked:
                return Brushes.Green;
            
            case ChecklistItemState.Unchecked:
                return Brushes.Red;
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}