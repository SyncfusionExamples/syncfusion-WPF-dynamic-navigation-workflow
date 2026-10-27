using WizardApp.ViewModels;

namespace WizardApp.Services;

/// <summary>Holds the ordered wizard steps and tracks the current one. No reflection is used.</summary>
public sealed class NavigationService
{
    private readonly IReadOnlyList<ViewModelBase> _steps;
    private int _index;

    /// <summary>Creates the service with ordered steps.</summary>
    public NavigationService(IReadOnlyList<ViewModelBase> steps)
    {
        if (steps.Count == 0) throw new ArgumentException("At least one step is required.", nameof(steps));
        _steps = steps;
    }

    /// <summary>Raised after the current step changes.</summary>
    public event Action? Navigated;

    /// <summary>The active step ViewModel.</summary>
    public ViewModelBase Current => _steps[_index];
    /// <summary>True when a previous step exists.</summary>
    public bool CanGoBack => _index > 0;
    /// <summary>True when a next step exists.</summary>
    public bool CanGoNext => _index < _steps.Count - 1;
    /// <summary>1-based current step number.</summary>
    public int StepNumber => _index + 1;
    /// <summary>Total number of steps.</summary>
    public int StepCount => _steps.Count;

    /// <summary>Moves to the next step if possible.</summary>
    public void MoveNext() { if (CanGoNext) { _index++; Navigated?.Invoke(); } }

    /// <summary>Moves to the previous step if possible.</summary>
    public void MovePrevious() { if (CanGoBack) { _index--; Navigated?.Invoke(); } }
}
