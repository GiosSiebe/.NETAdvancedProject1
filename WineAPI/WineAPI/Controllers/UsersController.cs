using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineAPI.Services;
using WineCode.DAL; // Zorg ervoor dat dit overeenkomt met jouw namespace
using WineCode.Models;

namespace WineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private IUserService _userService;

        public UsersController(IUnitOfWork uow, IUserService userService)
        {
            _userService = userService;
            _uow = uow;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            var user = _userService.Authenticate(userParam.UserName, userParam.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _uow.UserRepository.GetAll();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _uow.UserRepository.GetByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _uow.UserRepository.Update(user);

            try
            {
                _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _uow.UserRepository.Insert(user);
            _uow.Save();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _uow.UserRepository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            _uow.UserRepository.Delete(id);
            _uow.Save();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _uow.UserRepository.GetByID(id) != null;
        }
    }
}
