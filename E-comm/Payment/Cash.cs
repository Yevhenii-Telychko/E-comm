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
            Amount -= amount;
            balance.Amount += amount;
        }
    }
}
