﻿namespace E_comm.Payment
{
    public class Card
    {
        public string CardNumber { get; }
        public string CardPassword { get; set; }
        public string CVV { get; }

        public Card(string cardNumber, string cardPassword, string cvv)
        {
            if (!ValidateCard(cardNumber, cardPassword, cvv))
            {
                throw new Exception("Please enter valid credentials");
            }
            CardNumber = cardNumber;
            CardPassword = cardPassword;
            CVV = cvv;
        }



        private bool ValidateCard(string cardNumber, string cardPassword, string cvv)
        {
            if (cardNumber == null || cardPassword == null || cvv == null)
            {
                return false;
            }
            return cardNumber.Length == 16 && cardPassword.Length == 4 && cvv.Length == 3;
        }
    }
}
