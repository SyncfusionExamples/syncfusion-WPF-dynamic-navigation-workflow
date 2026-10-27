using System.Windows.Input;

namespace WizardApp.Commands;

/// <summary>
/// Minimal <see cref="ICommand"/> implementation (no third-party MVVM framework).
/// </summary>
public sealed class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?>? _canExecute;

    /// <summary>Creates a command.</summary>
    /// <param name="execute">Action to run.</param>
    /// <param name="canExecute">Optional predicate controlling availability.</param>
    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>Raised when <see cref="CanExecute"/> may have changed.</summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>Returns whether the command can run.</summary>
    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    /// <summary>Runs the command.</summary>
    public void Execute(object? parameter) => _execute(parameter);

    /// <summary>Tells bound buttons to re-query <see cref="CanExecute"/>.</summary>
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
