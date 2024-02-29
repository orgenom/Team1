using RecipeFinder.Logic.Model;
using System.Text.Json;


namespace RecipeFinder.Logic
{
    public class MealDBReader
    {
        public static async Task<MealResponse> Read(string url)
        {

            var response = await new HttpClient().GetStreamAsync(url);
            var mealResponse = await JsonSerializer.DeserializeAsync<MealResponse>(response);
            
            Console.WriteLine(mealResponse);

            return mealResponse ?? throw new Exception("null meal response");

        }
    }
}
