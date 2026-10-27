using System.Windows;

namespace WizardApp.Converters;

/// <summary>
/// Freezable that carries the DataContext to elements outside the visual tree (such as grid columns).
/// This avoids <c>x:Reference</c>, which causes cyclic-dependency errors.
/// </summary>
public class BindingProxy : Freezable
{
    /// <summary>The proxied data (normally the DataContext).</summary>
    public object? Data
    {
        get => GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    /// <summary>Dependency property for <see cref="Data"/>.</summary>
    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register(nameof(Data), typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));

    /// <inheritdoc />
    protected override Freezable CreateInstanceCore() => new BindingProxy();
}
