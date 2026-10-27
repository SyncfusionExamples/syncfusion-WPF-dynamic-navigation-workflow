using WizardApp.Models;

namespace WizardApp.ViewModels;

/// <summary>ViewModel for the form step.</summary>
public class ControlCViewModel : ViewModelBase
{
    /// <summary>The validated form model.</summary>
    public FormDataModel Form { get; } = new();

    /// <summary>Choices for the department ComboBox.</summary>
    public string[] Departments { get; } = { "Sales", "Marketing", "Support" };
}
