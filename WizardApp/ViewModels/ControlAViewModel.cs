using System.Collections.ObjectModel;
using System.Windows.Input;
using WizardApp.Commands;
using WizardApp.Models;

namespace WizardApp.ViewModels;

/// <summary>ViewModel for the TreeView step (hierarchy, search, lazy loading).</summary>
public class ControlAViewModel : ViewModelBase
{
    private string _searchText = string.Empty;

    /// <summary>Builds sample data. Team nodes are loaded lazily on first expand/search.</summary>
    public ControlAViewModel()
    {
        var root = new TreeNodeModel { Name = "Departments", IsExpanded = true };
        foreach (var d in new[] { "Sales", "Marketing", "Support" })
            root.Children.Add(new TreeNodeModel { Name = d, HasUnloadedChildren = true });
        Nodes.Add(root);
        LoadChildrenCommand = new RelayCommand(p => LoadChildren(p as TreeNodeModel));
    }

    /// <summary>Root nodes bound to SfTreeView.</summary>
    public ObservableCollection<TreeNodeModel> Nodes { get; } = new();

    /// <summary>Search text; matching branches are expanded.</summary>
    public string SearchText { get => _searchText; set { if (SetProperty(ref _searchText, value)) ApplySearch(); } }

    /// <summary>Loads children of a node on demand (lazy loading pattern).</summary>
    public ICommand LoadChildrenCommand { get; }

    /// <summary>Populates children of a lazy node once.</summary>
    public void LoadChildren(TreeNodeModel? node)
    {
        if (node is null || !node.HasUnloadedChildren) return;
        node.HasUnloadedChildren = false;
        for (int i = 1; i <= 3; i++)
            node.Children.Add(new TreeNodeModel { Name = $"{node.Name} Team {i}" });
    }

    private void ApplySearch()
    {
        foreach (var n in Nodes) Visit(n);
    }

    private bool Visit(TreeNodeModel node)
    {
        bool searching = SearchText.Length > 0;
        if (searching) LoadChildren(node);
        bool match = searching && node.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
        bool childMatch = false;
        foreach (var c in node.Children) childMatch |= Visit(c);
        if (searching && childMatch) node.IsExpanded = true;
        return match || childMatch;
    }
}
