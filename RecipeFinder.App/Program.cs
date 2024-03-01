using RecipeFinder.ConsoleApp.Models;
using System;
using System.Data;
using System.Transactions;

namespace RecipeFinder
{
    class Program
    {
        static User? user;
        public static async Task Main(string[] args)
        {
            bool loop;
            do
            {
                user = null;
                loop = true;
                switch (await ShowStartPage())
                {
                    case 1: // signed in user
                        await ShowMenu(user);
                        break;
                    case 2: // return to start page
                        break;
                    case 0: // exit program
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Unexpected error occured while processing ShowStartPage()");
                        break;
                }
            }while(loop);
        }
        
        static async Task<int> ShowStartPage()
        {
            bool loop;
            do
            {
                loop = true;
                Console.WriteLine("========== Start Menu ==========" +
                                "\n1. Sign Up" +
                                "\n2. Sign In" +
                                "\n3. Continue Without Signing In" +
                              "\n\n0. Exit");
                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": // to sign up
                        Console.Clear();
                        user = await MenuOption.SignUp();
                        return (user == null) ? 2 : 1;
                    case "2": // to sign in
                        Console.Clear();
                        user = await MenuOption.UserSignIn();
                        return ( user == null) ? 2 : 1;
                    case "3": // continue without sign in
                        Console.Clear();
                        return 2;
                    case "0": // exit
                        Console.WriteLine("Have a Good Day");
                        return 0;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Choice");
                        loop = false;
                        break;
                }
            }while (!loop);

            return -1; // error occurred
        }

        static async Task ShowMenu(User? user)
        {
            //Console.Clear();
            //await MenuOption.ShowRandomMeal();

            Console.WriteLine(user == null ?
                              "------------Welcome-------------" :
                              "--- Welcome " + user.FirstName + " ---");
            Console.WriteLine("============= Menu =============");
            Console.WriteLine("1. Search for a Recipe" +
                            "\n2. Show My Recipes" +
                            "\n3. Add a Recipe" +
                            "\n4. Show Meal Plan" +
                          "\n\n0. Exit");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();
            await RespondToMenu(choice);
        }

        static async Task RespondToMenu(string? choice)
        {
            Console.Clear();
            int option = 9;
            if (choice == null){
                Console.WriteLine("Error processing input");
                return;
            }

            try{
                option = Int32.Parse(choice);
                if (user == null && option > 1)
                {
                    Console.WriteLine("Please sign up to use this feature");
                    return;
                }

                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("=====Search for a Recipe========");
                        await MenuOption.FindARecipe(ProcessSearchOption());
                        break;
                    case "2":
                        Console.WriteLine("=========Show My Recipes========");
                        await MenuOption.ShowMyRecipes();
                        break;
                    case "3":
                        Console.WriteLine("===========Add a Recipe=========");
                        await MenuOption.AddRecipe(user);
                        break;
                    case "4":
                        Console.WriteLine("=========Show Meal Plan=========");
                        await MenuOption.ShowMyMealPlan(user);
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Not a valid choice");
                        break;
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                return;
            }
        }

        static int ProcessSearchOption()
        {
            Console.Clear();
            Console.WriteLine("Find recipe by: " +
                            "\n1. First Letter" +
                            "\n2. Name" +
                            "\n3. ID" +
                          "\n\n0. Exit");
            string? choice = Console.ReadLine();
            
            int option;
            try
            {
                if (choice == null)
                    throw new ArgumentNullException("choice is null");
                option = Int32.Parse(choice);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                option = -1; // error occurred
            }
            return option;
        }
    }

}
