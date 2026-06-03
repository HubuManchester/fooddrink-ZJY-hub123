using FoodDrinkMaui.Models;

namespace FoodDrinkMaui.Services;

/// <summary>
/// Centralised mock data service providing all recipe and restaurant data for the app.
/// <para>
/// This is the single source of truth — all pages consume data from this service,
/// eliminating the hardcoded duplication that previously existed across XAML and code-behind files.
/// </para>
/// <para>
/// To add a new food type: add a new entry to <see cref="RecipeDetails"/> and optionally
/// a corresponding <see cref="RecipeItem"/> to <see cref="AllRecipes"/>.
/// </para>
/// </summary>
public static class FoodDataService
{
    // ================================================================
    //  Recipe Detail Data — keyed by food-type identifier string
    //  Each entry contains the complete UI data for RecipeDetailPage
    // ================================================================

    /// <summary>
    /// Complete recipe detail data keyed by food-type identifier (e.g. "burger", "salad").
    /// Each value drives the entire RecipeDetailPage UI for that food type.
    /// </summary>
    public static Dictionary<string, RecipeDetailData> RecipeDetails { get; } = new()
    {
        ["burger"] = new RecipeDetailData
        {
            Emoji = "🍔", HeaderColor = "#FFECB3", AccentColor = "#FF6D00",
            Time = "25 min", Difficulty = "Easy", Servings = "4 servings",
            Rating = "4.8", Reviews = "(245)",
            Description = "A juicy classic beef burger with melted cheddar, crisp lettuce, ripe tomato, and a perfectly toasted bun — the ultimate comfort food.",
            Ingredients = new[] {
                "500g ground beef (80/20 blend)",
                "4 brioche burger buns",
                "4 slices aged cheddar cheese",
                "Lettuce, tomato, red onion",
                "Salt, black pepper, garlic powder"
            },
            Instructions = new[] {
                "Mix ground beef with salt, pepper and garlic powder. Form into 4 patties, making a small indent in the center of each.",
                "Heat a grill or cast-iron pan over medium-high heat. Cook patties for 4-5 minutes per side for medium doneness.",
                "Add cheese on top during the last minute of cooking. Cover with a lid to melt perfectly.",
                "Toast buns with butter until golden. Assemble with lettuce, tomato, onion, and your favorite sauce. Enjoy!"
            },
            FirstInstruction = "Mix ground beef with salt, pepper and garlic powder. Form into 4 patties.",
            SpecialTitle = "👨‍🍳 Chef's Tips", SpecialColor = "#FFF8E1",
            Specials = new (string, string)[] {
                ("🔥", "Don't press down on patties while cooking — you'll squeeze out all the flavorful juices!"),
                ("⏳", "Let cooked patties rest for 3 minutes before serving for maximum juiciness."),
                ("🧈", "Toast your buns with a thin layer of butter for a golden, crispy finish."),
                ("🧀", "Use room-temperature cheese so it melts evenly over the hot patty.")
            }
        },

        ["salad"] = new RecipeDetailData
        {
            Emoji = "🥗", HeaderColor = "#C8E6C9", AccentColor = "#2E7D32",
            Time = "15 min", Difficulty = "Easy", Servings = "2 servings",
            Rating = "4.5", Reviews = "(182)",
            Description = "A refreshing garden-fresh salad with crisp mixed greens, juicy cherry tomatoes, crunchy cucumber, tangy feta cheese, and a light homemade vinaigrette.",
            Ingredients = new[] {
                "200g mixed baby greens (spinach, arugula, romaine)",
                "1 cup cherry tomatoes, halved",
                "1 cucumber, thinly sliced",
                "100g feta cheese, crumbled",
                "3 tbsp extra virgin olive oil + 1 tbsp balsamic vinegar"
            },
            Instructions = new[] {
                "Wash and thoroughly dry all vegetables. Use a salad spinner for best results — wet leaves make a soggy salad.",
                "Toss greens, tomatoes, and cucumber in a large bowl until evenly mixed.",
                "Sprinkle crumbled feta cheese generously over the top.",
                "Drizzle with olive oil and balsamic vinegar just before serving. Toss gently and serve immediately!"
            },
            FirstInstruction = "Wash and thoroughly dry all vegetables. Use a salad spinner for best results.",
            SpecialTitle = "🏷️ Nutrition Facts", SpecialColor = "#E8F5E9",
            Specials = new (string, string)[] {
                ("🔥", "Calories: 320 kcal per serving — light and satisfying."),
                ("💪", "Protein: 12g | Carbs: 18g | Fiber: 6g | Fat: 22g (healthy fats)"),
                ("🥕", "Rich in Vitamin A, Vitamin C, Vitamin K, and folate."),
                ("❤️", "Mediterranean diet approved — heart-healthy and anti-inflammatory.")
            }
        },

        ["pizza"] = new RecipeDetailData
        {
            Emoji = "🍕", HeaderColor = "#FFCCBC", AccentColor = "#C62828",
            Time = "30 min", Difficulty = "Medium", Servings = "6 slices",
            Rating = "4.7", Reviews = "(312)",
            Description = "Authentic Italian-style pizza with a perfectly crispy thin crust, rich San Marzano tomato sauce, fresh mozzarella di bufala, and aromatic basil — baked to bubbly perfection.",
            Ingredients = new[] {
                "300g pizza dough (tipo 00 flour, yeast, water, salt)",
                "150ml San Marzano tomato pizza sauce",
                "200g fresh mozzarella di bufala, torn into pieces",
                "50g pepperoni or prosciutto slices",
                "Fresh basil leaves + extra virgin olive oil for drizzling"
            },
            Instructions = new[] {
                "Preheat oven to 250°C (480°F) with a pizza stone or inverted baking sheet inside for at least 30 minutes.",
                "Stretch dough by hand on floured parchment paper into a 12-inch round. Don't use a rolling pin — it deflates the air bubbles!",
                "Spread tomato sauce evenly leaving a 1-inch border. Arrange torn mozzarella and pepperoni on top.",
                "Slide pizza (on parchment) onto the hot stone. Bake 10-12 minutes until crust is golden and cheese is bubbly. Top with fresh basil and a drizzle of olive oil. Slice and serve hot!"
            },
            FirstInstruction = "Preheat oven to 250°C (480°F) with a pizza stone or inverted baking sheet inside for at least 30 minutes.",
            SpecialTitle = "🍷 Perfect Pairings", SpecialColor = "#FBE9E7",
            Specials = new (string, string)[] {
                ("🍷", "Wine pairing: Chianti Classico or Barbera for red; Pinot Grigio for white."),
                ("🥗", "Side dish: Fresh arugula salad with lemon vinaigrette and shaved Parmesan."),
                ("🫒", "Dip it: Garlic-infused olive oil, ranch, or spicy marinara on the side."),
                ("🍰", "Finish with: Classic tiramisu or affogato for the full Italian experience.")
            }
        },

        ["sushi"] = new RecipeDetailData
        {
            Emoji = "🍣", HeaderColor = "#B3E5FC", AccentColor = "#0277BD",
            Time = "40 min", Difficulty = "Hard", Servings = "32 pieces",
            Rating = "4.9", Reviews = "(178)",
            Description = "Delicate Japanese maki rolls with fresh sashimi-grade salmon, creamy avocado, and perfectly seasoned sushi rice — an elegant dining experience crafted with precision.",
            Ingredients = new[] {
                "300g premium sushi rice, cooked and seasoned with rice vinegar",
                "4 sheets nori seaweed (roasted, premium grade)",
                "200g sashimi-grade salmon, sliced into long strips",
                "1 ripe avocado, thinly sliced",
                "Soy sauce, pickled ginger, wasabi, sesame seeds for serving"
            },
            Instructions = new[] {
                "Cook sushi rice according to package directions. Season with rice vinegar, sugar, and salt while warm. Fan to cool to room temperature — do not refrigerate.",
                "Place nori shiny-side down on a bamboo rolling mat. With wet fingers, spread an even layer of rice covering 3/4 of the nori, leaving a 2cm gap at the far edge.",
                "Arrange salmon and avocado strips in a neat line across the center of the rice. Sprinkle with sesame seeds.",
                "Roll forward tightly using the mat, applying even pressure. Seal the edge with a dab of water. With a sharp, wet knife, slice each roll into 8 even pieces. Serve with soy sauce, pickled ginger, and wasabi on the side."
            },
            FirstInstruction = "Cook sushi rice according to package directions. Season with rice vinegar, sugar, and salt while warm. Fan to cool to room temperature.",
            SpecialTitle = "🥢 Sushi Etiquette", SpecialColor = "#E1F5FE",
            Specials = new (string, string)[] {
                ("🐟", "Dip fish-side down into soy sauce — never rice-side, or the rice will absorb too much and fall apart."),
                ("👄", "Eat each piece in a single bite to experience the full harmony of flavors at once."),
                ("🌸", "Use pickled ginger as a palate cleanser between different types of sushi, not as a topping."),
                ("🌿", "Place wasabi directly on the fish, not mixed into the soy sauce — that's the authentic Japanese way!")
            }
        },

        ["tacos"] = new RecipeDetailData
        {
            Emoji = "🌮", HeaderColor = "#FFE0B2", AccentColor = "#E65100",
            Time = "20 min", Difficulty = "Easy", Servings = "8 tacos",
            Rating = "4.6", Reviews = "(203)",
            Description = "Vibrant Mexican street tacos loaded with perfectly seasoned beef, crisp shredded lettuce, fresh homemade salsa, cool sour cream, and a burst of zesty lime — fiesta in every bite!",
            Ingredients = new[] {
                "8 small corn tortillas (street taco size)",
                "400g ground beef with homemade taco seasoning",
                "2 cups shredded iceberg lettuce",
                "1 cup fresh pico de gallo salsa",
                "Sour cream, fresh lime wedges, chopped cilantro"
            },
            Instructions = new[] {
                "Brown ground beef in a skillet over medium-high heat, breaking it up as it cooks. Drain excess fat, then add taco seasoning and 1/4 cup water. Simmer until sauce thickens, about 3 minutes.",
                "Warm corn tortillas on a dry hot skillet or open flame for 30 seconds each side until slightly charred and pliable.",
                "Fill each tortilla with a generous scoop of seasoned beef as the base layer.",
                "Top generously with shredded lettuce, fresh salsa, a dollop of sour cream, chopped cilantro, and a big squeeze of fresh lime. Serve immediately while hot!"
            },
            FirstInstruction = "Brown ground beef in a skillet over medium-high heat. Drain fat, then add taco seasoning and 1/4 cup water. Simmer until thickened.",
            SpecialTitle = "🌶️ Toppings Bar", SpecialColor = "#FFF3E0",
            Specials = new (string, string)[] {
                ("🥑", "Creamy guacamole or diced avocado — adds richness that balances the spice."),
                ("🌶️", "Pickled jalapeños for extra heat and a tangy crunch."),
                ("🧀", "Crumbled queso fresco or cotija cheese — salty, crumbly, and authentic."),
                ("🔥", "Hot sauce flight: mild (Valentina), medium (Cholula), wild (habanero). Choose your adventure!")
            }
        },

        ["pasta"] = new RecipeDetailData
        {
            Emoji = "🍝", HeaderColor = "#FFECB3", AccentColor = "#BF360C",
            Time = "35 min", Difficulty = "Medium", Servings = "4 servings",
            Rating = "4.7", Reviews = "(267)",
            Description = "Al dente pasta tossed in a rich, slow-simmered sauce with aromatic herbs and freshly grated Parmigiano-Reggiano — Italian comfort in a bowl.",
            Ingredients = new[] {
                "400g pasta (spaghetti, fettuccine, or penne)",
                "3 tbsp extra virgin olive oil",
                "4 garlic cloves, minced + 1 onion, diced",
                "800g canned San Marzano tomatoes, crushed",
                "Fresh basil, grated Parmigiano-Reggiano, red pepper flakes"
            },
            Instructions = new[] {
                "Bring a large pot of generously salted water to a rolling boil. Cook pasta until al dente, about 8-10 minutes. Reserve 1 cup of pasta water before draining.",
                "While pasta cooks, heat olive oil in a large pan. Sauté onion until translucent, then add garlic until fragrant (1 minute).",
                "Add crushed tomatoes, simmer for 15-20 minutes until thickened. Season with salt, pepper, and red pepper flakes.",
                "Toss drained pasta into the sauce with a splash of reserved pasta water. Stir vigorously to emulsify. Serve topped with fresh basil and generous grated Parmigiano."
            },
            FirstInstruction = "Bring a large pot of generously salted water to a rolling boil. Cook pasta until al dente following package directions.",
            SpecialTitle = "🇮🇹 Italian Secrets", SpecialColor = "#FFF8E1",
            Specials = new (string, string)[] {
                ("💧", "Always reserve pasta water! The starchy liquid is liquid gold for creating a silky, emulsified sauce."),
                ("🧂", "Salt your pasta water like the sea — this is your only chance to season the pasta itself from within."),
                ("🧀", "Never buy pre-grated cheese. Grate Parmigiano-Reggiano fresh for superior flavor and texture."),
                ("⏱️", "Finish cooking the pasta IN the sauce for the last 1-2 minutes — it absorbs more flavor.")
            }
        },

        ["chicken"] = new RecipeDetailData
        {
            Emoji = "🍗", HeaderColor = "#C8E6C9", AccentColor = "#558B2F",
            Time = "30 min", Difficulty = "Medium", Servings = "4 servings",
            Rating = "4.4", Reviews = "(156)",
            Description = "Juicy, golden-seared chicken breast with a herb-infused marinade, served with roasted vegetables — healthy never tasted this good.",
            Ingredients = new[] {
                "4 boneless, skinless chicken breasts",
                "3 tbsp olive oil + 2 tbsp lemon juice",
                "Fresh rosemary, thyme, garlic (minced)",
                "1 tsp paprika, salt, black pepper",
                "Roasted vegetables: bell peppers, zucchini, red onion"
            },
            Instructions = new[] {
                "Marinate chicken breasts with olive oil, lemon juice, minced garlic, rosemary, thyme, paprika, salt, and pepper. Let sit for 15-30 minutes.",
                "Heat a grill pan or cast-iron skillet over medium-high heat. Sear chicken for 6-7 minutes per side until golden brown and internal temp reaches 75°C (165°F).",
                "Meanwhile, toss chopped bell peppers, zucchini, and red onion with olive oil, salt, and pepper. Roast at 200°C (400°F) for 20 minutes.",
                "Let chicken rest for 5 minutes before slicing. Plate alongside roasted vegetables and drizzle with pan juices. Garnish with fresh herbs!"
            },
            FirstInstruction = "Marinate chicken breasts with olive oil, lemon juice, garlic, and herbs for at least 15 minutes.",
            SpecialTitle = "🔪 Pro Techniques", SpecialColor = "#E8F5E9",
            Specials = new (string, string)[] {
                ("🥩", "Pound chicken breasts to even thickness before marinating — ensures uniform cooking."),
                ("🌡️", "Use a meat thermometer! 75°C (165°F) is the sweet spot — juicy and fully safe."),
                ("⏳", "Never skip the resting step — it redistributes juices throughout the meat."),
                ("🍋", "Brighten the dish with a final squeeze of fresh lemon and a sprinkle of flaky sea salt.")
            }
        },

        ["dessert"] = new RecipeDetailData
        {
            Emoji = "🍰", HeaderColor = "#F3E5F5", AccentColor = "#6A1B9A",
            Time = "45 min", Difficulty = "Medium", Servings = "8 slices",
            Rating = "4.9", Reviews = "(421)",
            Description = "Decadent layered chocolate cake with silky ganache frosting, moist crumb, and a secret ingredient that takes it over the top — pure bliss in every forkful.",
            Ingredients = new[] {
                "200g dark chocolate (70% cocoa), chopped",
                "200g unsalted butter, softened",
                "4 large eggs + 200g caster sugar",
                "150g all-purpose flour + 1 tsp baking powder",
                "200ml heavy cream (for ganache) + cocoa powder for dusting"
            },
            Instructions = new[] {
                "Preheat oven to 180°C (350°F). Grease and line two 8-inch round cake pans with parchment paper.",
                "Melt chocolate and butter together over a double boiler or in 30-second microwave bursts. Stir until smooth. Let cool slightly.",
                "Whisk eggs and sugar until pale and fluffy. Fold in melted chocolate mixture, then sift in flour and baking powder. Fold gently until just combined.",
                "Divide batter between pans. Bake 22-25 minutes. Cool completely. For ganache: heat cream until simmering, pour over chopped chocolate, stir until glossy. Spread between layers and over the cake. Dust with cocoa powder!"
            },
            FirstInstruction = "Preheat oven to 180°C (350°F). Grease and line two 8-inch round cake pans with parchment paper.",
            SpecialTitle = "🍫 Baking Secrets", SpecialColor = "#F3E5F5",
            Specials = new (string, string)[] {
                ("☕", "Add 1 tsp of instant espresso powder to the batter — it intensifies the chocolate flavor without tasting like coffee."),
                ("🌡️", "All ingredients at room temperature! Cold eggs or butter will cause the batter to seize."),
                ("⏲️", "Don't overbake! The cake continues cooking from residual heat after it leaves the oven."),
                ("🧊", "Chill the cake for 30 minutes before slicing for the cleanest, most beautiful cuts.")
            }
        }
    };

