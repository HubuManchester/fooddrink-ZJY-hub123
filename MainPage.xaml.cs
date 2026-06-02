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

        // Provide haptic feedback
        try
        {
            HapticFeedback.Perform(HapticFeedbackType.Click);
        }
        catch { }

        await DisplayAlert("Search", $"Searching for: {searchText}", "OK");
    }

    private async void OnRecipesClicked(object sender, EventArgs e)
    {
        // Provide haptic feedback
        try
        {
            HapticFeedback.Perform(HapticFeedbackType.Click);
        }
        catch { }

        await DisplayAlert("Recipes", "Opening 1000+ delicious recipes...", "OK");
    }

    private async void OnNearbyClicked(object sender, EventArgs e)
    {
        // Provide haptic feedback
        try
        {
            HapticFeedback.Perform(HapticFeedbackType.Click);
        }
        catch { }

        await Shell.Current.GoToAsync("//LocationPage");
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        // Provide haptic feedback
        try
        {
            HapticFeedback.Perform(HapticFeedbackType.Click);
        }
        catch { }

        await Shell.Current.GoToAsync("//CameraPage");
    }

    private async void OnFavoritesClicked(object sender, EventArgs e)
    {
        // Provide haptic feedback
        try
        {
            HapticFeedback.Perform(HapticFeedbackType.Click);
        }
        catch { }

        await DisplayAlert("Favorites", "You have 12 saved recipes", "OK");
    }

    private async void OnFeaturedRecipeClicked(object sender, EventArgs e)
    {
        // Provide haptic feedback
        try
        {
            HapticFeedback.Perform(HapticFeedbackType.Click);
        }
        catch { }

        await DisplayAlert("Classic Beef Noodle Soup", 
            "Ingredients:\n- 500g beef\n- 200g noodles\n- Green onions\n- Soy sauce\n- Star anise\n\nCooking time: 45 minutes\nDifficulty: Easy", 
            "Start Cooking");
    }
}
