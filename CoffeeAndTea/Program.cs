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
            foreach (Drinks drinkDetails in menu)
            {
                counter++;
                Console.WriteLine($"{counter}. {drinkDetails}");
            }

            List<string> itemOrdered = new List<string>();
            List<string> itemPriced = new List<string>();
            string itemName, itemPrice;

            Console.WriteLine("We are taking your order. Which item do you want?");
            while (true)
            {
                string userinput = Console.ReadLine().ToLower();
                foreach (Drinks oneDrink in menu)
                {
                    if (oneDrink.Name.ToLower() == userinput)
                    {
                        string[] splittingRow = oneDrink.ToString().Split(",");
                        itemName = splittingRow[1];
                        itemPrice = splittingRow[2];
                        Console.WriteLine($"{ itemName }: { itemPrice }");

                        //Items name and price are being stored here to receipted
                        itemOrdered.Add(itemName);
                        itemPriced.Add(itemPrice);
                    }
                }

                bool addItems = true;
                Console.WriteLine("Would you like to add more items? y/n");
                while (true)
                {
                    string addCheck = Console.ReadLine();
                    if (addCheck == "y")
                    {
                        Console.WriteLine("What addtional items do you want?");
                        break;
                    }
                    else if (addCheck == "n")
                    {
                        addItems = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid input.");
                    }
                }

                if (addItems == false)
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("Thank you for your order");
            Console.WriteLine("These are your items:");
            for (int i = 0; i < itemOrdered.Count; i++)
            {
                Console.WriteLine($"{itemOrdered[i] } \t{itemPriced[i]}");
            }

            double Total = 0;
            double convertThePrice = Convert.ToDouble(itemPriced);
            foreach (double value in convertThePrice.ToString())//add all values into averagePrice
            {
                Total += value;
            }
            //get average using averagePrice and list.Count
            Total = Math.Round(Total, 2);
            Console.WriteLine($"Your bill: ${Total}");
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
