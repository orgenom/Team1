
using Microsoft.Extensions.Configuration;
using RecipeFinder.Logic.Model;
using System.Data.SqlClient;

namespace RecipeFinder.DTO
{
    public class MealAccess
    {

        private string? _connectionString;

        public MealAccess(string conString)
        {
            try
            {
                _connectionString = conString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error with connection string...");
                Environment.Exit(1);
            }
        }

        public async Task<List<Meal>> GetMeals()
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();

            string query = "SELECT * FROM [RecipeFinder].[Meal]";
            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

           

            var meals = new List<Meal>();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var meal = new Meal();
                    meal.idMeal =  reader.GetString(0);
                    meal.strMeal = reader.GetString(1);
                    meal.strCategory = reader.GetString(2);
                    meal.strArea = reader.GetString(3);
                    meal.strInstructions = reader.GetString(4);
                    meal.strMealThumb = reader.GetString(5);
                    meal.strTags = reader.GetString(6);
                    meal.strYoutube = reader.GetString(7);
                    meal.strIngredient1 = reader.GetString(8);
                    meal.strIngredient2 = reader.GetString(9);
                    meal.strIngredient3 = reader.GetString(10);
                    meal.strIngredient4 = reader.GetString(11);
                    meal.strIngredient5 = reader.GetString(12);
                    meal.strIngredient6 = reader.GetString(13);
                    meal.strIngredient7 = reader.GetString(14);
                    meal.strIngredient8 = reader.GetString(15);
                    meal.strIngredient9 = reader.GetString(16);
                    meal.strIngredient10 = reader.GetString(17);
                    meal.strIngredient11 = reader.GetString(18);
                    meal.strIngredient12 = reader.GetString(19);
                    meal.strIngredient13 = reader.GetString(20);
                    meal.strIngredient14 = reader.GetString(21);
                    meal.strIngredient15 = reader.GetString(22);
                    meal.strMeasure1 = reader.GetString(23);
                    meal.strMeasure2 = reader.GetString(24);
                    meal.strMeasure3 = reader.GetString(25);
                    meal.strMeasure4 = reader.GetString(26);
                    meal.strMeasure5 = reader.GetString(27);
                    meal.strMeasure6 = reader.GetString(28);
                    meal.strMeasure7 = reader.GetString(29);
                    meal.strMeasure8 = reader.GetString(30);
                    meal.strMeasure9 = reader.GetString(31);
                    meal.strMeasure10 = reader.GetString(32);
                    meal.strMeasure11 = reader.GetString(33);
                    meal.strMeasure12 = reader.GetString(34);
                    meal.strMeasure13 = reader.GetString(35);
                    meal.strMeasure14 = reader.GetString(36);
                    meal.strMeasure15 = reader.GetString(37);
                    meals.Add(meal);
                }
            }
            await conn.CloseAsync();
            return meals;
        }

        public async Task<Meal> GetMeal(int id)
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();

            string query = "SELECT * FROM [RecipeFinder].[Meal] WHERE Id = @idMeal";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@idMeal", id);
            using SqlDataReader reader = cmd.ExecuteReader();

            

            var meal = new Meal();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {

                    meal.idMeal = reader.GetString(0);
                    meal.strMeal = reader.GetString(1);
                    meal.strCategory = reader.GetString(2);
                    meal.strArea = reader.GetString(3);
                    meal.strInstructions = reader.GetString(4);
                    meal.strMealThumb = reader.GetString(5);
                    meal.strTags = reader.GetString(6);
                    meal.strYoutube = reader.GetString(7);
                    meal.strIngredient1 = reader.GetString(8);
                    meal.strIngredient2 = reader.GetString(9);
                    meal.strIngredient3 = reader.GetString(10);
                    meal.strIngredient4 = reader.GetString(11);
                    meal.strIngredient5 = reader.GetString(12);
                    meal.strIngredient6 = reader.GetString(13);
                    meal.strIngredient7 = reader.GetString(14);
                    meal.strIngredient8 = reader.GetString(15);
                    meal.strIngredient9 = reader.GetString(16);
                    meal.strIngredient10 = reader.GetString(17);
                    meal.strIngredient11 = reader.GetString(18);
                    meal.strIngredient12 = reader.GetString(19);
                    meal.strIngredient13 = reader.GetString(20);
                    meal.strIngredient14 = reader.GetString(21);
                    meal.strIngredient15 = reader.GetString(22);
                    meal.strMeasure1 = reader.GetString(23);
                    meal.strMeasure2 = reader.GetString(24);
                    meal.strMeasure3 = reader.GetString(25);
                    meal.strMeasure4 = reader.GetString(26);
                    meal.strMeasure5 = reader.GetString(27);
                    meal.strMeasure6 = reader.GetString(28);
                    meal.strMeasure7 = reader.GetString(29);
                    meal.strMeasure8 = reader.GetString(30);
                    meal.strMeasure9 = reader.GetString(31);
                    meal.strMeasure10 = reader.GetString(32);
                    meal.strMeasure11 = reader.GetString(33);
                    meal.strMeasure12 = reader.GetString(34);
                    meal.strMeasure13 = reader.GetString(35);
                    meal.strMeasure14 = reader.GetString(36);
                    meal.strMeasure15 = reader.GetString(37);

                }
            }
            await conn.CloseAsync();
            return meal;
        }

        public async Task<bool> AddMeal(Meal meal)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();


                string query = "INSERT INTO [RecipeFinder].[Meal] (Name, Category, Area, Instructions, MealThumb, Tags, Youtube, Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6, Ingredient7, Ingredient8, Ingredient9, Ingredient10, Ingredient11, Ingredient12, Ingredient13, Ingredient14, Ingredient15, Measure1, Measure2, Measure3, Measure4, Measure5, Measure6, Measure7, Measure8, Measure9, Measure10, Measure11, Measure12, Measure13, Measure14, Measure15) VALUES (@strMeal, @strCategory, @strArea, @strInstructions, @strMealThumb, @strTags, @strYoutube, @strIngredient1, @strIngredient2, @strIngredient3, @strIngredient4, @strIngredient5, @strIngredient6, @strIngredient7, @strIngredient8, @strIngredient9, @strIngredient10, @strIngredient11, @strIngredient12, @strIngredient13, @strIngredient14, @strIngredient15, @strMeasure1, @strMeasure2, @strMeasure3, @strMeasure4, @strMeasure5, @strMeasure6, @strMeasure7, @strMeasure8, @strMeasure9, @strMeasure10, @strMeasure11, @strMeasure12, @strMeasure13, @strMeasure14, @strMeasure15)";

                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@strMeal", meal.strMeal);
                cmd.Parameters.AddWithValue("@strCategory", meal.strCategory);
                cmd.Parameters.AddWithValue("@strArea", meal.strArea);
                cmd.Parameters.AddWithValue("@strInstructions", meal.strInstructions);
                cmd.Parameters.AddWithValue("@strMealThumb", meal.strMealThumb);
                cmd.Parameters.AddWithValue("@strTags", meal.strTags);
                cmd.Parameters.AddWithValue("@strYoutube", meal.strYoutube);
                cmd.Parameters.AddWithValue("@strIngredient1", meal.strIngredient1);
                cmd.Parameters.AddWithValue("@strIngredient2", meal.strIngredient2);
                cmd.Parameters.AddWithValue("@strIngredient3", meal.strIngredient3);
                cmd.Parameters.AddWithValue("@strIngredient4", meal.strIngredient4);
                cmd.Parameters.AddWithValue("@strIngredient5", meal.strIngredient5);
                cmd.Parameters.AddWithValue("@strIngredient6", meal.strIngredient6);
                cmd.Parameters.AddWithValue("@strIngredient7", meal.strIngredient7);
                cmd.Parameters.AddWithValue("@strIngredient8", meal.strIngredient8);
                cmd.Parameters.AddWithValue("@strIngredient9", meal.strIngredient9);
                cmd.Parameters.AddWithValue("@strIngredient10", meal.strIngredient10);
                cmd.Parameters.AddWithValue("@strIngredient11", meal.strIngredient11);
                cmd.Parameters.AddWithValue("@strIngredient12", meal.strIngredient12);
                cmd.Parameters.AddWithValue("@strIngredient13", meal.strIngredient13);
                cmd.Parameters.AddWithValue("@strIngredient14", meal.strIngredient14);
                cmd.Parameters.AddWithValue("@strIngredient15", meal.strIngredient15);
                cmd.Parameters.AddWithValue("@strMeasure1", meal.strMeasure1);
                cmd.Parameters.AddWithValue("@strMeasure2", meal.strMeasure2);
                cmd.Parameters.AddWithValue("@strMeasure3", meal.strMeasure3);
                cmd.Parameters.AddWithValue("@strMeasure4", meal.strMeasure4);
                cmd.Parameters.AddWithValue("@strMeasure5", meal.strMeasure5);
                cmd.Parameters.AddWithValue("@strMeasure6", meal.strMeasure6);
                cmd.Parameters.AddWithValue("@strMeasure7", meal.strMeasure7);
                cmd.Parameters.AddWithValue("@strMeasure8", meal.strMeasure8);
                cmd.Parameters.AddWithValue("@strMeasure9", meal.strMeasure9);
                cmd.Parameters.AddWithValue("@strMeasure10", meal.strMeasure10);
                cmd.Parameters.AddWithValue("@strMeasure11", meal.strMeasure11);
                cmd.Parameters.AddWithValue("@strMeasure12", meal.strMeasure12);
                cmd.Parameters.AddWithValue("@strMeasure13", meal.strMeasure13);
                cmd.Parameters.AddWithValue("@strMeasure14", meal.strMeasure14);
                cmd.Parameters.AddWithValue("@strMeasure15", meal.strMeasure15);


                await cmd.ExecuteNonQueryAsync();

                await conn.CloseAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateMeal(Meal meal)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);

                await conn.OpenAsync();

                string query = "UPDATE [RecipeFinder].[Meal] SET Name = @strMeal, Category = @strCategory, Area = @strArea, Instructions = @strInstructions, MealThumb = @strMealThumb, Tags = @strTags, Youtube = @strYoutube, Ingredient1 = @strIngredient1, Ingredient2 = @strIngredient2, Ingredient3 = @strIngredient3, Ingredient4 = @strIngredient4, Ingredient5 = @strIngredient5, Ingredient6 = @strIngredient6, Ingredient7 = @strIngredient7, Ingredient8 = @strIngredient8, Ingredient9 = @strIngredient9, Ingredient10 = @strIngredient10, Ingredient11 = @strIngredient11, Ingredient12 = @strIngredient12, Ingredient13 = @strIngredient13, Ingredient14 = @strIngredient14, Ingredient15 = @strIngredient15, Measure1 = @strMeasure1, Measure2 = @strMeasure2, Measure3 = @strMeasure3, Measure4 = @strMeasure4, Measure5 = @strMeasure5, Measure6 = @strMeasure6, Measure7 = @strMeasure7, Measure8 = @strMeasure8, Measure9 = @strMeasure9, Measure10 = @strMeasure10, Measure11 = @strMeasure11, Measure12 = @strMeasure12, Measure13 = @strMeasure13, Measure14 = @strMeasure14, Measure15 = @strMeasure15 WHERE Id = @idMeal";

                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@idMeal", meal.idMeal);
                cmd.Parameters.AddWithValue("@strMeal", meal.strMeal);
                cmd.Parameters.AddWithValue("@strCategory", meal.strCategory);
                cmd.Parameters.AddWithValue("@strArea", meal.strArea);
                cmd.Parameters.AddWithValue("@strInstructions", meal.strInstructions);
                cmd.Parameters.AddWithValue("@strMealThumb", meal.strMealThumb);
                cmd.Parameters.AddWithValue("@strTags", meal.strTags);
                cmd.Parameters.AddWithValue("@strYoutube", meal.strYoutube);
                cmd.Parameters.AddWithValue("@strIngredient1", meal.strIngredient1);
                cmd.Parameters.AddWithValue("@strIngredient2", meal.strIngredient2);
                cmd.Parameters.AddWithValue("@strIngredient3", meal.strIngredient3);
                cmd.Parameters.AddWithValue("@strIngredient4", meal.strIngredient4);
                cmd.Parameters.AddWithValue("@strIngredient5", meal.strIngredient5);
                cmd.Parameters.AddWithValue("@strIngredient6", meal.strIngredient6);
                cmd.Parameters.AddWithValue("@strIngredient7", meal.strIngredient7);
                cmd.Parameters.AddWithValue("@strIngredient8", meal.strIngredient8);
                cmd.Parameters.AddWithValue("@strIngredient9", meal.strIngredient9);
                cmd.Parameters.AddWithValue("@strIngredient10", meal.strIngredient10);
                cmd.Parameters.AddWithValue("@strIngredient11", meal.strIngredient11);
                cmd.Parameters.AddWithValue("@strIngredient12", meal.strIngredient12);
                cmd.Parameters.AddWithValue("@strIngredient13", meal.strIngredient13);
                cmd.Parameters.AddWithValue("@strIngredient14", meal.strIngredient14);
                cmd.Parameters.AddWithValue("@strIngredient15", meal.strIngredient15);
                cmd.Parameters.AddWithValue("@strMeasure1", meal.strMeasure1);
                cmd.Parameters.AddWithValue("@strMeasure2", meal.strMeasure2);
                cmd.Parameters.AddWithValue("@strMeasure3", meal.strMeasure3);
                cmd.Parameters.AddWithValue("@strMeasure4", meal.strMeasure4);
                cmd.Parameters.AddWithValue("@strMeasure5", meal.strMeasure5);
                cmd.Parameters.AddWithValue("@strMeasure6", meal.strMeasure6);
                cmd.Parameters.AddWithValue("@strMeasure7", meal.strMeasure7);
                cmd.Parameters.AddWithValue("@strMeasure8", meal.strMeasure8);
                cmd.Parameters.AddWithValue("@strMeasure9", meal.strMeasure9);
                cmd.Parameters.AddWithValue("@strMeasure10", meal.strMeasure10);
                cmd.Parameters.AddWithValue("@strMeasure11", meal.strMeasure11);
                cmd.Parameters.AddWithValue("@strMeasure12", meal.strMeasure12);
                cmd.Parameters.AddWithValue("@strMeasure13", meal.strMeasure13);
                cmd.Parameters.AddWithValue("@strMeasure14", meal.strMeasure14);
                cmd.Parameters.AddWithValue("@strMeasure15", meal.strMeasure15);

                await cmd.ExecuteNonQueryAsync();

                await conn.CloseAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public async Task<bool> DeleteMeal(int id)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "DELETE FROM [RecipeFinder].[Meal] WHERE Id = @idMeal";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@idMeal", id);
                await cmd.ExecuteNonQueryAsync();

                await conn.CloseAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
