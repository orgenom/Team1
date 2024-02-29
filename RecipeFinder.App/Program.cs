
using Microsoft.Extensions.Configuration;
using RecipeFinder.DTO;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.ConsoleApp;

public class Program
{
    public static async Task Main(string[] args)
    {

        string cs = "Server=tcp:rev-training.database.windows.net,1433;Initial Catalog=trainingDB;Persist Security Info=False;User ID=chris;Password=Santa346;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        RecipeRepository repo = new RecipeRepository(cs);

        List<User> users = await repo.GetAllUsers();

        foreach(User user in users)
        {
            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.LastName);
            Console.WriteLine(user.Username);
            Console.WriteLine(user.Email);
            Console.WriteLine();
        }

    }
}