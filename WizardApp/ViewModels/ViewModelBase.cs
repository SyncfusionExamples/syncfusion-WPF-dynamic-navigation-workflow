using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WizardApp.ViewModels;

/// <summary>Base class providing efficient <see cref="INotifyPropertyChanged"/> support.</summary>
public abstract class ViewModelBase : INotifyPropertyChanged
{
    /// <summary>Raised when a property value changes.</summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>Raises <see cref="PropertyChanged"/>.</summary>
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    /// <summary>Sets a field and raises change notification only if the value changed.</summary>
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? name = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(name);
        return true;
    }
}
