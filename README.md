# Syncfusion WPF Dynamic Navigation Workflow

A wizard-style WPF sample that shows how to navigate between dynamically loaded views using the **MVVM** pattern and **Syncfusion WPF** controls. A single window hosts three steps; the **Previous** and **Next** buttons swap the content through ViewModel-to-View `DataTemplate`s. It uses no frames, no reflection-based navigation and no third-party MVVM framework.

## Key features

- **MVVM navigation**: `MainViewModel` exposes `NextCommand` and `PreviousCommand`. Previous is disabled on the first step and Next on the last, and the buttons update automatically.
- **Step 1 – Organization tree**: `SfTreeView` with a four-level hierarchy (departments, teams, employees) and live search.
- **Step 2 – Editable data grid**: `SfDataGrid` with 50 sample rows, in-place editing, sorting, filtering and grouping.
- **Step 3 – Validated form**: `SfTextInputLayout`, `SfTextBoxExt`, `ComboBoxAdv`, `DateTimeEdit` and `CheckListBox`, with inline validation messages.
- **Fluent theme**: `SfSkinManager` with the FluentLight theme, plus shared styles in `App.xaml`.
- No business logic in code-behind. Public members have XML documentation.

## Prerequisites

- Windows 10 or later
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 with the *.NET desktop development* workload (optional; the CLI also works)
- A Syncfusion license key

## Getting started

```bash
git clone https://github.com/SyncfusionExamples/Syncfusion-WPF-Dynamic-Navigation-Workflow.git
cd Syncfusion-WPF-Dynamic-Navigation-Workflow
dotnet run --project WizardApp
```

Or open `SyncfusionWizard.sln` in Visual Studio and press **F5**. NuGet packages restore automatically.

### Register your license key

In `WizardApp/App.xaml.cs`, uncomment the line below and add your own key. Do not commit real keys to a public repository.

```csharp
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR_LICENSE_KEY");
```

## Usage

1. Search and browse the organization in step 1, then click **Next**.
2. Click a cell in the grid to edit it. Use the column headers to sort or filter, and drag a header to the group area to group. Click **Next**.
3. Fill in the form in step 3. Required fields show validation messages until they are valid. Use **Previous** to go back at any time.

## Project structure

```
WizardApp/
  Commands/     RelayCommand (ICommand implementation)
  Converters/   BindingProxy, StringToBoolConverter
  Models/       Tree, grid and form data models
  Services/     NavigationService, SampleData
  ViewModels/   MainViewModel + one ViewModel per step
  Views/        MainWindow, ControlA, ControlB, ControlC
```

## Dependencies

All Syncfusion packages are version **35.1.41**: `Syncfusion.SfGrid.WPF`, `Syncfusion.SfTreeView.WPF`, `Syncfusion.SfInput.WPF`, `Syncfusion.SfTextInputLayout.WPF`, `Syncfusion.Shared.WPF`, `Syncfusion.Tools.WPF`, `Syncfusion.SfSkinManager.WPF` and `Syncfusion.Themes.FluentLight.WPF`.


## License

Syncfusion controls require a valid Syncfusion license (commercial or Community). See the [Syncfusion license terms](https://www.syncfusion.com/sales/products).