    // ================================================================
    //  Recipe List Items — for CollectionView-based list pages
    // ================================================================

    /// <summary>
    /// Complete list of all recipes shown in the Recipe List and Search Results pages.
    /// Each entry maps to a card in the CollectionView.
    /// </summary>
    public static List<RecipeItem> AllRecipes { get; } = new()
    {
        new() { Name = "Classic Beef Burger",   Emoji = "🍔", Time = "25 min", Difficulty = "Easy",   Category = "American", Rating = "4.8", Reviews = "(245)", ColorHex = "#FFECB3" },
        new() { Name = "Margherita Pizza",      Emoji = "🍕", Time = "30 min", Difficulty = "Medium", Category = "Italian",  Rating = "4.7", Reviews = "(312)", ColorHex = "#FFCCBC" },
        new() { Name = "Garden Fresh Salad",    Emoji = "🥗", Time = "15 min", Difficulty = "Easy",   Category = "Healthy",  Rating = "4.5", Reviews = "(182)", ColorHex = "#C8E6C9" },
        new() { Name = "Salmon Maki Sushi",     Emoji = "🍣", Time = "40 min", Difficulty = "Hard",   Category = "Japanese", Rating = "4.9", Reviews = "(178)", ColorHex = "#B3E5FC" },
        new() { Name = "Street Style Tacos",    Emoji = "🌮", Time = "20 min", Difficulty = "Easy",   Category = "Mexican",  Rating = "4.6", Reviews = "(203)", ColorHex = "#FFE0B2" },
        new() { Name = "Spaghetti Bolognese",   Emoji = "🍝", Time = "35 min", Difficulty = "Medium", Category = "Italian",  Rating = "4.7", Reviews = "(267)", ColorHex = "#FFECB3" },
        new() { Name = "Crispy Chicken Burger", Emoji = "🍗", Time = "30 min", Difficulty = "Medium", Category = "American", Rating = "4.4", Reviews = "(156)", ColorHex = "#C8E6C9" },
        new() { Name = "Chocolate Lava Cake",   Emoji = "🍰", Time = "25 min", Difficulty = "Medium", Category = "Dessert",  Rating = "4.9", Reviews = "(421)", ColorHex = "#D7CCC8" },
    };

