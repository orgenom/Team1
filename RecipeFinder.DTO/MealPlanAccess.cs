

using Microsoft.Extensions.Configuration;
using RecipeFinder.Logic.Model;
using System.Data.SqlClient;

namespace RecipeFinder.DTO
{
    public class MealPlanAccess
    {

        private string? _connectionString;

        public MealPlanAccess(string conString)
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

        public async Task<List<MealPlan>>GetMealPlansByUserID(int userID)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "SELECT * FROM [RecipeFinder].[MealPlan] WHERE UserID = @UserID";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                using SqlDataReader reader = cmd.ExecuteReader();

                List<MealPlan> mealplans = new();

                
                while (await reader.ReadAsync())
                {

                    MealPlan curr = new();
                    curr.UserID = reader.GetInt32(0);
                    curr.MealID = reader.GetInt32(1);
                    curr.Date = reader.GetDateTime(2);
                    mealplans.Add(curr);


                }

                await conn.CloseAsync();
                return mealplans;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MealPlan>();
            }
        }

        public async Task<bool> AddMealPlan(MealPlan mealplan)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "INSERT INTO [RecipeFinder].[MealPlan] (UserID, MealID, Date) VALUES (@UserID, @MealID, @Date)";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@UserID", mealplan.UserID);
                cmd.Parameters.AddWithValue("@MealID", mealplan.MealID);
                cmd.Parameters.AddWithValue("@Date", mealplan.Date);
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

        public async Task<bool> DeleteMealPlan(int userID, int mealID, DateTime date)
        {
            try { 
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "DELETE FROM [RecipeFinder].[MealPlan] WHERE UserID = @UserID AND MealID = @MealID AND Date = @Date";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@MealID", mealID);
                cmd.Parameters.AddWithValue("@Date", date);
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

        public async Task<bool> UpdateMealPlan(MealPlan mealplan)
        {

            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "UPDATE [RecipeFinder].[MealPlan] SET UserID = @UserID, MealID = @MealID, Date = @Date WHERE UserID = @UserID AND MealID = @MealID AND Date = @Date";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@UserID", mealplan.UserID);
                cmd.Parameters.AddWithValue("@MealID", mealplan.MealID);
                cmd.Parameters.AddWithValue("@Date", mealplan.Date);
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

        public async Task<List<MealPlan>> GetMealPlans()
        {

            try
            {
                using SqlConnection conn = new(_connectionString);
                await conn.OpenAsync();

                string query = "SELECT * FROM [RecipeFinder].[MealPlan]";
                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                List<MealPlan> mealplans = new();
                while (await reader.ReadAsync())
                {

                    MealPlan mealPlan = new();
                    mealPlan.UserID = reader.GetInt32(0);
                    mealPlan.MealID = reader.GetInt32(1);
                    mealPlan.Date = reader.GetDateTime(2);
                    mealplans.Add(mealPlan);

                }
                return mealplans;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MealPlan>();
            }

        }

    }
}
