using System;
using System.Text;
using RecipeFinder.Logic.Model;

namespace RecipeFinder.Logic
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Recipe Finder starting...");

            var emailSender = new EmailObject("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");


            emailSender.GetAllContacts();

        }
    }
}