    // ================================================================
    //  Quick Picks — 5 featured items for MainPage horizontal scroll
    // ================================================================

    /// <summary>
    /// Five featured recipes shown in the Quick Picks horizontal scroll on the home page.
    /// </summary>
    public static List<RecipeItem> QuickPicks { get; } = new()
    {
        new() { Name = "Classic Beef Burger", Emoji = "🍔", Time = "25 min", Difficulty = "Easy",   Category = "Burger",  Rating = "4.8", Reviews = "(245)", ColorHex = "#FFECB3" },
        new() { Name = "Garden Fresh Salad",  Emoji = "🥗", Time = "15 min", Difficulty = "Easy",   Category = "Salad",   Rating = "4.5", Reviews = "(182)", ColorHex = "#C8E6C9" },
        new() { Name = "Margherita Pizza",    Emoji = "🍕", Time = "30 min", Difficulty = "Medium", Category = "Pizza",   Rating = "4.7", Reviews = "(312)", ColorHex = "#FFCDD2" },
        new() { Name = "Salmon Maki Sushi",   Emoji = "🍣", Time = "40 min", Difficulty = "Hard",   Category = "Sushi",   Rating = "4.9", Reviews = "(178)", ColorHex = "#E1F5FE" },
        new() { Name = "Street Style Tacos",  Emoji = "🌮", Time = "20 min", Difficulty = "Easy",   Category = "Tacos",   Rating = "4.6", Reviews = "(203)", ColorHex = "#FFE0B2" },
    };

