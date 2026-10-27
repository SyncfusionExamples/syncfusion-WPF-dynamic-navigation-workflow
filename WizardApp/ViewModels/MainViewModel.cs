using System.Windows.Input;
using WizardApp.Commands;
using WizardApp.Services;

namespace WizardApp.ViewModels;

/// <summary>Shell ViewModel: exposes the current step and navigation commands.</summary>
public class MainViewModel : ViewModelBase
{
    private readonly NavigationService _navigation;
    private readonly RelayCommand _next;
    private readonly RelayCommand _previous;

    /// <summary>Creates the three wizard steps and wires navigation.</summary>
    public MainViewModel()
    {
        _navigation = new NavigationService(new ViewModelBase[]
        {
            new ControlAViewModel(), new ControlBViewModel(), new ControlCViewModel()
        });
        _next = new RelayCommand(_ => _navigation.MoveNext(), _ => _navigation.CanGoNext);
        _previous = new RelayCommand(_ => _navigation.MovePrevious(), _ => _navigation.CanGoBack);
        _navigation.Navigated += OnNavigated;
    }

    /// <summary>ViewModel hosted by the ContentControl; DataTemplates map it to a View.</summary>
    public ViewModelBase CurrentViewModel => _navigation.Current;
    /// <summary>Moves forward; disabled on the last page.</summary>
    public ICommand NextCommand => _next;
    /// <summary>Moves back; disabled on the first page.</summary>
    public ICommand PreviousCommand => _previous;
    /// <summary>Header text showing progress.</summary>
    public string StepText => $"Step {_navigation.StepNumber} of {_navigation.StepCount}";

    private void OnNavigated()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
        OnPropertyChanged(nameof(StepText));
        _next.RaiseCanExecuteChanged();
        _previous.RaiseCanExecuteChanged();
    }
}
