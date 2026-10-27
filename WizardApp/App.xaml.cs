using System.Windows;

namespace WizardApp;

/// <summary>Application entry point. Register your Syncfusion license key here.</summary>
public partial class App : Application
{
    /// <summary>Registers the Syncfusion license before any control is created.</summary>
    public App()
    {
        // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR_LICENSE_KEY");
    }
}
