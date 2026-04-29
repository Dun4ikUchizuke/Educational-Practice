namespace Unlearn;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnMenuClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Меню", "Тут будет меню.", "OK");
    }

    private async void OnAddNewTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new NewHabitModalPage());
    }
}