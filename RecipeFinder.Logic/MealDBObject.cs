
namespace RecipeFinder.Logic
{
    public class MealDBObject
    {

        public static int id { get; set; } = 1;


        public async Task<int> GetInt()
        {
            return id;
        }
    }
}
