using Microsoft.AspNetCore.Mvc;
using RecipeFinder.DTO;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly RecipeRepository _repo;
        private readonly ILogger<UserController> _logger;

        public UserController(RecipeRepository repo, ILogger<UserController> logger)
        {

            _repo = repo;
            _logger = logger;

        }

        //get user by id
        //get all users
        //add user
        //update user
        //delete user

        [HttpGet("user/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                List<User> users = await _repo.GetAllUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all users");
                return StatusCode(500, "AHHHHHHHHHHHHHH");
            }
        }

        [HttpPost("user")]
        public async Task<ActionResult<bool>> AddUser(User user)
        {
            try
            {
                return Ok(await _repo.Register(user));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("user")]
        public async Task<ActionResult<bool>> UpdateUser(User user)
        {
            try
            {
                return Ok(await _repo.UpdateUser(user));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("user")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            try
            {
                return Ok(await _repo.DeleteUser(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("login/{username}/{password}")]
        public async Task<ActionResult<User>> Login(string username, string password)
        {
            try
            {
                return Ok(await _repo.Login(username, password));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
