using System;

namespace CoffeeAndTea
{
    class ValidateUserInput
    {
        public static bool AboveZero(int x)
        {
            if (x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool StringNotEmpty(string value)
        {
            if (value == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool StringIsNumeric(string value)
        {
            try
            {
                int x = int.Parse(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidatorInput(int userInput, int counter)
        {
            bool output = true;
            if (userInput <= 0 || userInput > counter)
            {
                Console.WriteLine("Not less than 0 and more than the list");
                output = false;
            }
            return output;
        }
    }
}