    // ================================================================
    //  Restaurant List — for LocationPage CollectionView
    // ================================================================

    /// <summary>
    /// List of restaurants shown on the Nearby Restaurants page.
    /// </summary>
    public static List<RestaurantItem> Restaurants { get; } = new()
    {
        new() { Name = "Golden Dragon Restaurant", Cuisine = "Chinese Cuisine",   Rating = "4.5", Distance = "0.5 km away", Status = "Open Now",      Emoji = "🐉", ColorHex = "#FFECB3" },
        new() { Name = "Sakura Sushi Bar",         Cuisine = "Japanese Cuisine",  Rating = "4.8", Distance = "0.8 km away", Status = "Open Now",      Emoji = "🍣", ColorHex = "#E1F5FE" },
        new() { Name = "Pizza Paradise",           Cuisine = "Italian Cuisine",   Rating = "4.3", Distance = "1.2 km away", Status = "Closes at 10PM", Emoji = "🍕", ColorHex = "#FCE4EC" },
        new() { Name = "Burger Palace",            Cuisine = "American Fast Food",Rating = "4.6", Distance = "1.5 km away", Status = "Open 24h",      Emoji = "🍔", ColorHex = "#F3E5F5" },
    };

    // ================================================================
    //  Search — filters AllRecipes by query string
    // ================================================================

