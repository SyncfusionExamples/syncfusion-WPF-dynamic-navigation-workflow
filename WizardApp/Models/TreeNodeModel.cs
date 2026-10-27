using System.Collections.ObjectModel;
using WizardApp.ViewModels;

namespace WizardApp.Models;

/// <summary>A hierarchical node displayed in the SfTreeView.</summary>
public class TreeNodeModel : ViewModelBase
{
    private bool? _isChecked = false;
    private bool _isExpanded;

    /// <summary>Display text.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Child nodes. Loaded on demand for lazy-loading nodes.</summary>
    public ObservableCollection<TreeNodeModel> Children { get; } = new();

    /// <summary>True when children have not been loaded yet (lazy loading).</summary>
    public bool HasUnloadedChildren { get; set; }

    /// <summary>Checkbox state.</summary>
    public bool? IsChecked { get => _isChecked; set => SetProperty(ref _isChecked, value); }

    /// <summary>Expanded state.</summary>
    public bool IsExpanded { get => _isExpanded; set => SetProperty(ref _isExpanded, value); }
}
