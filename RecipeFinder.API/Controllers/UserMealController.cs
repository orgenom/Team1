
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
        private readonly ILogger<RecipeRepository> _logger;
        private readonly EmailObject _emailObject;
        private readonly MealDBObject _mealDBObject;

        public UserMealController(RecipeRepository repo, ILogger<RecipeRepository> logger)
        {
            _repo= repo;
            _logger = logger;
            _emailObject = new EmailObject(_repo._configuration["BrevoKey"] ?? "");
            _mealDBObject = new MealDBObject();
        }



        [HttpGet("meal/{id}")]
        public async Task<ActionResult<Meal>> GetMealById(int id)
        {
            var meal = await _repo.GetMealById(id);
            if (meal == null)
            {
                return NotFound();
            }
            return meal;
        }

        [HttpGet("meals")]
        public async Task<ActionResult<List<Meal>>> GetMeals()
        {
            try
            {
                return await _repo.GetMeals();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("meal")]
        public async Task<ActionResult<bool>> AddMeal(Meal meal)
        {
            try
            {
                return await _repo.AddMeal(meal);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("meal")]
        public async Task<ActionResult<bool>> UpdateMeal(Meal meal)
        {
            try
            {
                return await _repo.UpdateMeal(meal);
            }
            catch (Exception ex)
            {
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
                return NotFound(ex.Message);
            }
        }


    }
}
