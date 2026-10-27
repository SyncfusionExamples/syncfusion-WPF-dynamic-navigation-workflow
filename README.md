# Syncfusion WPF Dynamic Navigation Workflow

A small MVVM wizard built with Syncfusion WPF controls (v35.1.41, FluentLight theme). One window hosts three steps; **Previous / Next** swap the content through ViewModel-to-View `DataTemplate`s (no frames, no reflection, no MVVM framework).

| Step | View | Controls |
| --- | --- | --- |
| 1 | `ControlA` | `SfTreeView` (organization hierarchy) + `SfTextInputLayout` search |
| 2 | `ControlB` | `SfDataGrid` (50 editable rows, sorting, filtering, grouping) |
| 3 | `ControlC` | `SfTextInputLayout`, `SfTextBoxExt`, `ComboBoxAdv`, `DateTimeEdit`, `CheckListBox` |

## Structure
- `Models/` – data classes
- `ViewModels/` – `MainViewModel` (navigation commands) and one ViewModel per step
- `Services/NavigationService.cs` – tracks the current step
- `Commands/RelayCommand.cs` – `ICommand` implementation
- `Views/` – XAML views; `App.xaml` holds shared styles
- `WizardApp.Tests/` – unit tests for navigation and ViewModels

## Run
Requires Windows and the .NET 8 SDK.

```
dotnet run --project WizardApp
```

Register your Syncfusion license key in `WizardApp/App.xaml.cs` to remove the trial banner.

## Test
```
dotnet test WizardApp.Tests
```