    /// <summary>
    /// Filters <see cref="AllRecipes"/> by a search query, matching against
    /// recipe name, category, and difficulty (case-insensitive).
    /// Returns all recipes if the query is empty or whitespace.
    /// </summary>
    /// <param name="query">User's search input from the home page search bar.</param>
    /// <returns>Filtered list of matching recipes.</returns>
    public static List<RecipeItem> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return AllRecipes;

        string q = query.ToLower().Trim();
        return AllRecipes
            .Where(r =>
                r.Name.ToLower().Contains(q) ||
                r.Category.ToLower().Contains(q) ||
                r.Difficulty.ToLower().Contains(q))
            .ToList();
    }

    // ================================================================
    //  Lookup — resolves a recipe name to its detail data
    // ================================================================

    /// <summary>
    /// Resolves a recipe name to its full <see cref="RecipeDetailData"/> by
    /// detecting the food type from keywords in the name.
    /// Falls back to burger data if no match is found.
    /// </summary>
    /// <param name="recipeName">The recipe name (e.g. "Classic Beef Burger").</param>
    /// <returns>The matching RecipeDetailData, or burger data as default.</returns>
    public static RecipeDetailData GetDetail(string recipeName)
    {
        string key = DetectFoodType(recipeName);
        return RecipeDetails.TryGetValue(key, out var data) ? data : RecipeDetails["burger"];
    }

    /// <summary>
    /// Detects the food type identifier from a recipe name using keyword matching.
    /// </summary>
    private static string DetectFoodType(string name)
    {
        string n = name.ToLower();
        if (n.Contains("burger")) return "burger";
        if (n.Contains("salad")) return "salad";
        if (n.Contains("pizza")) return "pizza";
        if (n.Contains("sushi")) return "sushi";
        if (n.Contains("taco")) return "tacos";
        if (n.Contains("noodle") || n.Contains("soup") || n.Contains("pasta") || n.Contains("spaghetti")) return "pasta";
        if (n.Contains("chicken")) return "chicken";
        if (n.Contains("cake") || n.Contains("chocolate") || n.Contains("dessert")) return "dessert";
        return "burger";
    }
}
