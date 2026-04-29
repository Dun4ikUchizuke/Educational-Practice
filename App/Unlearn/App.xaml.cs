using Microsoft.Maui.Storage;

namespace Unlearn;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var name = Preferences.Get("UserName", "");
        MainPage = string.IsNullOrWhiteSpace(name)
            ? new NavigationPage(new RegisterPage())
            : new AppShell();
    }
}