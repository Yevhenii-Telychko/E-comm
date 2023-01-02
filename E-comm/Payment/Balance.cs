namespace E_comm.Payment
{
    public class Balance
    {
        public double Amount { get; set; }
        public Balance()
        {
            Amount = 0;
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
