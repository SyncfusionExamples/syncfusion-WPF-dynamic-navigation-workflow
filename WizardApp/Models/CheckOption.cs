using WizardApp.ViewModels;

namespace WizardApp.Models;

/// <summary>One entry of a CheckListBox.</summary>
public class CheckOption : ViewModelBase
{
    private bool _isChecked;

    /// <summary>Text shown next to the check mark.</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>Checked state.</summary>
    public bool IsChecked { get => _isChecked; set => SetProperty(ref _isChecked, value); }
}
