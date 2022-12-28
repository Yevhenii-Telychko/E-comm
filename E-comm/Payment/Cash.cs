namespace E_comm.Payment
{
    public class Cash
    {
        public int Amount { get; set; }

        public Cash()
        {
            Amount = 100000;
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
    }
}
