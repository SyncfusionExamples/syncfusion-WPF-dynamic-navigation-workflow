using System.Collections.ObjectModel;
using WizardApp.Models;
using WizardApp.Services;

namespace WizardApp.ViewModels;

/// <summary>ViewModel for the TreeView step: organization hierarchy with search and selection details.</summary>
public class ControlAViewModel : ViewModelBase
{
    private readonly TreeNodeModel _root = SampleData.CreateOrganization();
    private string _searchText = string.Empty;
    private TreeNodeModel? _selectedNode;

    /// <summary>Loads the full hierarchy.</summary>
    public ControlAViewModel() => Nodes.Add(_root);

    /// <summary>Nodes bound to SfTreeView. Replaced by a filtered copy while searching.</summary>
    public ObservableCollection<TreeNodeModel> Nodes { get; } = new();

    /// <summary>Search text; the tree shows only matching branches.</summary>
    public string SearchText
    {
        get => _searchText;
        set { if (SetProperty(ref _searchText, value)) ApplyFilter(); }
    }

    /// <summary>Node currently selected in the tree.</summary>
    public TreeNodeModel? SelectedNode
    {
        get => _selectedNode;
        set { if (SetProperty(ref _selectedNode, value)) OnPropertyChanged(nameof(SelectionText)); }
    }

    /// <summary>Text describing the selected node.</summary>
    public string SelectionText => SelectedNode is null ? "Select a node" : $"{SelectedNode.Name} — {SelectedNode.Description}";

    private void ApplyFilter()
    {
        Nodes.Clear();
        if (SearchText.Length == 0) { Nodes.Add(_root); return; }
        var filtered = Filter(_root);
        if (filtered is not null) Nodes.Add(filtered);
    }

    private TreeNodeModel? Filter(TreeNodeModel node)
    {
        var copy = new TreeNodeModel { Name = node.Name, Description = node.Description, Glyph = node.Glyph, IsChecked = node.IsChecked };
        foreach (var c in node.Children)
        {
            var fc = Filter(c);
            if (fc is not null) copy.Children.Add(fc);
        }
        bool selfMatch = node.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
        return selfMatch || copy.Children.Count > 0 ? copy : null;
    }
}
