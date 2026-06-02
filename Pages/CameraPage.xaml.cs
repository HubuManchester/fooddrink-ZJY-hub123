namespace FoodDrinkMaui.Pages;

public partial class CameraPage : ContentPage
{
    public CameraPage()
    {
        InitializeComponent();
    }

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    CapturedImage.Source = ImageSource.FromStream(() => stream);
                    CapturedImage.IsVisible = true;
                    ResultLabel.Text = "Photo captured successfully!";
                }
            }
            else
            {
                await DisplayAlert("Error", "Camera not supported on this device", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to take photo. Please try again.", "OK");
            ResultLabel.Text = "";
        }
    }

    private async void OnPickPhotoClicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();

            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                CapturedImage.Source = ImageSource.FromStream(() => stream);
                CapturedImage.IsVisible = true;
                ResultLabel.Text = "Photo selected successfully!";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to pick photo. Please try again.", "OK");
            ResultLabel.Text = "";
        }
    }
}
