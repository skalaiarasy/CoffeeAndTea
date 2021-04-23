using System;
using System.Collections.Generic;
using System.IO;

namespace CoffeeAndTea
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Drinks> drinks = new List<Drinks>();
            StreamReader reader = new StreamReader("StoreList.txt");
          
            while (true)
            {
                string line = reader.ReadLine();
                if(line == null)
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

                    Drinks drink = new Drinks(category, name, price, type);
                    Console.WriteLine(drink.ToString());
                    drinks.Add(drink);
                    
                }
            }
            reader.Close();
        }


        
    }
}
