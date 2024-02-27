using RecipeAPI.Model;

namespace RecipeData
{
    public interface IRepository
    {
        public Task EnterNewMealAsync(Meal meal);
    }
}
