namespace E_comm
{

    class CustomerController
    {
        public Customer getBaseCustomer()
        {
            return new BaseCustomer("Yevhenii", "Telychko");
        }

        public Customer getVipCustomer()
        {
            return new VipCustomer("Yevhenii", "Telychko");
        }
    }

}
