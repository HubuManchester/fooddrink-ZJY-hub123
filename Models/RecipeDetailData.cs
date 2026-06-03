namespace FoodDrinkMaui.Models;

/// <summary>
/// Complete data for a recipe detail page.
/// A single instance drives the entire <see cref="Pages.RecipeDetailPage"/> UI
/// including header, ingredients, instructions, and the food-type-specific special section.
/// </summary>
public class RecipeDetailData
{
    /// <summary>Large emoji displayed in the header banner.</summary>
    public string Emoji { get; set; } = "🍽️";

    /// <summary>Background colour of the header frame (hex).</summary>
    public string HeaderColor { get; set; } = "#E0E0E0";

    /// <summary>Accent colour used for instruction step badges and rating badge (hex).</summary>
    public string AccentColor { get; set; } = "#FF6B35";

    /// <summary>Cooking/preparation time (e.g. "25 min").</summary>
    public string Time { get; set; } = "30 min";

    /// <summary>Difficulty level: Easy, Medium, or Hard.</summary>
    public string Difficulty { get; set; } = "Medium";

    /// <summary>Number of servings or pieces (e.g. "4 servings", "8 tacos").</summary>
    public string Servings { get; set; } = "4 servings";

    /// <summary>Average rating score (e.g. "4.8").</summary>
    public string Rating { get; set; } = "4.5";

    /// <summary>Review count with parentheses (e.g. "(245)").</summary>
    public string Reviews { get; set; } = "(100)";

    /// <summary>Short descriptive paragraph shown below the title.</summary>
    public string Description { get; set; } = "";

    /// <summary>List of ingredient strings displayed with checkmark bullets.</summary>
    public string[] Ingredients { get; set; } = [];

    /// <summary>Ordered list of cooking instruction steps (1-indexed).</summary>
    public string[] Instructions { get; set; } = [];

    /// <summary>The first instruction, used by the Text-to-Speech feature when "Start Cooking" is tapped.</summary>
    public string FirstInstruction { get; set; } = "";

    /// <summary>Title of the food-type-specific special section (e.g. "👨‍🍳 Chef's Tips").</summary>
    public string SpecialTitle { get; set; } = "";

    /// <summary>Background colour of the special section frame (hex).</summary>
    public string SpecialColor { get; set; } = "#FFFFFF";

    /// <summary>Array of (emoji, text) tuples rendered as the special section content.</summary>
    public (string Emoji, string Text)[] Specials { get; set; } = [];
}
