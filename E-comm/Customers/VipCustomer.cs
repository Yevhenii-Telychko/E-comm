namespace E_comm
{
    public class VipCustomer : Customer
    {
        public double Discount { get; set; }
        public VipCustomer(string name, string surname) : base(name, surname)
        {
            Discount = 0.95;
        }

        public override double UpdatePrice(double price)
        {
            return price * Discount;
        }
    }
}
