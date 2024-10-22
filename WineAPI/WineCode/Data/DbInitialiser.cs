using System;
using System.Collections.Generic;
using System.Linq;
using WineCode.Models;

namespace WineCode.Data
{
    public static class DbInitialiser
    {
        public static void Initialize(WineContext context)
        {
            context.Database.EnsureCreated();

            // Check if there is already data in the database
            if (context.Wines.Any() || context.Categories.Any() || context.Countries.Any() ||
                context.Kinds.Any() || context.Recipes.Any() || context.Favorites.Any())
            {
                return; // DB has been seeded
            }

            // Seed Categories
            var categories = new Category[]
            {
                new Category { Name = "Red" },
                new Category { Name = "White" },
                new Category { Name = "Vegan" }
            };
            context.Categories.AddRange(categories);

            // Seed Countries
            var countries = new Country[]
            {
                new Country { Name = "France" },
                new Country { Name = "Italy" },
                new Country { Name = "Spain" }
            };
            context.Countries.AddRange(countries);

            // Seed Kinds
            var kinds = new Kind[]
            {
                new Kind { Name = "Sauvignon Blanc" },
                new Kind { Name = "Merlot" },
                new Kind { Name = "Chardonnay" }
            };
            context.Kinds.AddRange(kinds);

            // Seed Recipes
            var recipes = new List<Recipe>
            {
                new Recipe { Name = "Spaghetti Carbonara", Description = "A creamy pasta dish",
                    Link = "https://dagelijksekost.vrt.be/gerechten/spaghetti-alla-carbonara",
                    Image = "https://www.leukerecepten.nl/app/uploads/2021/06/pasta-carbonara_v.jpg" },
                new Recipe { Name = "Chicken Cordon Bleu", Description = "Chicken wrapped with ham and cheese",
                    Link = "https://www.libelle-lekker.be/bekijk-recept/2588/cordon-bleu",
                    Image = "https://img.static-rmg.be/a/food/image/q75/w640/h400/2424/cordon-bleu.jpg" },
                new Recipe { Name = "Biefstuk", Description = "Juicy steak cooked to perfection",
                    Link = "https://www.example.com/biefstuk-recept", // Replace with a real link
                    Image = "https://www.example.com/images/biefstuk.jpg" }, // Replace with a real image
                new Recipe { Name = "Asperges", Description = "Fresh asparagus served with hollandaise sauce",
                    Link = "https://www.example.com/asperges-recept", // Replace with a real link
                    Image = "https://www.example.com/images/asperges.jpg" }, // Replace with a real image
                new Recipe { Name = "Friet", Description = "Crispy Belgian fries",
                    Link = "https://www.example.com/friet-recept", // Replace with a real link
                    Image = "https://www.example.com/images/friet.jpg" }, // Replace with a real image
                new Recipe { Name = "Kip", Description = "Delicious roasted chicken",
                    Link = "https://www.example.com/kip-recept", // Replace with a real link
                    Image = "https://www.example.com/images/kip.jpg" }, // Replace with a real image
                new Recipe { Name = "Spaghetti", Description = "Classic spaghetti with tomato sauce",
                    Link = "https://www.example.com/spaghetti-recept", // Replace with a real link
                    Image = "https://www.example.com/images/spaghetti.jpg" } // Replace with a real image
            };
            context.Recipes.AddRange(recipes);

            // Seed Wines
            var wines = new List<Wine>
            {
                new Wine
                {
                    Name = "Chateau Margaux",
                    Description = "A famous French red wine",
                    TasteProfile = "Rich and complex",
                    Image = "https://www.topwijnen.be/media/cache/product_detail/b/0/9/e/b09e54296c8c63ced5db824aafc4fd69769146eb_Margaux_02.png",
                    Link = "https://www.topwijnen.be/fr/produit/wijnen/frankrijk/bordeaux/medoc/margaux/pavillon-rouge-de-ch-margaux/WN1002416?srsltid=AfmBOor7ADM0CHbO8B2XFVJk2HsG2KwRkAYnol5d1kJQgTs5eqoPclMJ4SA",
                    Price = "$120",
                    Country = countries[0], // France
                    Categories = new List<Category> { categories[0] }, // Red
                    Kind = kinds[1], // Merlot
                  
                },
                new Wine
                {
                    Name = "Pinot Grigio",
                    Description = "A light white wine",
                    TasteProfile = "Crisp and fresh",
                    Image = "https://www.wijnbeurs.be/media/catalog/product/K/2/K200777_2023_bella_vittoria_pinot_grigio_edit.png?quality=95&fit=bounds&height=560&width=700&bg-color=FFF",
                    Link = "https://www.wijnbeurs.be/bella-vittoria-pinot-grigio-delle-venezie",
                    Price = "$45",
                    Country = countries[1], // Italy
                    Categories = new List<Category> { categories[1] }, // White
                    Kind = kinds[0], // Sauvignon Blanc
                    
                }
            };
            context.Wines.AddRange(wines);

            // Seed Favorites
            var favorites = new List<Favorite>
            {
                new Favorite { Favorites = new List<Wine> { wines[0], wines[1] } },
                new Favorite { Favorites = new List<Wine> { wines[1] } }
            };
            context.Favorites.AddRange(favorites);

            // Save changes to the database
            context.SaveChanges();
        }
    }
}
