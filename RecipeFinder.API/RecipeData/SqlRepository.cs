using Microsoft.Extensions.Logging;
using RecipeAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData
{
    internal class SqlRepository
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SqlRepository> _logger;

        // Constructors
        public SqlRepository(string connectionString, ILogger<SqlRepository> logger)
        {
            this._connectionString = connectionString; ;
            this._logger = logger;
        }

        public async Task EnterNewMealAsync(Meal meal)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();

            string cmdText = @"INSERT INTO [Recipe].[Meals] (Id, Name, Category, Area, Ingredient1, Ingredient2, Ingredient3) VALUES (@id, @name, @category, @area, @ing1, @ing2, @ing3);";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, connection);

            sqlCommand.Parameters.AddWithValue("", meal.idMeal);
            sqlCommand.Parameters.AddWithValue("", meal.strMeal);
            sqlCommand.Parameters.AddWithValue("", meal.strCategory);
            sqlCommand.Parameters.AddWithValue("", meal.strArea);
            sqlCommand.Parameters.AddWithValue("", meal.strIngredient1);
            sqlCommand.Parameters.AddWithValue("", meal.strIngredient2);
            sqlCommand.Parameters.AddWithValue("", meal.strIngredient3);

            await sqlCommand.ExecuteNonQueryAsync();
            await connection.CloseAsync();

            _logger.LogInformation("Executed EnterNewMealAsync");
        }
    }
}
