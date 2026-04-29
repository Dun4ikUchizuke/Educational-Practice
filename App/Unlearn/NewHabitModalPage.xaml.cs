namespace Unlearn;

public partial class NewHabitModalPage : ContentPage
{
    public NewHabitModalPage()
    {
        InitializeComponent();
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void OnBackdropTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}