using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RecipeFinder.Logic.Model;


public class Meal
{
    public string? idMeal { get; set; }
    public string? strMeal { get; set; }
    public string? strCategory { get; set; }
    public string? strArea { get; set; }
    public string? strInstructions { get; set; }
    public string? strMealThumb { get; set; }
    public string? strTags { get; set; }
    public string? strYoutube { get; set; }
    public string? strIngredient1 { get; set; }
    public string? strIngredient2 { get; set; }
    public string? strIngredient3 { get; set; }
    public string? strIngredient4 { get; set; }
    public string? strIngredient5 { get; set; }
    public string? strIngredient6 { get; set; }
    public string? strIngredient7 { get; set; }
    public string? strIngredient8 { get; set; }
    public string? strIngredient9 { get; set; }
    public string? strIngredient10 { get; set; }
    public string? strIngredient11 { get; set; }
    public string? strIngredient12 { get; set; } 
    public string? strIngredient13 { get; set; }
    public string? strIngredient14 { get; set; }
    public string? strIngredient15 { get; set; }
    public string? strMeasure1 { get; set; }
    public string? strMeasure2 { get; set; }
    public string? strMeasure3 { get; set; }
    public string? strMeasure4 { get; set; }
    public string? strMeasure5 { get; set; }
    public string? strMeasure6 { get; set; }
    public string? strMeasure7 { get; set; }
    public string? strMeasure8 { get; set; }   
    public string? strMeasure9 { get; set; }
    public string? strMeasure10 { get; set; }  
    public string? strMeasure11 { get; set; }
    public string? strMeasure12 { get; set; }
    public string? strMeasure13 { get; set; }
    public string? strMeasure14 { get; set; }
    public string? strMeasure15 { get; set; }

    public override string ToString()
    {
        return $"idMeal: {idMeal}, strMeal: {strMeal}, strCategory: {strCategory}, strArea: {strArea}, strInstructions: {strInstructions}, strMealThumb: {strMealThumb}, strTags: {strTags}, strYoutube: {strYoutube}, strIngredient1: {strIngredient1}, strIngredient2: {strIngredient2}, strIngredient3: {strIngredient3}, strIngredient4: {strIngredient4}, strIngredient5: {strIngredient5}, strIngredient6: {strIngredient6}, strIngredient7: {strIngredient7}, strIngredient8: {strIngredient8}, strIngredient9: {strIngredient9}, strIngredient10: {strIngredient10}, strIngredient11: {strIngredient11}, strIngredient12: {strIngredient12}, strIngredient13: {strIngredient13}, strIngredient14: {strIngredient14}, strIngredient15: {strIngredient15}, strMeasure1: {strMeasure1}, strMeasure2: {strMeasure2}, strMeasure3: {strMeasure3}, strMeasure4: {strMeasure4}, strMeasure5: {strMeasure5}, strMeasure6: {strMeasure6}, strMeasure7: {strMeasure7}, strMeasure8: {strMeasure8}, strMeasure9: {strMeasure9}, strMeasure10: {strMeasure10}, strMeasure11: {strMeasure11}, strMeasure12: {strMeasure12}, strMeasure13: {strMeasure13}, strMeasure14: {strMeasure14}, strMeasure15: {strMeasure15}";
    }
}


public class MealResponse
{
    public List<Meal>? meals { get; set; }
}