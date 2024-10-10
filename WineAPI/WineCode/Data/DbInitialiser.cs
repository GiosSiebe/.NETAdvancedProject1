using System;
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
                context.Kinds.Any() || context.Recipes.Any() || context.Favorites.Any() || context.Users.Any())
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
            var recipes = new Recipe[]
            {
                new Recipe { Name = "Spaghetti Carbonara", Description = "A creamy pasta dish", Link = "https://dagelijksekost.vrt.be/gerechten/spaghetti-alla-carbonara", Image = "https://www.leukerecepten.nl/app/uploads/2021/06/pasta-carbonara_v.jpg" },
                new Recipe { Name = "Chicken Cordon Bleu", Description = "Chicken wrapped with ham and cheese", Link = "https://www.libelle-lekker.be/bekijk-recept/2588/cordon-bleu", Image = "https://img.static-rmg.be/a/food/image/q75/w640/h400/2424/cordon-bleu.jpg" }
            };
            context.Recipes.AddRange(recipes);

            // Seed Wines
            var wines = new Wine[]
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
                    Categories = new Category[] { categories[0] }, // Red
                    Kind = kinds[1], // Merlot
                    Recipes = new Recipe[] { recipes[0] } // Spaghetti Carbonara
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
                    Categories = new Category[] { categories[1] }, // White
                    Kind = kinds[0], // Sauvignon Blanc
                    Recipes = new Recipe[] { recipes[1] } // Chicken Cordon Bleu
                }
            };
            context.Wines.AddRange(wines);

            // Seed Users
            var users = new User[]
            {
                new User { UserName = "JohnDoe", Password = "12345" },
                new User { UserName = "JaneDoe", Password = "54321" }
            };
            context.Users.AddRange(users);

            // Seed Favorites
            var favorites = new Favorite[]
            {
                new Favorite { User = users[0], Favorites = new List<Wine> { wines[0], wines[1] } },
                new Favorite { User = users[1], Favorites = new List<Wine> { wines[1] } }
            };
            context.Favorites.AddRange(favorites);


            // Save changes to the database
            context.SaveChanges();
        }
    }
}
