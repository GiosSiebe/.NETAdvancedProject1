using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var recipes = _uow.RecipeRepository.GetAll();
            return Ok(recipes);
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            var recipe = _uow.RecipeRepository.GetByID(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT: api/Recipes/5
        [HttpPut("{id}")]
        public IActionResult PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            _uow.RecipeRepository.Update(recipe);

            try
            {
                _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recipes
        [HttpPost]
        public ActionResult<Recipe> PostRecipe(Recipe recipe)
        {
            _uow.RecipeRepository.Insert(recipe);
            _uow.Save();

            return CreatedAtAction("GetRecipe", new { id = recipe.RecipeId }, recipe);
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
