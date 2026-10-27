using WizardApp.ViewModels;

namespace WizardApp.Models;

/// <summary>An editable row in the SfDataGrid. Raises change notifications so edits flow back to the UI.</summary>
public class GridDataModel : ViewModelBase
{
    private string _name = string.Empty;
    private string _department = string.Empty;
    private string _status = string.Empty;

    /// <summary>Identifier (read-only in the grid).</summary>
    public int Id { get; set; }
    /// <summary>Employee name.</summary>
    public string Name { get => _name; set => SetProperty(ref _name, value); }
    /// <summary>Department name.</summary>
    public string Department { get => _department; set => SetProperty(ref _department, value); }
    /// <summary>Status text.</summary>
    public string Status { get => _status; set => SetProperty(ref _status, value); }
}
