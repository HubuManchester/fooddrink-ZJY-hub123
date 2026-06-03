namespace FoodDrinkMaui.Models;

/// <summary>
/// Represents a recipe card displayed in list views (RecipesListPage, SearchResultsPage, Quick Picks).
/// Lightweight model used only for display — detail data is in <see cref="RecipeDetailData"/>.
/// </summary>
public class RecipeItem
{
    /// <summary>Display name of the recipe (e.g. "Classic Beef Burger").</summary>
    public string Name { get; set; } = "";

    /// <summary>Emoji character used as the visual icon for this recipe.</summary>
    public string Emoji { get; set; } = "🍽️";

    /// <summary>Estimated cooking/preparation time (e.g. "25 min").</summary>
    public string Time { get; set; } = "30 min";

    /// <summary>Difficulty level: Easy, Medium, or Hard.</summary>
    public string Difficulty { get; set; } = "Medium";

    /// <summary>Cuisine category used for filtering (e.g. "Italian", "Japanese").</summary>
    public string Category { get; set; } = "";

    /// <summary>Average user rating as a string (e.g. "4.7").</summary>
    public string Rating { get; set; } = "4.5";

    /// <summary>Number of reviews in parentheses (e.g. "(245)").</summary>
    public string Reviews { get; set; } = "(100)";

    /// <summary>Hex colour code for the card background (e.g. "#FFECB3").</summary>
    public string ColorHex { get; set; } = "#E0E0E0";
}
