using System.Globalization;
using System.Windows.Data;

namespace WizardApp.Converters;

/// <summary>Converts a non-empty string to true (drives SfTextInputLayout.HasError).</summary>
public sealed class StringToBoolConverter : IValueConverter
{
    /// <summary>True when the value is a non-empty string.</summary>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is string s && s.Length > 0;

    /// <summary>Not supported.</summary>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
