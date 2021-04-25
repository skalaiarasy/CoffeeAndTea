using System;
using System.Collections.Generic;

namespace CoffeeAndTea
{
    class PaymentDetails
    {
        private List<PaymentType> _paymentChoices = new List<PaymentType>
        {
            //Empty list of payment.
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
            ReceiptPaymentDetails();
        }
    }
}
