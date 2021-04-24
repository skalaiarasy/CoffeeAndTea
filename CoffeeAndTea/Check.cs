namespace CoffeeAndTea
{
    class Check : PaymentType
    {
        private string _checkNumber;

        private string CheckNumber
        {
            get { return this._checkNumber; }
            set { this._checkNumber = value; }
        }

        public Check(string name, decimal payment, string checkNumber) :base (name, payment)
        {
            this._checkNumber = checkNumber;
        }

        public override string ToString()
        {
            string result =  base.ToString();
            return $"{ result } "; // somehow we need to return the last four digit of the check number to the receipt.
        }
    }

}
