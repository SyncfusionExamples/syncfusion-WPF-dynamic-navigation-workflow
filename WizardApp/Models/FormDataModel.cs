using System.ComponentModel;
using WizardApp.ViewModels;

namespace WizardApp.Models;

/// <summary>Form data with <see cref="IDataErrorInfo"/> validation.</summary>
public class FormDataModel : ViewModelBase, IDataErrorInfo
{
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _department = string.Empty;
    private DateTime? _joiningDate = DateTime.Today;
    private readonly CheckOption _notifications = new() { Label = "Enable Notifications" };
    private readonly CheckOption _terms = new() { Label = "Accept Terms" };

    /// <summary>Creates the form and relays option changes to the model properties.</summary>
    public FormDataModel()
    {
        Options = new[] { _notifications, _terms };
        _notifications.PropertyChanged += (_, _) => OnPropertyChanged(nameof(EnableNotifications));
        _terms.PropertyChanged += (_, _) =>
        {
            OnPropertyChanged(nameof(AcceptTerms));
            OnPropertyChanged(nameof(IsValid));
            OnPropertyChanged(nameof(TermsError));
        };
    }

    /// <summary>Entries shown in the CheckListBox.</summary>
    public CheckOption[] Options { get; }

    /// <summary>Validation message for the terms option.</summary>
    public string TermsError => this[nameof(AcceptTerms)];

    /// <summary>First name (required).</summary>
    public string FirstName { get => _firstName; set { if (SetProperty(ref _firstName, value)) OnPropertyChanged(nameof(IsValid)); } }
    /// <summary>Last name (required).</summary>
    public string LastName { get => _lastName; set { if (SetProperty(ref _lastName, value)) OnPropertyChanged(nameof(IsValid)); } }
    /// <summary>Department (required).</summary>
    public string Department { get => _department; set { if (SetProperty(ref _department, value)) OnPropertyChanged(nameof(IsValid)); } }
    /// <summary>Joining date (cannot be in the future).</summary>
    public DateTime? JoiningDate { get => _joiningDate; set { if (SetProperty(ref _joiningDate, value)) OnPropertyChanged(nameof(IsValid)); } }
    /// <summary>Notification preference.</summary>
    public bool EnableNotifications => _notifications.IsChecked;
    /// <summary>Terms acceptance (required).</summary>
    public bool AcceptTerms => _terms.IsChecked;

    /// <summary>Not used by WPF; see indexer.</summary>
    public string Error => string.Empty;

    /// <summary>Returns the validation message for a property, or empty.</summary>
    public string this[string columnName] => columnName switch
    {
        nameof(FirstName) => string.IsNullOrWhiteSpace(FirstName) ? "First name is required." : string.Empty,
        nameof(LastName) => string.IsNullOrWhiteSpace(LastName) ? "Last name is required." : string.Empty,
        nameof(Department) => string.IsNullOrWhiteSpace(Department) ? "Select a department." : string.Empty,
        nameof(JoiningDate) => JoiningDate is null || JoiningDate > DateTime.Today ? "Joining date cannot be in the future." : string.Empty,
        nameof(AcceptTerms) => AcceptTerms ? string.Empty : "You must accept the terms.",
        _ => string.Empty
    };

    /// <summary>True when every validated field is valid.</summary>
    public bool IsValid => new[] { nameof(FirstName), nameof(LastName), nameof(Department), nameof(JoiningDate), nameof(AcceptTerms) }
        .All(p => string.IsNullOrEmpty(this[p]));
}
