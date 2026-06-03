using FoodDrinkMaui.Models;
using FoodDrinkMaui.Services;

namespace FoodDrinkMaui.Pages;

public partial class LocationPage : ContentPage
{
    public LocationPage()
    {
        InitializeComponent();
        RestaurantsCollection.ItemsSource = FoodDataService.Restaurants;
    }

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
            {
                LocationLabel.Text = "Detecting...";

                var location = await Geolocation.Default.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });

                if (location != null)
                {
                    LocationLabel.Text = $"Latitude: {location.Latitude:F4}\nLongitude: {location.Longitude:F4}";

                    try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
                    await Navigation.PushAsync(new LocationDetailPage(location.Latitude, location.Longitude));
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
        catch (Exception)
        {
            await DisplayAlert("Error", "Failed to get location. Please try again.", "OK");
            LocationLabel.Text = "Location error";
        }
    }

    private async void OnRestaurantClicked(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.GestureRecognizers[0] is TapGestureRecognizer tap)
        {
            // CommandParameter is now the RestaurantItem object itself
            if (tap.CommandParameter is RestaurantItem r)
            {
                try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
                await Navigation.PushAsync(new RestaurantDetailPage(r.Name, r.Cuisine, r.Rating, r.Distance, r.Status));
            }
        }
    }
}
