namespace FoodDrinkMaui.Services;

public static class ThemeService
{
    private const string DarkModeKey = "DarkModeEnabled";
    private const string FontSizeKey = "FontSize";
    
    public static bool IsDarkMode
    {
        get => Preferences.Default.Get(DarkModeKey, false);
        set
        {
            Preferences.Default.Set(DarkModeKey, value);
            ApplyTheme();
        }
    }
    
    public static int FontSize
    {
        get => Preferences.Default.Get(FontSizeKey, 16);
        set
        {
            Preferences.Default.Set(FontSizeKey, value);
            ApplyFontSize();
        }
    }
    
    public static void Initialize()
    {
        ApplyTheme();
        ApplyFontSize();
    }
    
    public static void ApplyTheme()
    {
        var resources = Application.Current?.Resources;
        if (resources == null) return;
        
        if (IsDarkMode)
        {
            // Dark theme colors
            resources["Background"] = Color.FromArgb("#1A1A2E");
            resources["Surface"] = Color.FromArgb("#252542");
            resources["TextPrimary"] = Color.FromArgb("#FFFFFF");
            resources["TextSecondary"] = Color.FromArgb("#B0B0B0");
            resources["Divider"] = Color.FromArgb("#3D3D5C");
        }
        else
        {
            // Light theme colors
            resources["Background"] = Color.FromArgb("#F5F7F8");
            resources["Surface"] = Color.FromArgb("#FFFFFF");
            resources["TextPrimary"] = Color.FromArgb("#1A1A2E");
            resources["TextSecondary"] = Color.FromArgb("#6B7280");
            resources["Divider"] = Color.FromArgb("#E5E7EB");
        }
        
        // Force refresh the current page
        RefreshCurrentPage();
    }
    
    public static void ApplyFontSize()
    {
        var resources = Application.Current?.Resources;
        if (resources == null) return;
        
        int baseFontSize = FontSize;
        
        // Update font size styles dynamically
        // Note: In MAUI, changing font sizes requires updating styles or using bindings
        // For now, we'll store the preference and use it when creating new pages
        
        RefreshCurrentPage();
    }
    
    private static void RefreshCurrentPage()
    {
        // Force refresh by navigating to the same page
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            try
            {
                // Get current shell location and refresh
                if (Shell.Current != null)
                {
                    var current = Shell.Current.CurrentPage;
                    if (current != null)
                    {
                        // Trigger a visual refresh
                        current.ForceLayout();
                    }
                }
            }
            catch { }
        });
    }
}
