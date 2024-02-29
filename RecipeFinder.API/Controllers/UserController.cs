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
        private readonly ILogger _logger;

        public UserController(RecipeRepository repo, ILogger logger)
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
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _repo.GetAllUsers();
            
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
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


    }
}
