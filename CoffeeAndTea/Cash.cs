namespace CoffeeAndTea
{
    class Cash : Payment
    {
        public Cash(string name, decimal payment) :base(name, payment)
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
