namespace Unlearn;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // СПОСОБ A (временно): сбрасываем сохранённое имя,
        // чтобы при запуске всегда открывался экран регистрации.
        Preferences.Remove("UserName");

        MainPage = new NavigationPage(new RegisterPage());
    }
}