namespace FoodDrinkMaui.Pages;

public partial class RestaurantDetailPage : ContentPage
{
    public RestaurantDetailPage(string name, string cuisine, string rating, string distance, string status)
    {
        InitializeComponent();
        
        RestaurantName.Text = name;
        Title = name;
        CuisineLabel.Text = cuisine;
        RatingLabel.Text = rating;
        DistanceLabel.Text = distance;
        StatusLabel.Text = status;
        
        // Set emoji and colors based on cuisine
        (string emoji, string bgColor) = cuisine.ToLower() switch
        {
            var c when c.Contains("chinese") => ("&#x1F961;", "#FFECB3"),
            var c when c.Contains("japanese") => ("&#x1F363;", "#FFCCBC"),
            var c when c.Contains("italian") => ("&#x1F355;", "#FFCCBC"),
            var c when c.Contains("american") || c.Contains("fast") => ("&#x1F354;", "#FFECB3"),
            var c when c.Contains("indian") => ("&#x1F35B;", "#FFE0B2"),
            var c when c.Contains("mexican") => ("&#x1F32E;", "#FFF9C4"),
            _ => ("&#x1F37D;", "#E0E0E0")
        };
        
        RestaurantEmoji.Text = emoji;
        HeaderFrame.BackgroundColor = Color.FromArgb(bgColor);
        
        // Set status badge color
        if (status.Contains("Open"))
        {
            StatusBadge.BackgroundColor = (Color)Application.Current.Resources["TagGreen"];
            StatusLabel.TextColor = (Color)Application.Current.Resources["TagGreenText"];
        }
        else
        {
            StatusBadge.BackgroundColor = (Color)Application.Current.Resources["TagOrange"];
            StatusLabel.TextColor = (Color)Application.Current.Resources["TagOrangeText"];
        }
    }

    private async void OnCallClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        
        try
        {
            PhoneDialer.Default.Open("+1234567890");
        }
        catch
        {
            await DisplayAlert("Phone", "Calling +1 234 567 8900...", "OK");
        }
    }

    private async void OnDirectionsClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        
        try
        {
            await Map.Default.OpenAsync(37.7749, -122.4194, new MapLaunchOptions
            {
                Name = RestaurantName.Text,
                NavigationMode = NavigationMode.Driving
            });
        }
        catch
        {
            await DisplayAlert("Directions", "Opening maps to 123 Food Street, City Center...", "OK");
        }
    }
}
