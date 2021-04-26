using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAndTea
{
    class  ShoppingCart
    {
        private List<Products> _product = new List<Products>
        {
            new Products("Coffee","Latte",    "Light & Smooth", 2.50M),
            new Products("Coffee","Cappucino","Nice & Bold",    3.0M),
            new Products("Coffee","Espresso", "Morning Burst",  5.50M),
            new Products("Coffee","Cold brew","Simple & Rustic",2.00M),
            new Products("Coffee","Mocha",    "Warm & Comfy",   3.50M),
            new Products("Coffee","Decaf",    "For Fun",        2.50M),
            new Products("Tea",   "Bubble",   "Happy Day",      4.50M),
            new Products("Tea",   "Green",    "Energy for Days",3.50M),
            new Products("Tea",   "Black",    "Wide Awake",     3.00M),
            new Products("Tea",   "Ginger",   "Tummy Love",     3.50M),
            new Products("Tea",   "Sleepy",   "Sweet Dreams",   4.00M),
            new Products("Tea",   "Lemon",    "Citrus Treat",   2.50M),
        };

        List<Products> items = new List<Products>();
        public List<Products> Product
        {
            get { return this._product; }
            set { this._product = value; }
        }

        public ShoppingCart()
        {

        }

        public void ListProducts()
        {
            int counter = 1;
            foreach (Products products in this._product)
            {
                Console.WriteLine($"{counter}. {products.ToString()}");
                counter++;
            }
        }

        public void AddToCart(int num)
        {

            num--;
            // decimal itemPrice = 0;
            Console.WriteLine(this._product[num].ToString());
            Console.WriteLine($"How many would you like to purchase?");
            //Console.WriteLine($"The max is 3 per item.");
            int qty = int.Parse(Console.ReadLine());
            Console.WriteLine();
            decimal total = qty * this._product[num].Price;
            decimal subtotal = total;
            decimal salesTax = 1.06M;
            decimal grandTotal = Math.Round(total * salesTax);

            Console.WriteLine($"You total is for {qty} {this._product[num].ToString()} is ${total}");
            Console.WriteLine();
            //Section checkout

            Console.WriteLine("Are you ready to checkout? y/n");
            string input;
            while (true)
            {
                input = Console.ReadLine().ToLower().Trim();
                if (input == "y")
                {
                    Console.WriteLine($"Your total is for {qty} {this._product[num].ToString()} is ${total}");
                    Console.WriteLine($"Subtotal: ${subtotal}");
                    Console.WriteLine($"Sales Tax: ${salesTax}");
                    Console.WriteLine($"Grand Total: ${grandTotal}");
                    break;
                    //This is where the payment of payment will go

                }
                else if (input == "n")
                {

                    //Continue to shop and add to cart
                    //Console.WriteLine("Thank you for shopping at Take a Sip!");
                    //Console.WriteLine("Enjoy your drinks and have a great day!");

                }
                else
                {
                    Console.WriteLine("That was not a y/n. Please try again.");
                }
            }

        }



        public void DisplayHeader()
        {
            string formatHeader = string.Format("{0,10} | {1,4} | {2,8} | {3,5}", "Category", "Name", "Description", "Price");
            Console.WriteLine(formatHeader);

        }
    }
}

        
