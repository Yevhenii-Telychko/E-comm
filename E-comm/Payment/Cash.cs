namespace E_comm.Payment
{
    public class Cash
    {
        public double Amount { get; set; }

        public Cash()
        {
            Amount = 10000;
        }

        public void TransferToBalance(int amount, Balance balance)
        {
            if (Amount < amount)
            {
                throw new Exception("Not enough money :((");
            }
            Amount -= amount;
            balance.Amount += amount;
        }

        public void Pay(double price)
        {
            if (Amount < price)
            {
                throw new Exception("Not enough money");
            }
            Amount -= price;
            Console.WriteLine("Success");
        }



    }
}
