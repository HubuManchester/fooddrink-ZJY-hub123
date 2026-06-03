# Food Explorer

A cross-platform mobile app for discovering recipes and restaurants, built with .NET MAUI.

**Author:** Junyi Zou (21906431)  
**Module:** 6G6Z0014 Mobile Computing — 1CWK100  
**Framework:** .NET 8 MAUI  
**Platforms:** Android · Windows

---

## App Overview

Food Explorer lets users browse, search, and discover recipes from around the world. It also helps find nearby restaurants using GPS. The app makes use of on-board mobile hardware including the camera, location services, haptic feedback, and text-to-speech.

### Key Features

| Feature | Description |
|---------|-------------|
| 🔍 **Search** | Search recipes by name, category, or difficulty |
| 📋 **Browse** | Browse 8 curated recipes with category filtering |
| 🍳 **Recipe Detail** | 5 unique detail interfaces with ingredients, steps, and special tips |
| 📍 **Nearby Restaurants** | View restaurants with GPS location detection |
| 🗺️ **Maps & Phone** | Open maps for directions or call restaurants |
| 📷 **Food Scanner** | Take a photo or pick from gallery to identify food |
| 🌙 **Dark Mode** | Toggle dark/light theme with persistent preference |
| 🔤 **Font Scaling** | Adjust text size for readability |
| 🗣️ **Text-to-Speech** | Listen to cooking instructions read aloud |
| 📳 **Haptic Feedback** | Tactile feedback on button taps |

---

## Development Plan

1. ✅ Set up .NET MAUI project with Shell navigation
2. ✅ Build home page with search and Quick Picks
3. ✅ Create recipe list with CollectionView and category filters
4. ✅ Build recipe detail pages with dynamic data
5. ✅ Add restaurant listings with GPS location
6. ✅ Implement camera page with photo capture/gallery
7. ✅ Add Settings page (Dark Mode + Font Size)
8. ✅ Integrate mobile hardware (Camera, GPS, Haptics, TTS)
9. ✅ Refactor code with data models and service layer
10. ✅ Add accessibility (AutomationId, SemanticProperties)

---

## Mobile Hardware Used

| Hardware | Implementation | Page |
|----------|---------------|------|
| 📷 **Camera** | Take photo / pick from gallery | CameraPage |
| 📍 **Geolocation** | GPS location detection | LocationPage |
| 📳 **Haptic Feedback** | Click feedback on interactive elements | Multiple pages |
| 🗣️ **Text-to-Speech** | Reads cooking instructions aloud | RecipeDetailPage |

---

## Accessibility (WCAG)

The app follows Web Content Accessibility Guidelines principles:

- **AutomationId** on all interactive elements for screen reader identification
- **SemanticProperties.Description** providing context for each control
- **Adjustable font size** via Settings (12px–24px)
- **Dark Mode** support for reduced eye strain
- **High contrast** colour palette with readable text
- **Clear labels** on all buttons and switches

---

## Project Structure

```
FoodDrinkMaui/
├── Models/
│   ├── RecipeItem.cs          # Recipe card data model
│   ├── RecipeDetailData.cs    # Full recipe detail data model
│   └── RestaurantItem.cs      # Restaurant card data model
├── Services/
│   ├── FoodDataService.cs     # Centralised mock data (single source of truth)
│   └── ThemeService.cs        # Dark mode and font size preferences
├── Pages/
│   ├── MainPage.xaml/.cs      # Home page with search and Quick Picks
│   ├── SearchResultsPage      # Search results with CollectionView
│   ├── RecipesListPage        # All recipes with category filter
│   ├── RecipeDetailPage       # Dynamic recipe detail (5 food types)
│   ├── LocationPage           # Nearby restaurants with GPS
│   ├── LocationDetailPage     # GPS coordinate details
│   ├── RestaurantDetailPage   # Restaurant info, phone, directions
│   ├── CameraPage             # Photo capture and gallery
│   └── SettingsPage           # Dark mode, font size, notifications
├── Platforms/
│   ├── Android/               # Android manifest and entry point
│   └── Windows/               # Windows entry point
├── Resources/
│   ├── AppIcon/               # App icon
│   └── Splash/                # Splash screen
└── App.xaml                   # Global styles and colour palette
```

---

## How to Run

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 with MAUI workload (or `dotnet workload install maui`)

### Build & Run
```bash
# Windows
dotnet build -f net8.0-windows10.0.19041.0
dotnet run -f net8.0-windows10.0.19041.0

# Android (requires emulator or device)
dotnet build -f net8.0-android
dotnet run -f net8.0-android
```

### Deployment Demo
The app compiles and runs on **Android emulator** and **Windows**. See the screencast for a full demonstration of both platforms.

---

## Code Quality Notes

- **MVVM-adjacent data models** in `Models/` folder
- **Single source of truth** via `FoodDataService` — no duplicated hardcoded data
- **CollectionView + DataTemplate** for all list pages (code reuse)
- **XML documentation comments** on all public classes, properties, and methods
- **Consistent naming conventions** throughout the codebase
- **Error handling** with try-catch blocks on all hardware API calls
- **Validation** on user input (empty search check)

---

## Submission

- **GitHub:** [Repository link]
- **Screencast:** [mmutube link]
- **Deadline:** 3 June 2026, 22:00
