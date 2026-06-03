using FoodDrinkMaui.Pages;

namespace FoodDrinkMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        // Register routes for navigation
        Routing.RegisterRoute(nameof(SearchResultsPage), typeof(SearchResultsPage));
        Routing.RegisterRoute(nameof(RecipesListPage), typeof(RecipesListPage));
        Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
        Routing.RegisterRoute(nameof(RestaurantDetailPage), typeof(RestaurantDetailPage));
        Routing.RegisterRoute(nameof(LocationDetailPage), typeof(LocationDetailPage));
    }
}
