
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.DTO;
using RecipeFinder.Logic;
using RecipeFinder.Logic.Model;

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeFinderController : ControllerBase
    {
        private readonly RecipeRepository _repo;
        private readonly ILogger<RecipeRepository> _logger;
        private readonly EmailObject emailObject;

        public RecipeFinderController(RecipeRepository repo, ILogger<RecipeRepository> logger)
        {
            _repo= repo;
            _logger = logger;
            emailObject = new EmailObject(_repo._configuration["BrevoKey"] ?? "");
        }

        // GET: api/<UserController>/user/{id}
        [HttpGet("user/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet("key")]
        public async Task<ActionResult<string>> GetKey()
        {
            return _repo._configuration["BrevoKey"] ?? "";
        }

        [HttpGet("contacts")]
        public async Task<ActionResult<string>> GetAllContacts()
        {
            try
            {
                return await emailObject.GetAllContacts();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("contact")]
        public async Task<ActionResult<string>> AddContact(string firstname, string lastname, string email)
        {
            try
            {
                emailObject.AddContact(firstname, lastname, email);
                return "Contact added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("email")]
        public async Task<ActionResult<string>> SendEmail(string email, string subject, string content)
        {
            try
            {
                emailObject.SendEmail(email, subject, content);
                return "Email sent";
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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

        [HttpGet("mealplans/{userID}")]
        public async Task<ActionResult<List<MealPlan>>> GetMealPlansByID(int userID)
        {
            try
            {
                return await _repo.GetMealPlansByUserID(userID);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(User user)
        {
            try
            {
                return await _repo.Register(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("login")]
        public async Task<ActionResult<User>> Login(string username, string password)
        {
            try
            {
                return await _repo.Login(username, password);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("user")]
        public async Task<ActionResult<bool>> UpdateUser(int id, string username, string password, string firstName, string lastName, string email)
        {
            try
            {
                return await _repo.UpdateUser(id, username, password, firstName, lastName, email);
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
                return await _repo.DeleteUser(id);
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

        [HttpGet("mealplans")]
        public async Task<ActionResult<List<MealPlan>>> GetMealPlans()
        {
            try
            {
                return await _repo.GetMealPlans();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
