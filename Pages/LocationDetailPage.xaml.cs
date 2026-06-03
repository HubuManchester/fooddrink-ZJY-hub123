namespace FoodDrinkMaui.Pages;

public partial class LocationDetailPage : ContentPage
{
    private double _latitude;
    private double _longitude;
    
    public LocationDetailPage(double latitude, double longitude)
    {
        InitializeComponent();
        _latitude = latitude;
        _longitude = longitude;
        
        // Display the location data
        LatitudeLabel.Text = latitude.ToString("F6");
        LongitudeLabel.Text = longitude.ToString("F6");
        AddressLabel.Text = $"Lat: {latitude:F4}, Lng: {longitude:F4}";
        AccuracyLabel.Text = "10 m";
        AltitudeLabel.Text = "50 m";
        TimestampLabel.Text = $"Last updated: {DateTime.Now:HH:mm:ss}";
    }
    
    private async void OnRefreshClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        
        try
        {
            var location = await Geolocation.Default.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.High,
                Timeout = TimeSpan.FromSeconds(30)
            });
            
            if (location != null)
            {
                _latitude = location.Latitude;
                _longitude = location.Longitude;
                LatitudeLabel.Text = location.Latitude.ToString("F6");
                LongitudeLabel.Text = location.Longitude.ToString("F6");
                AddressLabel.Text = $"Lat: {location.Latitude:F4}, Lng: {location.Longitude:F4}";
                AccuracyLabel.Text = location.Accuracy.HasValue ? $"{location.Accuracy:F0} m" : "Unknown";
                AltitudeLabel.Text = location.Altitude.HasValue ? $"{location.Altitude:F0} m" : "Unknown";
                TimestampLabel.Text = $"Last updated: {DateTime.Now:HH:mm:ss}";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to refresh location", "OK");
        }
    }
    
    private async void OnShareClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Title = "Share Location",
            Text = $"My location: {_latitude:F6}, {_longitude:F6}\nhttps://maps.google.com/?q={_latitude},{_longitude}"
        });
    }
    
    private async void OnOpenMapsClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        
        try
        {
            await Map.Default.OpenAsync(_latitude, _longitude, new MapLaunchOptions
            {
                Name = "My Location"
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Could not open maps application", "OK");
        }
    }
    
    private async void OnFindRestaurantsClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        
        // Navigate back to the location page which shows restaurants
        await Navigation.PopAsync();
    }
}
