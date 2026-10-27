using System.Collections.ObjectModel;
using WizardApp.Models;

namespace WizardApp.ViewModels;

/// <summary>ViewModel for the DataGrid step; supplies 50 sample rows.</summary>
public class ControlBViewModel : ViewModelBase
{
    private static readonly string[] Departments = { "Sales", "Marketing", "Support" };
    private static readonly string[] Statuses = { "Active", "On Leave", "Inactive" };

    /// <summary>Generates sample data.</summary>
    public ControlBViewModel()
    {
        for (int i = 1; i <= 50; i++)
            Items.Add(new GridDataModel
            {
                Id = i,
                Name = $"Employee {i:00}",
                Department = Departments[i % Departments.Length],
                Status = Statuses[i % Statuses.Length]
            });
    }

    /// <summary>Rows bound to SfDataGrid.</summary>
    public ObservableCollection<GridDataModel> Items { get; } = new();
}
