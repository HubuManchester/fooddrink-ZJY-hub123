namespace FoodDrinkMaui.Models;

/// <summary>
/// Represents a restaurant card displayed in the LocationPage list.
/// </summary>
public class RestaurantItem
{
    /// <summary>Restaurant name (e.g. "Golden Dragon Restaurant").</summary>
    public string Name { get; set; } = "";

    /// <summary>Cuisine type (e.g. "Chinese Cuisine").</summary>
    public string Cuisine { get; set; } = "";

    /// <summary>Average rating as a string (e.g. "4.5").</summary>
    public string Rating { get; set; } = "4.0";

    /// <summary>Human-readable distance (e.g. "0.5 km away").</summary>
    public string Distance { get; set; } = "1.0 km away";

    /// <summary>Open/closed status used for badge colour and label (e.g. "Open Now").</summary>
    public string Status { get; set; } = "Open Now";

    /// <summary>Emoji icon for the restaurant card.</summary>
    public string Emoji { get; set; } = "🍽️";

    /// <summary>Hex colour for the icon background (e.g. "#FFECB3").</summary>
    public string ColorHex { get; set; } = "#E0E0E0";
}
