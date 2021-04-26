using System;
using System.Collections.Generic;
using System.IO;

namespace CoffeeAndTea
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            Console.WriteLine("Welcome to Take a Sip!");
            Console.WriteLine();

            while (true)
            {
                cart.DisplayHeader();
                cart.ListProducts();
                Console.WriteLine();
                Console.WriteLine("Which drink would you like to purchase?");
                Console.WriteLine("Please select a number 1-12: ");
                Console.WriteLine();

                Int32 choice = 0;
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("That was not a number.");
                }

                if (choice >= 1 && choice <= cart.Product.Count)
                {
                    cart.AddToCart(choice);

                }
                else if (choice <= 0 && choice > cart.Product.Count)
                {
                    Console.WriteLine("That was not an option. Please select a valid number.");
                }
            }
            //Call for checkout
        }

    }

}





