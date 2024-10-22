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
                }
            };
            context.Wines.AddRange(wines);

            // Seed Recipes
            var recipes = new Recipe[]
            {
                new Recipe { Name = "Biefstuk", Description = "Gegrilde biefstuk met kruidenboter", Link = "https://voorbeeld.nl/recepten/biefstuk", Image = "https://voorbeeld.nl/images/biefstuk.jpg", Wines = new Wine[] { wines[0] } }, // Pairing with Chateau Margaux
                new Recipe { Name = "Friet", Description = "Krokant gebakken Belgische frieten", Link = "https://voorbeeld.nl/recepten/friet", Image = "https://voorbeeld.nl/images/friet.jpg", Wines = new Wine[] { wines[1] } }, // Pairing with Pinot Grigio
                new Recipe { Name = "Asperges", Description = "Gestoomde asperges met hollandaise saus", Link = "https://voorbeeld.nl/recepten/asperges", Image = "https://voorbeeld.nl/images/asperges.jpg", Wines = new Wine[] { wines[1] } }, // Pairing with Pinot Grigio
                new Recipe { Name = "Spaghetti", Description = "Spaghetti met klassieke bolognesesaus", Link = "https://voorbeeld.nl/recepten/spaghetti", Image = "https://voorbeeld.nl/images/spaghetti.jpg", Wines = new Wine[] { wines[0] } }, // Pairing with Chateau Margaux
                new Recipe { Name = "Kip", Description = "Geroosterde kip met kruiden", Link = "https://voorbeeld.nl/recepten/kip", Image = "https://voorbeeld.nl/images/kip.jpg", Wines = new Wine[] { wines[0], wines[1] } } // Pairing with both wines
            };
            context.Recipes.AddRange(recipes);

            

            // Seed Favorites
            var favorites = new Favorite[]
            {
                new Favorite {Favorites = new List<Wine> { wines[0], wines[1] } },
                new Favorite {Favorites = new List<Wine> { wines[1] } }
            };
            context.Favorites.AddRange(favorites);

            // Save changes to the database
            context.SaveChanges();
        }
    }
}
