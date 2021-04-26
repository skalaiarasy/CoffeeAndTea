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

            Console.WriteLine("WELCOME to our COFFEE/TEA Shop!");
            decimal total = GetMenu();
            Console.WriteLine($"Your bill: ${total}");
            PaymentSelection(total);
            Console.ReadLine();
        }

        static decimal GetMenu()
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
                    menu.Add(drinkDetails);
                }
            }

            reader.Close();

            //This foreach display the menu
            int counter = 0;
            Console.WriteLine(string.Format("\t{0, -15} {1, -16} {2, -16} {3, -16}", "Category", "Name", "Price", "Description"));
            foreach (Drinks drinkDetails in menu)
            {
                counter++;
                Console.WriteLine($"{counter}. {drinkDetails}");
            }

            List<string> itemOrderedList = new List<string>();
            List<decimal> listOfItemPriced = new List<decimal>();
            List<int> itemQtyList = new List<int>();
            int userQty = 0;

            Console.WriteLine("Which drink would you like to purcahse:? Choose a number:");
            while (true)
            {
                int userinput = int.Parse(Console.ReadLine());
                
                int counter2 = 0;
                //this foreach grab an item per user selection
                foreach (Drinks userChoice in menu)
                {

                    counter2++;
                    if (counter2 == userinput)
                    {
                        Console.WriteLine($"{ userChoice.Name} \t{ userChoice.Price }");

                        Console.WriteLine($"How many of { userChoice.Name } would you like?");
                        userQty = int.Parse(Console.ReadLine());

                        Console.WriteLine($"{userQty} * { userChoice.Name} \t{ userChoice.Price * userQty }");

                        //userChoice.Price *= userQty;
                        itemQtyList.Add(userQty);
                        itemOrderedList.Add(userChoice.Name);
                        listOfItemPriced.Add(userChoice.Price);
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
            for (int i = 0; i < itemOrderedList.Count; i++)
            {
                Console.WriteLine($"{itemQtyList[i]} {itemOrderedList[i] } \t{listOfItemPriced[i]}");
            }
            Console.WriteLine($"You bought: \t{userQty + itemOrderedList.Count } items.");

            PaymentDetails salestax = new PaymentDetails();
            decimal Total = 0, grandTotal;
            foreach (decimal value in listOfItemPriced)//add all values into averagePrice
            {
                Total += value;
            }
            Console.WriteLine($"Total before tax: \t{Total}");
            Console.WriteLine($"Sales Tax: \t{ salestax.SalesTaxTendered() *100 }%");

            grandTotal = Math.Round(Total + (Total * salestax.SalesTaxTendered()), 2);
            return grandTotal;
        }
        static void PaymentSelection(decimal total)
        {
            PaymentDetails pd = new PaymentDetails();
            Console.WriteLine("Choose a payment method: \n1. for cash\n2. for credit card\n3. for checks");
            while (true)
            {
                string paymentMethodChosen = Console.ReadLine(); // This validation is working
                if (paymentMethodChosen == "1")
                {
                    Console.WriteLine("Give up the Moola!");
                    decimal userGiveMoney = decimal.Parse(Console.ReadLine());
                    decimal GrandTotal = total;
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
