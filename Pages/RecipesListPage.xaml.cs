using FoodDrinkMaui.Services;

namespace FoodDrinkMaui.Pages;

public partial class RecipesListPage : ContentPage
{
    public RecipesListPage()
    {
        InitializeComponent();
        BuildFilterChips();
        RecipesCollection.ItemsSource = FoodDataService.AllRecipes;
    }

    private void BuildFilterChips()
    {
        string[] categories = { "All", "American", "Italian", "Japanese", "Mexican", "Healthy", "Dessert" };
        foreach (string cat in categories)
        {
            bool isFirst = cat == "All";
            var chip = new Frame
            {
                BackgroundColor = isFirst
                    ? (Color)Application.Current!.Resources["Primary"]
                    : (Color)Application.Current!.Resources["Surface"],
                CornerRadius = 20, Padding = new Thickness(16, 10), HasShadow = false,
                BorderColor = isFirst ? Colors.Transparent : Color.FromArgb("#E0E0E0")
            };
            chip.Content = new Label
            {
                Text = cat, FontSize = 13,
                TextColor = isFirst ? Colors.White : (Color)Application.Current!.Resources["TextPrimary"],
                FontAttributes = isFirst ? FontAttributes.Bold : FontAttributes.None
            };

            var catCopy = cat;
            var tap = new TapGestureRecognizer();
            tap.Tapped += (_, _) => FilterByCategory(catCopy);
            chip.GestureRecognizers.Add(tap);

            FilterBar.Children.Add(chip);
        }
    }

    private void FilterByCategory(string category)
    {
        // Update chip highlights
        for (int i = 0; i < FilterBar.Children.Count; i++)
        {
            if (FilterBar.Children[i] is Frame chip && chip.Content is Label label)
            {
                bool active = label.Text == category;
                chip.BackgroundColor = active
                    ? (Color)Application.Current!.Resources["Primary"]
                    : (Color)Application.Current!.Resources["Surface"];
                chip.BorderColor = active ? Colors.Transparent : Color.FromArgb("#E0E0E0");
                label.TextColor = active ? Colors.White : (Color)Application.Current!.Resources["TextPrimary"];
                label.FontAttributes = active ? FontAttributes.Bold : FontAttributes.None;
            }
        }

        // Filter
        RecipesCollection.ItemsSource = category == "All"
            ? FoodDataService.AllRecipes
            : FoodDataService.AllRecipes.Where(r => r.Category == category).ToList();
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

    private async void OnLoadMoreClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Loading", "Loading more recipes...", "OK");
    }
}
