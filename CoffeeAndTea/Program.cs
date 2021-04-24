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
            //GetMenu();
            //Console.ReadLine();

            PaymentDetails pd = new PaymentDetails();
            decimal itemprice = 10;
            PaymentType pt = TakingCashPayments(itemprice);
            pd.TakingPayment(pt);
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

        static PaymentType TakingCashPayments(decimal itemPrice)
        {
            string usersName;
            while (true)
            {
                Console.WriteLine("Your name:");
                usersName = Console.ReadLine();
                if (ValidateUserInput.StringIsNumeric(usersName))
                {
                    Console.WriteLine("Name field cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            Cash userChoseCash = new Cash(usersName, itemPrice);
            return userChoseCash;
        }

        static PaymentType TakingCCPayments(decimal itemPrice)
        {
            string usersName;
            while (true)
            {
                Console.WriteLine("Your name:");
                usersName = Console.ReadLine();
                if (usersName == "")
                {
                    Console.WriteLine("Name field cannot be empty.");
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
                Console.WriteLine("Your name:");
                usersName = Console.ReadLine();
                if (usersName == "")
                {
                    Console.WriteLine("Name field cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            string checkNumber;
            while (true)
            {
                Console.WriteLine("Your name:");
                checkNumber = Console.ReadLine();
                if (checkNumber == "")
                {
                    Console.WriteLine("Name field cannot be empty.");
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
