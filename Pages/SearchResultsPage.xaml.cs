using FoodDrinkMaui.Models;
using FoodDrinkMaui.Services;

namespace FoodDrinkMaui.Pages;

public partial class SearchResultsPage : ContentPage
{
    public SearchResultsPage(string searchQuery)
    {
        InitializeComponent();
        SearchQueryLabel.Text = $"Results for '{searchQuery}'";

        List<RecipeItem> results = FoodDataService.Search(searchQuery);
        ResultCountLabel.Text = $"Found {results.Count} recipes";
        ResultsCollection.ItemsSource = results;
    }

    private async void OnRecipeClicked(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.GestureRecognizers[0] is TapGestureRecognizer tap)
        {
            string recipeName = tap.CommandParameter?.ToString() ?? "Recipe";
            try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
            await Navigation.PushAsync(new RecipeDetailPage(recipeName));
        }
    }
}
