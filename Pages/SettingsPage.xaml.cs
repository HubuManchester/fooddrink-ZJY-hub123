using FoodDrinkMaui.Services;

namespace FoodDrinkMaui.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        
        // Load saved settings
        DarkModeSwitch.IsToggled = ThemeService.IsDarkMode;
        DarkModeLabel.Text = ThemeService.IsDarkMode ? "On" : "Off";
        FontSizeSlider.Value = ThemeService.FontSize;
        FontSizeLabel.Text = $"{ThemeService.FontSize}px";
        
        // Apply current font size
        ApplyFontSize(ThemeService.FontSize);
    }

    private void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        ThemeService.IsDarkMode = e.Value;
        DarkModeLabel.Text = e.Value ? "On" : "Off";

        // Immediately update the current page's background to show the change
        UpdatePageTheme();
        
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
    }

    private void OnFontSizeChanged(object sender, ValueChangedEventArgs e)
    {
        int fontSize = (int)e.NewValue;
        FontSizeLabel.Text = $"{fontSize}px";
        ThemeService.FontSize = fontSize;
        
        // Update font sizes on current page
        ApplyFontSize(fontSize);
    }
    
    // Store each label's original (XAML-defined) font size so scaling is always correct
    private readonly Dictionary<Label, double> _originalSizes = new();

    private void ApplyFontSize(int baseFontSize)
    {
        double ratio = baseFontSize / 16.0; // 16 is the default base
        ApplyFontSizeToElement(this.Content, ratio);
    }

    private void ApplyFontSizeToElement(IView element, double ratio)
    {
        if (element == null) return;

        if (element is Label label)
        {
            // Record the original size the first time we see this label
            if (!_originalSizes.ContainsKey(label))
                _originalSizes[label] = label.FontSize;

            // Always scale from the original XAML size
            label.FontSize = Math.Round(_originalSizes[label] * ratio, 1);
        }

        // Recursively apply to children
        if (element is Layout layout)
        {
            foreach (var child in layout.Children)
                ApplyFontSizeToElement(child, ratio);
        }
        else if (element is ContentView contentView && contentView.Content != null)
        {
            ApplyFontSizeToElement(contentView.Content, ratio);
        }
        else if (element is ScrollView scrollView && scrollView.Content != null)
        {
            ApplyFontSizeToElement(scrollView.Content, ratio);
        }
        else if (element is Frame frame && frame.Content != null)
        {
            ApplyFontSizeToElement(frame.Content, ratio);
        }
        else if (element is Grid grid)
        {
            foreach (var child in grid.Children)
                ApplyFontSizeToElement(child, ratio);
        }
    }
    
    private void UpdatePageTheme()
    {
        bool isDark = ThemeService.IsDarkMode;
        
        // Update current page background
        BackgroundColor = isDark ? Color.FromArgb("#1A1A2E") : Color.FromArgb("#F5F7F8");
        
        // Update all resources
        var resources = Application.Current?.Resources;
        if (resources != null)
        {
            resources["Background"] = isDark ? Color.FromArgb("#1A1A2E") : Color.FromArgb("#F5F7F8");
            resources["Surface"] = isDark ? Color.FromArgb("#252542") : Color.FromArgb("#FFFFFF");
            resources["TextPrimary"] = isDark ? Color.FromArgb("#FFFFFF") : Color.FromArgb("#1A1A2E");
            resources["TextSecondary"] = isDark ? Color.FromArgb("#B0B0B0") : Color.FromArgb("#6B7280");
            resources["Divider"] = isDark ? Color.FromArgb("#3D3D5C") : Color.FromArgb("#E5E7EB");
        }
        
        // Force refresh all pages by invalidating
        InvalidateMeasure();
        
        // Show feedback to user
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            string mode = isDark ? "Dark" : "Light";
            await DisplayAlert("Theme Changed", $"{mode} mode is now active. Navigate to other pages to see the full effect.", "OK");
        });
    }
}
