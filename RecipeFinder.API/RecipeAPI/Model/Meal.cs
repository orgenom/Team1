using System.Xml.Linq;

namespace RecipeAPI.Model
{
    public class Meal : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Category {  get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string? Meal_thumb { get; set; }
        public string? Tags { get; set; }
        public string? Youtube { get; set; }
        public string Ingredient1 { get; set; } = string.Empty;
        public string? Ingredient2 { get; set; }
        public string? Ingredient3 { get; set; }
        public string? Ingredient4 { get; set; }
        public string? Ingredient5 { get; set; }
        public string? Ingredient6 { get; set; }
        public string? Ingredient7 { get; set; }
        public string? Ingredient8 { get; set; }
        public string? Ingredient9 { get; set; }
        public string? Ingredient10 { get; set; }
        public string? Ingredient11 { get; set; }
        public string? Ingredient12 { get; set; }
        public string? Ingredient13 { get; set; }
        public string? Ingredient14 { get; set; }
        public string? Ingredient15 { get; set; }
        public string Measure1 { get; set; } = string.Empty;
        public string? Measure2 { get; set; }
        public string? Measure3 { get; set; }
        public string? Measure4 { get; set; }
        public string? Measure5 { get; set; }
        public string? Measure6 { get; set; }
        public string? Measure7 { get; set; }
        public string? Measure8 { get; set; }
        public string? Measure9 { get; set; }
        public string? Measure10 { get; set; }
        public string? Measure11 { get; set; }
        public string? Measure12 { get; set; }
        public string? Measure13 { get; set; }
        public string? Measure14 { get; set; }
        public string? Measure15 { get; set; }
        
        /*
        public string? idMeal { get; set; }
        public string? strMeal { get; set; }
        public string? strDrinkAlternate { get; set; }
        public string? strCategory { get; set; }
        public string? strArea { get; set; }
        public string? strInstructions { get; set; }
        public string? strMealThumb { get; set; }
        public string? strTags { get; set; }
        public string? strYoutube { get; set; }
        public string? strIngredient1 { get; set; }
        public string? strIngredient2 { get; set; }
        public string? strIngredient3 { get; set; }
        */
    };
}