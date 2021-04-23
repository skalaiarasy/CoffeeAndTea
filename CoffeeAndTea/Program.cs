using System;
using System.Collections.Generic;
using System.IO;

namespace CoffeeAndTea
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

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

    class CreditCards : Payment
    {
        private string _cardNumber;
        private string _expDate;
        private string _securityCode;

        public string SecurityCode
        {
            get { return _securityCode; }
            set { _securityCode = value; }
        }

        public string ExpirationDate
        {
            get { return _expDate; }
            set { _expDate = value; }
        }

        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

    }
}
