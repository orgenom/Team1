using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Logic;
using RecipeFinder.Logic.Model;
namespace RecipeFinder.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MealDBController : ControllerBase
    {

        private readonly MealDBObject _mealDBObject;

        public MealDBController()
        {
            _mealDBObject = new MealDBObject();
        }

        //get meal by first letter
        //get meal by name
        //get meal by id
        //get random meal
        //get all categories
        //get all areas
        //get all ingredients
        //filter by main ingredient
        //filter by category
        //filter by area

        [HttpGet("meals/first_letter/{first_letter}")]
        public async Task<ActionResult<List<Meal>>> GetMealsByFirstLetter(string first_letter)
        {
            try
            {
                return Ok(await _mealDBObject.GetMealByFirstLetter(first_letter));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("meal/name/{name}")]
        public async Task<ActionResult<Meal>> GetMealByName(string name)
        {
            try
            {
                return Ok(await _mealDBObject.GetMealByName(name));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("meal/id/{id}")]
        public async Task<ActionResult<Meal>> GetMealById(string id)
        {
            try
            {
                return Ok(await _mealDBObject.GetMealById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("meal/random")]
        public async Task<ActionResult<Meal>> GetRandomMeal()
        {
            try
            {
                return Ok(await _mealDBObject.GetRandomMeal());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<string?>>> GetAllCategories()
        {
            try
            {
                return Ok(await _mealDBObject.GetAllCategories());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("areas")]
        public async Task<ActionResult<List<string?>>> GetAllAreas()
        {
            try
            {
                return Ok(await _mealDBObject.GetAllAreas());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ingredients")]
        public async Task<ActionResult<List<string?>>> GetAllIngredients()
        {
            try
            {
                return Ok(await _mealDBObject.GetAllIngredients());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("filter/ingredient/{ingredient}")]
        public async Task<ActionResult<List<Meal>>> FilterByMainIngredient(string ingredient)
        {
            try
            {
                return Ok(await _mealDBObject.FilterByMainIngredient(ingredient));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("filter/category/{category}")]
        public async Task<ActionResult<List<Meal>>> FilterByCategory(string category)
        {
            try
            {
                return Ok(await _mealDBObject.FilterByCategory(category));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("filter/area/{area}")]
        public async Task<ActionResult<List<Meal>>> FilterByArea(string area)
        {
            try
            {
                return Ok(await _mealDBObject.FilterByArea(area));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }





    }
}
