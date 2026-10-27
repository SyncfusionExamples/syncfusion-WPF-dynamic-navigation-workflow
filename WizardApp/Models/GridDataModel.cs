namespace WizardApp.Models;

/// <summary>A row in the SfDataGrid.</summary>
public class GridDataModel
{
    /// <summary>Identifier.</summary>
    public int Id { get; set; }
    /// <summary>Employee name.</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>Department name.</summary>
    public string Department { get; set; } = string.Empty;
    /// <summary>Status text.</summary>
    public string Status { get; set; } = string.Empty;
}
