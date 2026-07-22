using System.Globalization;
using Avalonia.Data.Converters;

namespace MSFSHelper.Views.Controls.Checklist
{
    /// <summary>
    /// Adds formatting to a checklist item when it is selected.
    /// </summary>
    public class ChecklistItemSelectedTextConverter : IMultiValueConverter
    {
        public object Convert(
            IList<object> values,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (values.Count < 2)
                return "";

            var text = values[0]?.ToString() ?? "";
            var selected = values[1] is bool b && b;

            return selected ? $"> {text} <" : text;
        }
    }
}