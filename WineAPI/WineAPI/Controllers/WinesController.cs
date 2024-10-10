using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCode.DAL;
using WineCode.Models;

namespace WineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public WinesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Wines
        [HttpGet]
        public ActionResult<IEnumerable<Wine>> GetWines()
        {
            var wines = _uow.WineRepository.GetAll();
            return Ok(wines);
        }

        // GET: api/Wines/5
        [HttpGet("{id}")]
        public ActionResult<Wine> GetWine(int id)
        {
            var wine = _uow.WineRepository.GetByID(id);

            if (wine == null)
            {
                return NotFound();
            }

            return Ok(wine);
        }

        // PUT: api/Wines/5
        [HttpPut("{id}")]
        public IActionResult PutWine(int id, Wine wine)
        {
            if (id != wine.WineID)
            {
                return BadRequest();
            }

            _uow.WineRepository.Update(wine);

            try
            {
                _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineExists(id))
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

        // POST: api/Wines
        [HttpPost]
        public ActionResult<Wine> PostWine(Wine wine)
        {
            _uow.WineRepository.Insert(wine);
            _uow.Save();

            return CreatedAtAction("GetWine", new { id = wine.WineID }, wine);
        }

        // DELETE: api/Wines/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWine(int id)
        {
            var wine = _uow.WineRepository.GetByID(id);
            if (wine == null)
            {
                return NotFound();
            }

            _uow.WineRepository.Delete(id);
            _uow.Save();

            return NoContent();
        }

        private bool WineExists(int id)
        {
            return _uow.WineRepository.GetByID(id) != null;
        }
    }
}
