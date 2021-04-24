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


    }
}
