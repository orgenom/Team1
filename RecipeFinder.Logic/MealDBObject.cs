
using RecipeFinder.Logic.Model;

namespace RecipeFinder.Logic
{
    public class MealDBObject
    {

        private readonly string _apiUrl = "https://www.themealdb.com/api/json/v1/1/";

        //endpoints:
        //meal by name
        //meal by first letter
        //meal by id
        //random meal
        //list all meal categories
        //list all categories
        //list all area
        //list all ingredients
        //filter by main ingredient
        //filter by category
        //filter by area

        public MealDBObject()
        {
        }

        public async Task<List<Meal>>GetMealsByFirstLetter(string name)
        {

            string url = _apiUrl + "search.php?f=" + name;
            var mealResponse = await MealDBReader.Read(url);
            var meals = mealResponse.meals ?? throw new Exception("null meals");

            return meals;

        }

        public async Task<Meal> GetMealByName(string name)
        {
            string url = _apiUrl + "search.php?s=" + name;
            var mealResponse = await MealDBReader.Read(url);
            var meals = mealResponse.meals ?? throw new Exception("null meals");

            return meals[0] ?? throw new Exception("null meal");
        }

        public async Task<Meal> GetMealById(string id)
        {
            string url = _apiUrl + "lookup.php?i=" + id;
            var mealResponse = await MealDBReader.Read(url);
            var meals = mealResponse.meals ?? throw new Exception("null meals");

            return meals[0] ?? throw new Exception("null meal");
        }

        public async Task<Meal> GetRandomMeal()
        {
            string url = _apiUrl + "random.php";
            var mealResponse = await MealDBReader.Read(url);
            var meals = mealResponse.meals ?? throw new Exception("null meals");

            return meals[0] ?? throw new Exception("null meal");
        }

        public async Task<List<string?>> GetAllCategories()
        {
            string url = _apiUrl + "list.php?c=list";
            var categoryResponse = await MealDBReader.Read(url);
            var categories = categoryResponse.meals ?? throw new Exception("null categories");

            return categories.Select(c => c.strCategory).ToList();
        }

        public async Task<List<string?>> GetAllAreas()
        {
            string url = _apiUrl + "list.php?a=list";
            var areaResponse = await MealDBReader.Read(url);
            var areas = areaResponse.meals ?? throw new Exception("null areas");

            return areas.Select(a => a.strArea).ToList();
        }

        public async Task<List<string?>> GetAllIngredients()
        {
            string url = _apiUrl + "list.php?i=list";
            var ingredientResponse = await MealDBReader.Read(url);
            var ingredients = ingredientResponse.meals ?? throw new Exception("null ingredients");

            return ingredients.Select(i => i.strIngredient1).ToList();
        }

        public async Task<List<Meal>> FilterByMainIngredient(string ingredient)
        {
            string url = _apiUrl + "filter.php?i=" + ingredient;
            var mealResponse = await MealDBReader.Read(url);
            var meals = mealResponse.meals ?? throw new Exception("null meals");

            return meals;
        }

        public async Task<List<Meal>> FilterByCategory(string category)
        {
            string url = _apiUrl + "filter.php?c=" + category;
            var mealResponse = await MealDBReader.Read(url);
            var meals = mealResponse.meals ?? throw new Exception("null meals");

            return meals;
        }
        
        public async Task<List<Meal>> FilterByArea(string area)
        {
            string url = _apiUrl + "filter.php?a=" + area;
            var mealResponse = await MealDBReader.Read(url);
            var meals = mealResponse.meals ?? throw new Exception("null meals");

            return meals;
        }


        

    }
}
