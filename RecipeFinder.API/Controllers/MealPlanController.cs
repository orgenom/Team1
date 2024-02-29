using Microsoft.AspNetCore.Mvc;
using RecipeFinder.DTO;
using RecipeFinder.Logic;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MealPlanController : ControllerBase
    {

        private readonly RecipeRepository _repo;
        private readonly ILogger<MealPlanController> _logger;

        public MealPlanController(RecipeRepository repo, ILogger<MealPlanController> logger)
        {

            _repo = repo;
            _logger = logger;

        }

        //get mealplans by user id
        //get all mealplans
        //add mealplan
        //update mealplan
        //delete meal plan

        [HttpGet("mealplan/{user_id}")]
        public async Task<ActionResult<List<MealPlan>>> GetMealPlansByUserID(int id)
        {
            var mealplan = await _repo.GetMealPlansByUserID(id);
            if (mealplan == null)
            {
                return NotFound();
            }
            return mealplan;
        }

        [HttpGet("mealplans")]
        public async Task<ActionResult<List<MealPlan>>> GetAllMealPlans()
        {
            var mealplans = await _repo.GetMealPlans();
            if (mealplans == null)
            {
                return NotFound();
            }
            return mealplans;
        }

        [HttpPost("mealplan")]
        public async Task<ActionResult<bool>> AddMealPlan(MealPlan mealplan)
        {
            try
            {
                return await _repo.AddMealPlan(mealplan);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("mealplan")]
        public async Task<ActionResult<bool>> UpdateMealPlan(MealPlan mealplan)
        {
            try
            {
                return await _repo.UpdateMealPlan(mealplan);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("mealplan")]
        public async Task<ActionResult<bool>> DeleteMealPlan(int userID, int mealID, DateTime date)
        {
            try
            {
                return await _repo.DeleteMealPlan(userID, mealID, date);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
