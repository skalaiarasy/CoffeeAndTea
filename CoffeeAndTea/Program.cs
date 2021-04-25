using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoffeeAndTea
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMenu();
            PaymentSelection();
            Console.ReadLine();
        }

        static void GetMenu()
        {
            StreamReader reader = new StreamReader("StoreList.txt");
            List<Drinks> menu = new List<Drinks>();

            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                else
                {
                    string[] splitLine = line.Split(",");
                    string category = splitLine[0];
                    string name = splitLine[1];
                    decimal price = decimal.Parse(splitLine[2]);
                    string type = splitLine[3];

                    Drinks drinkDetails = new Drinks(category, name, price, type);

                    //Console.WriteLine(drinkDetails.ToString());
                    menu.Add(drinkDetails);
                }
            }
            // This will display all items to the screen
            reader.Close();
            Console.WriteLine("WELCOME to our COFFEE and TEA Shop!");
            int counter = 0;
            foreach (Drinks drink in menu)
            {
                counter++;
                Console.WriteLine($"{counter}. {drink}");
            }
        }

        static List<string> UserMakingASelection(List<Drinks> listOfDrinks, int choice)
        {
            List<string> itemsPurchased = new List<string>();
            //List<int> pricesPerItem = new List<int>();

            GetMenu();

            bool runApplication = true;
            while (runApplication)
            {
                Console.WriteLine("\n\nWhat item would you like to order?");
                choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("That was not a number.");
                    continue;
                }// everything above is working.

                do
                {
                    // Initial purchasing
                    string placeOrder = Console.ReadLine();
                    Console.Clear();

                    if (listOfDrinks.Count == choice)
                    {
                        itemsPurchased.Add(listOfDrinks);
                        //pricesPerItem.Add(result);
                        Console.WriteLine($"Adding {placeOrder} to cart at "); /*{result}*/
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, we don't have {placeOrder}. Please try again.");
                    }

                } while (true);

                // Check if they want to buy again
                Console.WriteLine("Would you like to order anything else (y/n)?");
                while (true)
                {
                    string loopChoice = Console.ReadLine();
                    if (loopChoice == "y")
                    {
                        break;
                    }
                    else if (loopChoice == "n")
                    {
                        runApplication = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("that was not a valid choice");
                    }
                }
            }
            return itemsPurchased;
        }


        static void PaymentSelection(/*It's possible we will have to pass a parameter here*/)
        {
            PaymentDetails pd = new PaymentDetails();
            Console.WriteLine("Choose a payment method: \n1. for cash\n2. for credit card\n3. for checks");
            while (true)
            {
                string paymentMethodChosen = Console.ReadLine();
                if (paymentMethodChosen == "1")
                {
                    Console.WriteLine("Give up the Moola!");
                    decimal userGiveMoney = decimal.Parse(Console.ReadLine());
                    decimal GrandTotal = 10;
                    if (userGiveMoney >= GrandTotal)
                    {
                        Console.WriteLine($"Cash Tender: \t${userGiveMoney}");
                        decimal changesToGiveBack = GrandTotal - userGiveMoney;
                        Console.WriteLine($"Change due: \t${-changesToGiveBack}");
                    }
                    break;
                }
                else if (paymentMethodChosen == "2")
                {
                    decimal itemprice = 10; // the value coming into itemprice needs to come from the total price of item already purchased
                    PaymentType pt = TakingCCPayments(itemprice);
                    pd.TakingPayment(pt);
                    break;
                }
                else if (paymentMethodChosen == "3")
                {
                    decimal itemprice = 10; // the value coming into itemprice needs to come from the total price of item already purchased
                    PaymentType pt = TakingCheckPayments(itemprice);
                    pd.TakingPayment(pt);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid entry. Choose a payment method: \n1. for cash\n2. for credit card\n3. for checks");
                }
            }

            Console.WriteLine("Thank you for your service");
        }
        static PaymentType TakingCCPayments(decimal itemPrice)
        {
            string usersName;
            while (true)
            {
                Console.WriteLine("Your name on the card:");
                usersName = Console.ReadLine();
                if (ValidateUserInput.StringNotEmpty(usersName) != true)
                {
                    Console.WriteLine("Name field cannot be empty.");
                }
                else if (ValidateUserInput.StringIsNumeric(usersName) == true)
                {
                    Console.WriteLine("Invalid entry. Please enter your name");
                }
                else
                {
                    break;
                }
            }

            string creditCardNumber;
            while (true)
            {
                Console.WriteLine("Credit Card Number:");
                creditCardNumber = Console.ReadLine();
                if (creditCardNumber == "")
                {
                    Console.WriteLine("Credit Card Number field cannot be empty.");
                }
                else if (ValidateUserInput.StringIsNumeric(creditCardNumber) == false)
                {
                    Console.WriteLine("Invalid entry. Please enter your name");
                }
                else
                {
                    break;
                }
            }

            string expirationDate;
            while (true)
            {
                Console.WriteLine("Expiration date:");
                expirationDate = Console.ReadLine();
                if (expirationDate == "")
                {
                    Console.WriteLine("Expiration Date field cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            string securityCode;
            while (true)
            {
                Console.WriteLine("Security Code:");
                securityCode = Console.ReadLine();
                if (securityCode == "")
                {
                    Console.WriteLine("Security code field cannot be empty.");
                }
                else
                {
                    break;
                }
            }
            CreditCard userChoseCC = new CreditCard(usersName, creditCardNumber, expirationDate, securityCode, itemPrice);
            return userChoseCC;
        }
        static PaymentType TakingCheckPayments(decimal itemPrice)
        {
            string usersName;
            while (true)
            {
                Console.WriteLine("Name on the check:");
                usersName = Console.ReadLine();
                if (ValidateUserInput.StringNotEmpty(usersName) != true)
                {
                    Console.WriteLine("Name field cannot be empty.");
                }
                else if (ValidateUserInput.StringIsNumeric(usersName) == true)
                {
                    Console.WriteLine("Invalid entry. Please enter your name");
                }
                else
                {
                    break;
                }
            }

            string checkNumber;
            while (true)
            {
                Console.WriteLine("Check Number:");
                checkNumber = Console.ReadLine();
                if (ValidateUserInput.StringNotEmpty(checkNumber) != true)
                {
                    Console.WriteLine("Name field cannot be empty.");
                }
                else if (ValidateUserInput.StringIsNumeric(checkNumber) == false)
                {
                    Console.WriteLine("Invalid entry. Please enter a check number");
                }
                else
                {
                    break;
                }
            }

            Check userChoseCheck = new Check(usersName, checkNumber, itemPrice);
            return userChoseCheck;
        }
    }
}
