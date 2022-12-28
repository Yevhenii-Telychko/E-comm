namespace E_comm.Payment
{
    public class Balance
    {
        public int Amount { get; set; }
        public Balance()
        {
            Amount = 0;
        }

        public void Pay(int price)
        {
            Amount -= price;
        }
    }

}
