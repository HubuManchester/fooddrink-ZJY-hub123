namespace FoodDrinkMaui.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private async void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        string mode = e.Value ? "Dark Mode enabled" : "Light Mode enabled";
        await DisplayAlert("Theme", mode, "OK");
    }

    private void OnFontSizeChanged(object sender, ValueChangedEventArgs e)
    {
        int fontSize = (int)e.NewValue;
        FontSizeLabel.Text = fontSize.ToString();
    }
}
