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

        public CreditCards(string name, decimal payment, string cardNumber, string expDate, string securityCode) :base (name, payment)
        {
            this._cardNumber = cardNumber;
            this._expDate = expDate;
            this._securityCode = securityCode;
        }
    }

}
