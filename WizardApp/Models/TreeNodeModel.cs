using System.Collections.ObjectModel;
using WizardApp.ViewModels;

namespace WizardApp.Models;

/// <summary>A hierarchical node displayed in the SfTreeView (department, team or employee).</summary>
public class TreeNodeModel : ViewModelBase
{
    private bool _isChecked;

    /// <summary>Display text.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Secondary text (e.g. head count).</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Segoe MDL2 icon glyph.</summary>
    public string Glyph { get; set; } = string.Empty;

    /// <summary>Child nodes.</summary>
    public ObservableCollection<TreeNodeModel> Children { get; } = new();

    /// <summary>Checkbox state.</summary>
    public bool IsChecked { get => _isChecked; set => SetProperty(ref _isChecked, value); }
}
