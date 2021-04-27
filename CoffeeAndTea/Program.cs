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
            Console.WriteLine();
            decimal GrandTotal = GetMenu();
            Console.WriteLine($"Grand Total: \t${GrandTotal}");
            Console.WriteLine();

            PaymentSelection(GrandTotal);
            Console.ReadLine();
        }

        static decimal GetMenu() // Mock display to confirm the list is working
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
            int userQty;

            Console.WriteLine();
            Console.WriteLine("Which drink would you like to purcahse:? Choose a number:");
            while (true)
            {
                int userinput = ValidateUserInput.UserSelection(); //?

                int counter2 = 0;
                //this foreach grab an item per user selection
                foreach (Drinks userChoice in menu)
                {

                    counter2++;
                    if (counter2 == userinput)
                    {
                        Console.WriteLine($"{ userChoice.Name} \t${ userChoice.Price }");
                        Console.WriteLine();
                        Console.WriteLine($"How many { userChoice.Name } would you like?");
                        userQty = int.Parse(Console.ReadLine());

                        Console.WriteLine($"{userQty} { userChoice.Name} \t${ userChoice.Price * userQty }");

                        //userChoice.Price *= userQty;
                        itemQtyList.Add(userQty);
                        itemOrderedList.Add(userChoice.Name);
                        listOfItemPriced.Add(userChoice.Price);
                    }
                }

                bool addItems = true;
                Console.WriteLine();
                Console.WriteLine("Would you like to add more items? y/n");
                while (true)
                {
                    string addCheck = Console.ReadLine().ToLower().Trim();
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
            Console.WriteLine("Thank you for your order!");
            Console.WriteLine();
            Console.WriteLine("These are your items:");
            Console.WriteLine();

            List<decimal> totalPriced = new List<decimal>(); // We added another list to confirm make sure price per item is displayed
            decimal tempPrice;
            decimal totalQty = 0;
            for (int i = 0; i < itemOrderedList.Count; i++)
            {
                totalQty += itemQtyList[i];
                tempPrice = listOfItemPriced[i] * itemQtyList[i];
                totalPriced.Add(tempPrice);
                
                Console.WriteLine($"{itemQtyList[i]} {itemOrderedList[i] } \t${listOfItemPriced[i] * itemQtyList[i]}");
            }
            Console.WriteLine();
            Console.WriteLine($"You purchased: \t{ totalQty } items"); // there a bug here

            PaymentDetails salestax = new PaymentDetails();
            decimal Total = 0, grandTotal;

            foreach (decimal value in totalPriced)//add all values into averagePrice
            {
                Total += value;
            }
            //Total *= listOfItemPriced.Count;
            Console.WriteLine($"\nSubtotal: \t${Total}");
            Console.WriteLine($"Sales tax: \t{ salestax.SalesTaxTendered() * 100}%");

            grandTotal = Math.Round(Total + (Total * salestax.SalesTaxTendered()), 2);
            return grandTotal;
        }
        static void PaymentSelection(decimal totalFromReceipt)
        {
            PaymentDetails pd = new PaymentDetails();
            Console.WriteLine("How would you like to pay for your items?:");
            while (true)
            {
                Console.WriteLine("1. for cash\n2. for credit card\n3. for checks");
                string paymentMethodChosen = Console.ReadLine(); // This validation is working
                if (paymentMethodChosen == "1")
                {
                    Console.WriteLine($"Remember your total is { totalFromReceipt }");

                    while (true)
                    {
                        string cashFromUserStr = Console.ReadLine();

                        if (ValidateUserInput.StringIsNumeric(cashFromUserStr) && cashFromUserStr != "" && decimal.Parse(cashFromUserStr) >= totalFromReceipt)
                        {
                            decimal cashFromUserDec = decimal.Parse(cashFromUserStr);
                            Console.WriteLine();
                            // I will need the the total receipt again
                            Console.WriteLine($"Cash Tender: \t${ cashFromUserDec }");
                            decimal changesToGiveBack = totalFromReceipt - cashFromUserDec;
                            Console.WriteLine($"Change due: \t${-changesToGiveBack}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid entry! Enter cash greater than { totalFromReceipt }");
                        }
                    }
                    break;
                }
                else if (paymentMethodChosen == "2")
                {
                    //decimal itemprice = totalFromReceipt; 
                    PaymentType pt = TakingCCPayments(totalFromReceipt);// the value coming into itemprice needs to come from the total price of item already purchased
                    pd.TakingPayment(pt);
                    break;
                }
                else if (paymentMethodChosen == "3")
                {
                    PaymentType pt = TakingCheckPayments(totalFromReceipt);
                    pd.TakingPayment(pt);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid entry. Choose a payment method:");
                }
            }

            Console.WriteLine("Thank you for your service. \nSee your receipt for your purchases");
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
                    Console.WriteLine("Invalid entry. Please enter your credit number");
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
                    Console.WriteLine("Numbers are not allowed in the name filed. Please enter your name");
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
                    Console.WriteLine("Check Number field cannot be empty.");
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
