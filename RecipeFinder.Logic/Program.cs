using System;
using System.Text;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.Logic
{
    class Program
    {
        public static async Task  Main(string[] args)
        {


            var mealObject = new MealDBObject();

            List<string?> meal = await mealObject.GetAllCategories();

            foreach (var item in meal)
            {
                Console.WriteLine(item);
            }

        }
    }
}