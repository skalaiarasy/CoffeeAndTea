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
            //List<string> itemBuy = new List<string>();
           // List<decimal> itemPrice = new List<decimal>();

            num--;
            // decimal itemPrice = 0;
            Console.WriteLine(this._product[num].ToString());
            Console.WriteLine($"How many would you like to purchase?");
            //Console.WriteLine($"The max is 3 per item.");
            int qty = 0;
            while (true)

            {       qty = int.Parse(Console.ReadLine());
                if (qty <= 0)
                {
                    Console.WriteLine("That number is to small.Please try again.");
                } 
                else
                {
                    break;
                }
            }
             for(int i = 0; i < qty; i++)
             {
                items.Add(this._product[num]);
             }

            //Checkout
            //Console.WriteLine();
            //decimal total = qty * this._product[num].Price;
            //decimal subtotal = total;
            //decimal salesTax = 1.06M * qty;
            //decimal grandTotal = Math.Round(total + salesTax);

            //Console.WriteLine($"Your total for ({qty}) {this._product[num].ToString()} is ${total}");
            //Console.WriteLine();
            ////Console.WriteLine($"Your total is for {qty} {this._product[num].ToString()} is ${total}");
            //Console.WriteLine($"Subtotal: ${subtotal}");
            //Console.WriteLine($"Sales Tax: ${salesTax}");
            //Console.WriteLine($"Grand Total: ${grandTotal}");

        }
        public void MoreItems()
        {
            //List<string> itemBuy = new List<string>();
            //List<int> itemPrice = new List<int>();
            // foreach(Products items in item)
            List<Products> items = new List<Products>();
            items.AddRange(items);
            foreach(Products add in items)
            {
                Console.WriteLine(add);
            }

        }

        public void Checkout()
        {
            Console.WriteLine("Are you ready to checkout?  y/n");
            string input;
            while (true)
            {
                int qty = 0;
                input = Console.ReadLine();
                if (input == "y")
                {
                    decimal total = qty * this._product[num].Price;
                    //DISPLAY receipt
                    foreach (Products add in items)
                    {
                        Console.WriteLine(add);
                        total += add; 

                    }
                    Console.WriteLine();
                    //decimal total = qty * this._product[num].Price;
                    decimal subtotal = total;
                    decimal salesTax = 1.06M * qty;
                    decimal grandTotal = Math.Round(total + salesTax);

                    //Console.WriteLine($"Your total for ({qty}) {this._product[num].ToString()} is ${total}");
                    Console.WriteLine();
                    //Console.WriteLine($"Your total is for {qty} {this._product[num].ToString()} is ${total}");
                    Console.WriteLine($"Subtotal: ${subtotal}");
                    Console.WriteLine($"Sales Tax: ${salesTax}");
                    Console.WriteLine($"Grand Total: ${grandTotal}");
                    Console.WriteLine();
                    Console.WriteLine("Thank you for shopping at Take a Sip!");
                    Console.WriteLine("Enjoy your drinks and have a great day!");
                }
                else if (input == "n")
                {

                    break;
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

        
