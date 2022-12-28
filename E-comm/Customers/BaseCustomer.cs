namespace E_comm
{
    public class BaseCustomer : Customer
    {
        public BaseCustomer(string name, string surname) : base(name, surname) { }
        public override double UpdatePrice(double price)
        {
            return price;
        }
    }
}
