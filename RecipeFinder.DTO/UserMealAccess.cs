
using Microsoft.Extensions.Configuration;
using RecipeFinder.Logic.Model;
using System.Data.SqlClient;

namespace RecipeFinder.DTO
{
    public class UserMealAccess
    {

        private string? _connectionString;

        public UserMealAccess(string conString)
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

        public async Task<List<UserMeal>> GetMeals()
        {

            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "SELECT * FROM [RecipeFinder].[Meal]";
                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();



                List<UserMeal> meals = new();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        UserMeal meal = new();
                        meal.userID = reader.GetInt32(0);
                        meal.idMeal = reader.GetInt32(1);
                        meal.strMeal = reader.GetString(2);
                        meal.strCategory = reader.GetString(3);
                        meal.strArea = reader.GetString(4);
                        meal.strInstructions = reader.GetString(5);
                        meal.strMealThumb = await reader.IsDBNullAsync(6) ? null : reader.GetString(6);
                        meal.strTags = await reader.IsDBNullAsync(7) ? null : reader.GetString(7);
                        meal.strYoutube = await reader.IsDBNullAsync(8) ? null : reader.GetString(8);
                        meal.strIngredient1 = reader.GetString(9);
                        meal.strIngredient2 = await reader.IsDBNullAsync(10) ? null : reader.GetString(10);
                        meal.strIngredient3 = await reader.IsDBNullAsync(11) ? null : reader.GetString(11);
                        meal.strIngredient4 = await reader.IsDBNullAsync(12) ? null : reader.GetString(12);
                        meal.strIngredient5 = await reader.IsDBNullAsync(13) ? null : reader.GetString(13);
                        meal.strIngredient6 = await reader.IsDBNullAsync(14) ? null : reader.GetString(14);
                        meal.strIngredient7 = await reader.IsDBNullAsync(15) ? null : reader.GetString(15);
                        meal.strIngredient8 = await reader.IsDBNullAsync(16) ? null : reader.GetString(16);
                        meal.strIngredient9 = await reader.IsDBNullAsync(17) ? null : reader.GetString(17);
                        meal.strIngredient10 = await reader.IsDBNullAsync(18) ? null : reader.GetString(18);
                        meal.strIngredient11 = await reader.IsDBNullAsync(19) ? null : reader.GetString(19);
                        meal.strIngredient12 = await reader.IsDBNullAsync(20) ? null : reader.GetString(20);
                        meal.strIngredient13 = await reader.IsDBNullAsync(21) ? null : reader.GetString(21);
                        meal.strIngredient14 = await reader.IsDBNullAsync(22) ? null : reader.GetString(22);
                        meal.strIngredient15 = await reader.IsDBNullAsync(23) ? null : reader.GetString(23);
                        meal.strMeasure1 = reader.GetString(24);
                        meal.strMeasure2 = await reader.IsDBNullAsync(25) ? null : reader.GetString(25);
                        meal.strMeasure3 = await reader.IsDBNullAsync(26) ? null : reader.GetString(26);
                        meal.strMeasure4 = await reader.IsDBNullAsync(27) ? null : reader.GetString(27);
                        meal.strMeasure5 = await reader.IsDBNullAsync(28) ? null : reader.GetString(28);
                        meal.strMeasure6 = await reader.IsDBNullAsync(29) ? null : reader.GetString(29);
                        meal.strMeasure7 = await reader.IsDBNullAsync(30) ? null : reader.GetString(30);
                        meal.strMeasure8 = await reader.IsDBNullAsync(31) ? null : reader.GetString(31);
                        meal.strMeasure9 = await reader.IsDBNullAsync(32) ? null : reader.GetString(32);
                        meal.strMeasure10 = await reader.IsDBNullAsync(33) ? null : reader.GetString(33);
                        meal.strMeasure11 = await reader.IsDBNullAsync(34) ? null : reader.GetString(34);
                        meal.strMeasure12 = await reader.IsDBNullAsync(35) ? null : reader.GetString(35);
                        meal.strMeasure13 = await reader.IsDBNullAsync(36) ? null : reader.GetString(36);
                        meal.strMeasure14 = await reader.IsDBNullAsync(37) ? null : reader.GetString(37);
                        meal.strMeasure15 = await reader.IsDBNullAsync(38) ? null : reader.GetString(38);
                        meals.Add(meal);
                    }
                }
                await conn.CloseAsync();
                return meals;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new List<UserMeal>();
            }
        }

        public async Task<UserMeal> GetMeal(int id)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "SELECT * FROM [RecipeFinder].[Meal] WHERE ID = @idMeal";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@idMeal", id);
                using SqlDataReader reader = cmd.ExecuteReader();


                var meal = new UserMeal();

                bool hasRows = reader.HasRows;
                if (hasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        meal.userID = reader.GetInt32(0);
                        meal.idMeal = reader.GetInt32(1);
                        meal.strMeal = reader.GetString(2);
                        meal.strCategory = reader.GetString(3);
                        meal.strArea = reader.GetString(4);
                        meal.strInstructions = reader.GetString(5);
                        meal.strMealThumb = await reader.IsDBNullAsync(6) ? null : reader.GetString(6);
                        meal.strTags = await reader.IsDBNullAsync(7) ? null : reader.GetString(7);
                        meal.strYoutube = await reader.IsDBNullAsync(8) ? null : reader.GetString(8);
                        meal.strIngredient1 = reader.GetString(9);
                        meal.strIngredient2 = await reader.IsDBNullAsync(10) ? null : reader.GetString(10);
                        meal.strIngredient3 = await reader.IsDBNullAsync(11) ? null : reader.GetString(11);
                        meal.strIngredient4 = await reader.IsDBNullAsync(12) ? null : reader.GetString(12);
                        meal.strIngredient5 = await reader.IsDBNullAsync(13) ? null : reader.GetString(13);
                        meal.strIngredient6 = await reader.IsDBNullAsync(14) ? null : reader.GetString(14);
                        meal.strIngredient7 = await reader.IsDBNullAsync(15) ? null : reader.GetString(15);
                        meal.strIngredient8 = await reader.IsDBNullAsync(16) ? null : reader.GetString(16);
                        meal.strIngredient9 = await reader.IsDBNullAsync(17) ? null : reader.GetString(17);
                        meal.strIngredient10 = await reader.IsDBNullAsync(18) ? null : reader.GetString(18);
                        meal.strIngredient11 = await reader.IsDBNullAsync(19) ? null : reader.GetString(19);
                        meal.strIngredient12 = await reader.IsDBNullAsync(20) ? null : reader.GetString(20);
                        meal.strIngredient13 = await reader.IsDBNullAsync(21) ? null : reader.GetString(21);
                        meal.strIngredient14 = await reader.IsDBNullAsync(22) ? null : reader.GetString(22);
                        meal.strIngredient15 = await reader.IsDBNullAsync(23) ? null : reader.GetString(23);
                        meal.strMeasure1 = reader.GetString(24);
                        meal.strMeasure2 = await reader.IsDBNullAsync(25) ? null : reader.GetString(25);
                        meal.strMeasure3 = await reader.IsDBNullAsync(26) ? null : reader.GetString(26);
                        meal.strMeasure4 = await reader.IsDBNullAsync(27) ? null : reader.GetString(27);
                        meal.strMeasure5 = await reader.IsDBNullAsync(28) ? null : reader.GetString(28);
                        meal.strMeasure6 = await reader.IsDBNullAsync(29) ? null : reader.GetString(29);
                        meal.strMeasure7 = await reader.IsDBNullAsync(30) ? null : reader.GetString(30);
                        meal.strMeasure8 = await reader.IsDBNullAsync(31) ? null : reader.GetString(31);
                        meal.strMeasure9 = await reader.IsDBNullAsync(32) ? null : reader.GetString(32);
                        meal.strMeasure10 = await reader.IsDBNullAsync(33) ? null : reader.GetString(33);
                        meal.strMeasure11 = await reader.IsDBNullAsync(34) ? null : reader.GetString(34);
                        meal.strMeasure12 = await reader.IsDBNullAsync(35) ? null : reader.GetString(35);
                        meal.strMeasure13 = await reader.IsDBNullAsync(36) ? null : reader.GetString(36);
                        meal.strMeasure14 = await reader.IsDBNullAsync(37) ? null : reader.GetString(37);
                        meal.strMeasure15 = await reader.IsDBNullAsync(38) ? null : reader.GetString(38);

                    }
                }
                await conn.CloseAsync();
                return hasRows ? meal : throw new Exception("No meal found");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AddMeal(UserMeal meal)
        {
            using SqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
            try
            {
                


                string query = "INSERT INTO [RecipeFinder].[Meal] (UserID,Name, Category, Area, Instructions, MealThumb, Tags, Youtube, Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6, Ingredient7, Ingredient8, Ingredient9, Ingredient10, Ingredient11, Ingredient12, Ingredient13, Ingredient14, Ingredient15, Measure1, Measure2, Measure3, Measure4, Measure5, Measure6, Measure7, Measure8, Measure9, Measure10, Measure11, Measure12, Measure13, Measure14, Measure15) VALUES (@userID, @strMeal, @strCategory, @strArea, @strInstructions, @strMealThumb, @strTags, @strYoutube, @strIngredient1, @strIngredient2, @strIngredient3, @strIngredient4, @strIngredient5, @strIngredient6, @strIngredient7, @strIngredient8, @strIngredient9, @strIngredient10, @strIngredient11, @strIngredient12, @strIngredient13, @strIngredient14, @strIngredient15, @strMeasure1, @strMeasure2, @strMeasure3, @strMeasure4, @strMeasure5, @strMeasure6, @strMeasure7, @strMeasure8, @strMeasure9, @strMeasure10, @strMeasure11, @strMeasure12, @strMeasure13, @strMeasure14, @strMeasure15)";

                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@userID", meal.userID);
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

                
            }
            catch (SqlException ex)
            {

                Console.WriteLine($"Error executing SQL command: {ex.Message}");
                Console.WriteLine($"Error details: {ex.StackTrace}");
                Console.WriteLine($"SQL Error Number: {ex.Number}");
                Console.WriteLine($"SQL Error State: {ex.State}");
                throw;
            }

            await conn.CloseAsync();
            return true;
        }
        
        public async Task<bool> UpdateMeal(UserMeal meal)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);

                await conn.OpenAsync();

                string query = "UPDATE [RecipeFinder].[Meal] SET Name = @strMeal, Category = @strCategory, Area = @strArea, Instructions = @strInstructions, MealThumb = @strMealThumb, Tags = @strTags, Youtube = @strYoutube, Ingredient1 = @strIngredient1, Ingredient2 = @strIngredient2, Ingredient3 = @strIngredient3, Ingredient4 = @strIngredient4, Ingredient5 = @strIngredient5, Ingredient6 = @strIngredient6, Ingredient7 = @strIngredient7, Ingredient8 = @strIngredient8, Ingredient9 = @strIngredient9, Ingredient10 = @strIngredient10, Ingredient11 = @strIngredient11, Ingredient12 = @strIngredient12, Ingredient13 = @strIngredient13, Ingredient14 = @strIngredient14, Ingredient15 = @strIngredient15, Measure1 = @strMeasure1, Measure2 = @strMeasure2, Measure3 = @strMeasure3, Measure4 = @strMeasure4, Measure5 = @strMeasure5, Measure6 = @strMeasure6, Measure7 = @strMeasure7, Measure8 = @strMeasure8, Measure9 = @strMeasure9, Measure10 = @strMeasure10, Measure11 = @strMeasure11, Measure12 = @strMeasure12, Measure13 = @strMeasure13, Measure14 = @strMeasure14, Measure15 = @strMeasure15 WHERE ID = @idMeal";

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

                string query = "DELETE FROM [RecipeFinder].[Meal] WHERE ID = @idMeal";
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

        public async Task<List<UserMeal>> GetMealsByUserID(int userid)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "SELECT * FROM [RecipeFinder].[Meal] WHERE UserID = @userID";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@userID", userid);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                List<UserMeal> meals = new();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        UserMeal meal = new()
                        {
                            userID = reader.GetInt32(0),
                            idMeal = reader.GetInt32(1),
                            strMeal = reader.GetString(2),
                            strCategory = reader.GetString(3),
                            strArea = reader.GetString(4),
                            strInstructions = reader.GetString(5),
                            strMealThumb = await reader.IsDBNullAsync(6) ? null : reader.GetString(6),
                            strTags = await reader.IsDBNullAsync(7) ? null : reader.GetString(7),
                            strYoutube = await reader.IsDBNullAsync(8) ? null : reader.GetString(8),
                            strIngredient1 = reader.GetString(9),
                            strIngredient2 = await reader.IsDBNullAsync(10) ? null : reader.GetString(10),
                            strIngredient3 = await reader.IsDBNullAsync(11) ? null : reader.GetString(11),
                            strIngredient4 = await reader.IsDBNullAsync(12) ? null : reader.GetString(12),
                            strIngredient5 = await reader.IsDBNullAsync(13) ? null : reader.GetString(13),
                            strIngredient6 = await reader.IsDBNullAsync(14) ? null : reader.GetString(14),
                            strIngredient7 = await reader.IsDBNullAsync(15) ? null : reader.GetString(15),
                            strIngredient8 = await reader.IsDBNullAsync(16) ? null : reader.GetString(16),
                            strIngredient9 = await reader.IsDBNullAsync(17) ? null : reader.GetString(17),
                            strIngredient10 = await reader.IsDBNullAsync(18) ? null : reader.GetString(18),
                            strIngredient11 = await reader.IsDBNullAsync(19) ? null : reader.GetString(19),
                            strIngredient12 = await reader.IsDBNullAsync(20) ? null : reader.GetString(20),
                            strIngredient13 = await reader.IsDBNullAsync(21) ? null : reader.GetString(21),
                            strIngredient14 = await reader.IsDBNullAsync(22) ? null : reader.GetString(22),
                            strIngredient15 = await reader.IsDBNullAsync(23) ? null : reader.GetString(23),
                            strMeasure1 = reader.GetString(24),
                            strMeasure2 = await reader.IsDBNullAsync(25) ? null : reader.GetString(25),
                            strMeasure3 = await reader.IsDBNullAsync(26) ? null : reader.GetString(26),
                            strMeasure4 = await reader.IsDBNullAsync(27) ? null : reader.GetString(27),
                            strMeasure5 = await reader.IsDBNullAsync(28) ? null : reader.GetString(28),
                            strMeasure6 = await reader.IsDBNullAsync(29) ? null : reader.GetString(29),
                            strMeasure7 = await reader.IsDBNullAsync(30) ? null : reader.GetString(30),
                            strMeasure8 = await reader.IsDBNullAsync(31) ? null : reader.GetString(31),
                            strMeasure9 = await reader.IsDBNullAsync(32) ? null : reader.GetString(32),
                            strMeasure10 = await reader.IsDBNullAsync(33) ? null : reader.GetString(33),
                            strMeasure11 = await reader.IsDBNullAsync(34) ? null : reader.GetString(34),
                            strMeasure12 = await reader.IsDBNullAsync(35) ? null : reader.GetString(35),
                            strMeasure13 = await reader.IsDBNullAsync(36) ? null : reader.GetString(36),
                            strMeasure14 = await reader.IsDBNullAsync(37) ? null : reader.GetString(37),
                            strMeasure15 = await reader.IsDBNullAsync(38) ? null : reader.GetString(38)
                        };
                        meals.Add(meal);
                    }

                }
                await conn.CloseAsync();
                return meals;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}
