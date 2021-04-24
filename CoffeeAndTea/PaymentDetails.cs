using System;
using System.Collections.Generic;

namespace CoffeeAndTea
{
    class PaymentDetails
    {
        private List<PaymentType> _paymentChoices = new List<PaymentType>
        {
            new PaymentType("Cash", 12),
            new CreditCard("credit card", "465456454654", "June-2025", "4455", 15.5m),
            new Check("checks", "456456465", 15)
        };

        public List<PaymentType> PaymentTypes
        {
            get { return this._paymentChoices; }
            set { this._paymentChoices = value; }
        }
        public PaymentDetails()
        {
            // No values heres
        }

        public void ReceiptPaymentDetails()
        {
            foreach (PaymentType pt in this._paymentChoices)
            {
                Console.WriteLine(pt.ToString());
            }
        }

        public void TakingPayment(PaymentType paymentChoice)
        {
            this._paymentChoices.Add(paymentChoice);
            Console.WriteLine("Look at that!");
            ReceiptPaymentDetails();
        }
    }
}
