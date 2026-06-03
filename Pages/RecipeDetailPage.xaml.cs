using FoodDrinkMaui.Models;
using FoodDrinkMaui.Services;

namespace FoodDrinkMaui.Pages;

public partial class RecipeDetailPage : ContentPage
{
    private RecipeDetailData _data = null!;

    public RecipeDetailPage(string recipeName)
    {
        InitializeComponent();
        RecipeTitle.Text = recipeName;
        Title = recipeName;

        // Single data-driven call — replaces 8 hardcoded LoadXxx() methods
        _data = FoodDataService.GetDetail(recipeName);
        LoadRecipe(_data);
    }

    private void LoadRecipe(RecipeDetailData d)
    {
        // Header
        RecipeEmoji.Text = d.Emoji;
        HeaderFrame.BackgroundColor = Color.FromArgb(d.HeaderColor);
        RatingBadge.BackgroundColor = Color.FromArgb(d.AccentColor);

        // Info row
        TimeLabel.Text = d.Time;
        DifficultyLabel.Text = d.Difficulty;
        ServingsLabel.Text = d.Servings;
        RatingScore.Text = d.Rating;
        RatingCount.Text = d.Reviews;

        // Description
        DescLabel.Text = d.Description;

        // Ingredients
        IngredientsStack.Children.Clear();
        foreach (string ing in d.Ingredients)
            AddIngredient(ing);

        // Instructions
        InstructionsStack.Children.Clear();
        for (int i = 0; i < d.Instructions.Length; i++)
            AddInstruction((i + 1).ToString(), d.Instructions[i], d.AccentColor);

        // Special section
        SpecialTitle.Text = d.SpecialTitle;
        SpecialFrame.BackgroundColor = Color.FromArgb(d.SpecialColor);
        SpecialStack.Children.Clear();
        foreach (var (emoji, text) in d.Specials)
            AddSpecialItem(emoji, text);
    }

    // --- UI builders ---
    private void AddIngredient(string text)
    {
        var grid = new Grid
        {
            ColumnDefinitions = { new ColumnDefinition(GridLength.Auto), new ColumnDefinition(GridLength.Star) },
            ColumnSpacing = 12
        };

        var check = new Frame
        {
            BackgroundColor = Color.FromArgb("#E8F5E9"), CornerRadius = 8,
            Padding = new Thickness(6), HasShadow = false,
            Margin = new Thickness(0, 0, 12, 0), WidthRequest = 28, HeightRequest = 28
        };
        check.Content = new Label { Text = "✓", FontSize = 12, TextColor = Color.FromArgb("#2E7D32"),
            HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
        Grid.SetColumn(check, 0);

        var label = new Label { Text = text, FontSize = 15,
            TextColor = (Color)Application.Current!.Resources["TextPrimary"],
            VerticalOptions = LayoutOptions.Center };
        Grid.SetColumn(label, 1);

        grid.Children.Add(check);
        grid.Children.Add(label);
        IngredientsStack.Children.Add(grid);
    }

    private void AddInstruction(string number, string text, string accentColor)
    {
        var grid = new Grid
        {
            ColumnDefinitions = { new ColumnDefinition(new GridLength(40)), new ColumnDefinition(GridLength.Star) },
            ColumnSpacing = 12
        };

        var num = new Frame
        {
            BackgroundColor = Color.FromArgb(accentColor), CornerRadius = 20,
            Padding = new Thickness(0), HasShadow = false, HeightRequest = 40, WidthRequest = 40
        };
        num.Content = new Label { Text = number, FontSize = 16, FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
        Grid.SetColumn(num, 0);

        var label = new Label { Text = text, FontSize = 14,
            TextColor = (Color)Application.Current!.Resources["TextPrimary"],
            VerticalOptions = LayoutOptions.Center };
        Grid.SetColumn(label, 1);

        grid.Children.Add(num);
        grid.Children.Add(label);
        InstructionsStack.Children.Add(grid);
    }

    private void AddSpecialItem(string emoji, string text)
    {
        var grid = new Grid
        {
            ColumnDefinitions = { new ColumnDefinition(GridLength.Auto), new ColumnDefinition(GridLength.Star) },
            ColumnSpacing = 10, Padding = new Thickness(0, 4)
        };

        var em = new Label { Text = emoji, FontSize = 18,
            VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.Center, WidthRequest = 30 };
        Grid.SetColumn(em, 0);

        var tx = new Label { Text = text, FontSize = 13,
            TextColor = (Color)Application.Current!.Resources["TextSecondary"],
            VerticalOptions = LayoutOptions.Center, LineBreakMode = LineBreakMode.WordWrap };
        Grid.SetColumn(tx, 1);

        grid.Children.Add(em);
        grid.Children.Add(tx);
        SpecialStack.Children.Add(grid);
    }

    // --- Actions ---
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }
        await DisplayAlert("Saved!", $"{RecipeTitle.Text} has been added to your favorites.", "OK");
    }

    private async void OnStartCookingClicked(object sender, EventArgs e)
    {
        try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }

        try
        {
            // Read out the recipe title and first step via Text-to-Speech
            string text = $"Let's start cooking {RecipeTitle.Text}. Step 1: {_data.FirstInstruction}";
            await TextToSpeech.Default.SpeakAsync(text);
        }
        catch (Exception)
        {
            // TTS may fail if no voice engine is installed on the device
            await DisplayAlert("Voice Unavailable",
                "Text-to-Speech engine not found. Install 'Google Text-to-Speech' from the Play Store, then go to Settings → System → Languages → Text-to-Speech to download voice data.", "OK");
        }
    }
}
