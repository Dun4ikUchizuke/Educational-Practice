using Microsoft.Maui.Storage;

namespace Unlearn;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnContinueClicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(name))
        {
            await DisplayAlert("Ошибка", "Введите имя.", "OK");
            return;
        }

        Preferences.Set("UserName", name);

        // Временный переход: просто откроем MainPage
        // (правильно через Shell настроим чуть позже)
        await Navigation.PushAsync(new MainPage());
    }
}