namespace CoffeeAndTea
{
    class Payment
    {
        private string _name;
        private decimal _payment;
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private decimal Money
        {
            get { return this._payment;  }
            set { this._payment = value; }
        }

        public Payment(string name, decimal payment)
        {
            this._name = name;
            this._payment = payment;
        }

        public override string ToString()
        {
            return $"{ this._name } { this._payment }";
        }
    }

}
