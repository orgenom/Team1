using Microsoft.Extensions.Configuration;
using RecipeFinder.Logic.Model;
using sib_api_v3_sdk.Client;

namespace RecipeFinder.DTO
{
    public class RecipeRepository
    {

        readonly private MealAccess  _meal;
        readonly private UserAccess _user;
        readonly private MealPlanAccess _mealPlan;
        readonly public IConfiguration? _configuration;


        public RecipeRepository(string connectionString)
        {

            _meal = new MealAccess(connectionString);
            _user = new UserAccess(connectionString);
            _mealPlan = new MealPlanAccess(connectionString);

        }
        public RecipeRepository(IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnection")?? throw new InvalidOperationException("Default Connection missing");

            _meal = new MealAccess(connectionString);
            _user = new UserAccess(connectionString);
            _mealPlan = new MealPlanAccess(connectionString);
            _configuration = configuration;

        }

        //user stuff
        public async Task<User> GetUserById(int id)
        {

            return await _user.GetUser(id);

        }

        public async Task<User> Login(string username, string password)
        {
            return await _user.Login(username, password);
        }

        public async Task<bool> Register(User user)
        {
            return await _user.Register(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _user.GetAllUsers();
        }


        //meal stuff
        public async Task<List<Meal>> GetMeals()
        {
            return await _meal.GetMeals();
        }

        public async Task<List<MealPlan>> GetMealPlansByUserID(int userID)
        {
            return await _mealPlan.GetMealPlansByUserID(userID);
        }

        public async Task<bool> AddMealPlan(MealPlan mealplan)
        {
           return await _mealPlan.AddMealPlan(mealplan);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _user.UpdateUser(user);
        }

        public async Task<bool> UpdateMealPlan(MealPlan mealplan)
        {
            return await _mealPlan.UpdateMealPlan(mealplan);
        }

        public async Task<bool> DeleteMealPlan(int userID, int mealID, DateTime date)
        {
            return await _mealPlan.DeleteMealPlan(userID, mealID, date);
        }


        //mealplan stuff
        public async Task<bool> DeleteUser(int id)
        {
            return await _user.DeleteUser(id);
        }

        public async Task<Meal> GetMealById(int id)
        {
            return await _meal.GetMeal(id);
        }

        public async Task<bool> DeleteMeal(int id)
        {
            return await _meal.DeleteMeal(id);
        }

        public async Task<bool> UpdateMeal(Meal meal)
        {
            return await _meal.UpdateMeal(meal);
        }

        public async Task<bool> AddMeal(Meal meal)
        {
            return await _meal.AddMeal(meal);
        }

        public async Task<List<MealPlan>> GetMealPlans()
        {
            return await _mealPlan.GetMealPlans();
        }


    }
}
