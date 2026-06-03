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
                    // Load and display the image properly
                    CapturedImage.Source = ImageSource.FromFile(photo.FullPath);
                    CapturedImage.Aspect = Aspect.AspectFit;
                    CapturedImage.IsVisible = true;
                    CameraPlaceholder.IsVisible = false;
                    CornerGuides.IsVisible = false;
                    DeleteButton.IsVisible = true;
                    
                    ResultFrame.IsVisible = true;
                    ResultLabel.Text = "Analyzing your food...";
                    
                    // Simulate food recognition
                    await Task.Delay(1500);
                    ResultLabel.Text = "Detected: Burger, Fries, Salad";
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
        }
    }

    private async void OnPickPhotoClicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();

            if (photo != null)
            {
                // Load and display the image properly - AspectFit shows full image without cropping
                CapturedImage.Source = ImageSource.FromFile(photo.FullPath);
                CapturedImage.Aspect = Aspect.AspectFit;
                CapturedImage.IsVisible = true;
                CameraPlaceholder.IsVisible = false;
                CornerGuides.IsVisible = false;
                DeleteButton.IsVisible = true;
                
                ResultFrame.IsVisible = true;
                ResultLabel.Text = "Analyzing your food photo...";
                
                // Simulate food recognition
                await Task.Delay(1500);
                ResultLabel.Text = "Food identified! Tap to see recipe suggestions.";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to pick photo. Please try again.", "OK");
        }
    }
    
    private void OnDeletePhotoClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        
        // Reset to initial state
        CapturedImage.Source = null;
        CapturedImage.IsVisible = false;
        CameraPlaceholder.IsVisible = true;
        CornerGuides.IsVisible = true;
        DeleteButton.IsVisible = false;
        ResultFrame.IsVisible = false;
        ResultLabel.Text = "";
    }
}
