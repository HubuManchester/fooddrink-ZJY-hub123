namespace FoodDrinkMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        string searchText = SearchEntry.Text;

        if (string.IsNullOrWhiteSpace(searchText))
        {
            await DisplayAlert("Notice", "Please enter search keywords", "OK");
            return;
        }

        await DisplayAlert("Search", $"Searching: {searchText}", "OK");
    }

    private async void OnRecipesClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Recipes", "Opening recipe browser...", "OK");
    }

    private async void OnNearbyClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LocationPage");
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CameraPage");
    }

    private async void OnFavoritesClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Favorites", "Opening your saved recipes...", "OK");
    }
}
