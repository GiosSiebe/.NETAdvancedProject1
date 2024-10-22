using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WineCode.DAL;
using WineCode.Models;

namespace WineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RecipesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Recipes
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetRecipes()
        {
            // Include the Wines navigation property when retrieving recipes
            var recipes = _uow.RecipeRepository.Get(includes: r => r.Wines);
            return Ok(recipes);
        }

        // POST: api/Recipes
        [HttpPost]
        public ActionResult<Recipe> PostRecipe(Recipe recipe)
        {
            _uow.RecipeRepository.Insert(recipe);
            _uow.Save();
            return CreatedAtAction("GetRecipe", new { id = recipe.RecipeId }, recipe);
        }

        // GET: api/Recipes/name/{name}
        [HttpGet("{name}")]
        public ActionResult<Recipe> GetRecipeByName(string name)
        {
            var recipe = _uow.RecipeRepository
                .Get(r => r.Name.Contains(name),
                     includes: r => r.Wines) // Include Wines
                .FirstOrDefault();

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = _uow.RecipeRepository.GetByID(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _uow.RecipeRepository.Delete(id);
            _uow.Save();
            return NoContent();
        }

        private bool RecipeExists(int id)
        {
            return _uow.RecipeRepository.GetByID(id) != null;
        }
    }
}
