
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.DTO;
using RecipeFinder.Logic;
using RecipeFinder.Logic.Model;

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMealController : ControllerBase
    {
        private readonly RecipeRepository _repo;
        private readonly ILogger<UserMealController> _logger;

        public UserMealController(RecipeRepository repo, ILogger<UserMealController> logger)
        {
            _repo= repo;
            _logger = logger;
        }



        [HttpGet("meal/{id}")]
        public async Task<ActionResult<UserMeal>> GetMealById(int id)
        {
            var meal = await _repo.GetMealById(id);
            if (meal == null)
            {
                return NotFound();
            }
            return meal;
        }

        [HttpGet("meals")]
        public async Task<ActionResult<List<UserMeal>>> GetMeals()
        {
            try
            {
                return await _repo.GetMeals();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all meals");
                return NotFound(ex.Message);
            }
        }

        [HttpPost("meal")]
        public async Task<ActionResult<bool>> AddMeal(UserMeal meal)
        {
            try
            {
                return await _repo.AddMeal(meal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding meal");
                return NotFound(ex.Message);
            }
        }

        [HttpPut("meal")]
        public async Task<ActionResult<bool>> UpdateMeal(UserMeal meal)
        {
            try
            {
                return await _repo.UpdateMeal(meal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating meal");
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("meal")]
        public async Task<ActionResult<bool>> DeleteMeal(int id)
        {
            try
            {
                return await _repo.DeleteMeal(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting meal");
                return NotFound(ex.Message);
            }
        }

        [HttpGet("meal/userid/{id}")]
        public async Task<ActionResult<List<UserMeal>>> GetMealsByUserID(int id)
        {
            var meal = await _repo.GetMealsByUserID(id);
            if (meal == null)
            {

                return NotFound();
            }
            return meal;
        }

    }
}
