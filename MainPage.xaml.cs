using FoodDrinkMaui.Pages;

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

        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }

        // Navigate to search results page
        await Navigation.PushAsync(new SearchResultsPage(searchText));
    }

    private async void OnRecipesClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }

        // Navigate to recipes list page
        await Navigation.PushAsync(new RecipesListPage());
    }

    private async void OnNearbyClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        await Shell.Current.GoToAsync("//LocationPage");
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        await Shell.Current.GoToAsync("//CameraPage");
    }

    private async void OnFavoritesClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        await DisplayAlert("Favorites", "You have 12 saved recipes:\n\n1. Classic Beef Burger\n2. Margherita Pizza\n3. Caesar Salad\n4. Chocolate Cake\n\n...and 8 more", "OK");
    }

    private async void OnFeaturedRecipeClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        await Navigation.PushAsync(new RecipeDetailPage("Classic Beef Noodle Soup"));
    }

    private async void OnQuickPickClicked(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.GestureRecognizers[0] is TapGestureRecognizer tap)
        {
            string recipeName = tap.CommandParameter?.ToString() ?? "Recipe";
            try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
            await Navigation.PushAsync(new RecipeDetailPage(recipeName));
        }
    }
}
