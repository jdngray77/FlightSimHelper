using Avalonia.Data.Converters;
using System.Globalization;

namespace MSFSHelper.Converters
{
    public class SelectedChecklistItemTextConverter : IMultiValueConverter
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