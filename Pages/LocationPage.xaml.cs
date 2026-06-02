namespace FoodDrinkMaui.Pages;

public partial class LocationPage : ContentPage
{
    public LocationPage()
    {
        InitializeComponent();
    }

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                var location = await Geolocation.Default.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });

                if (location != null)
                {
                    LocationLabel.Text = $"Latitude: {location.Latitude:F4}\nLongitude: {location.Longitude:F4}";
                }
                else
                {
                    LocationLabel.Text = "Unable to get location";
                }
            }
            else
            {
                await DisplayAlert("Permission Denied", "Location permission is required", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to get location. Please try again.", "OK");
            LocationLabel.Text = "Location error";
        }
    }
}
