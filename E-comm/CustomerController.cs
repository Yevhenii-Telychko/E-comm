namespace E_comm
{

    class CustomerController
    {
        public Customer getBaseCustomer(string name, string surname)
        {
            return new BaseCustomer(name, surname);
        }

        public Customer getVipCustomer(string name, string surname)
        {
            return new VipCustomer(name, surname);
        }
    }

}
