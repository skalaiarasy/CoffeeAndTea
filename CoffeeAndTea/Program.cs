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
            //List<Products> itemChoice = new List<Products>();

            Console.WriteLine("Welcome to Take a Sip!");
            Console.WriteLine();

            while (true)
            {
                //cart.DisplayHeader();
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

                    Console.WriteLine("Would you like to add more drinks to your cart? y/n");
                    string input;
                    while (true)
                    {
                        input = Console.ReadLine().ToLower().Trim();
                        if (input == "y")
                        {

                          
                            break;

                        }
                        else if (input == "n")
                        {
                            cart.Checkout();
                           
                            //Display receipt

                        }
                        else
                        {
                            Console.WriteLine("That was not a y/n. Please try again.");
                        }
                    }

                }
                else if (choice <= 0 || choice >= 13 )
                {
                    Console.WriteLine("That was not an option. Please select a valid number.");
                    Console.WriteLine();
                } 
                
            }
        }

    }

}





