using E_comm.Products;

namespace E_comm
{
    public class Store
    {

        public void Run()
        {
            CustomerController userController = new CustomerController();
            List<Customer> customerList = new List<Customer>
            {
                userController.getBaseCustomer(),
                userController.getVipCustomer()
            };
            Customer customer;

            ProductGenerator productGenerator = new ProductGenerator();
            List<Product> products = productGenerator.InitProducts();

            Console.WriteLine("Welcome to our store\n" +
                "Which customer are you:" +
                "\n1. Customer" +
                "\n2.Vip customer" +
                "\nYour choice:");
            int customerSelection = Convert.ToInt32(Console.ReadLine());
            switch (customerSelection)
            {
                case 1:
                    customer = customerList[0];
                    break;
                case 2:
                    customer = customerList[1];
                    break;
                default:
                    Console.WriteLine("Okay, you will be a normal one.");
                    customer = customerList[0];
                    break;
            }

            Console.WriteLine($"Welcome {customer.Name} {customer.Surname}.");
            customer.ShowAllMoney();

            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("1. Check the products\n" +
                                  "2. Add my credit card\n" +
                                  "3. Add money to the balance\n" +
                                  "4. Check my cart\n" +
                                  "5. Exit");
                customerSelection = Convert.ToInt32(Console.ReadLine());
                switch (customerSelection)
                {
                    case 1:
                        for (int i = 0; i < products.Count(); i++)
                        {
                            Console.Write($"{i + 1}. ");
                            products[i].View();
                        }
                        Console.WriteLine("Your choice: ");
                        int productNumber = Convert.ToInt32(Console.ReadLine());
                        switch (productNumber)
                        {
                            case 1:
                                products[productNumber - 1].View();
                                products[productNumber - 1].Description.View();
                                Console.WriteLine("1. Buy\n2. Go back");
                                if (Convert.ToInt32(Console.ReadLine()) == 1)
                                {
                                    Console.WriteLine("Congrats");
                                }
                                break;
                            case 2:
                                products[productNumber - 1].View();
                                products[productNumber - 1].Description.View();
                                Console.WriteLine("1. Buy\n2. Go back");
                                if (Convert.ToInt32(Console.ReadLine) == 1)
                                {
                                    Console.WriteLine("Congrats");
                                }
                                break;
                            case 3:
                                products[productNumber - 1].View();
                                products[productNumber - 1].Description.View();
                                Console.WriteLine("1. Buy\n2. Go back");
                                if (Convert.ToInt32(Console.ReadLine) == 1)
                                {
                                    Console.WriteLine("Congrats");
                                }
                                break;
                            case 4:
                                products[productNumber - 1].View();
                                products[productNumber - 1].Description.View();
                                Console.WriteLine("1. Buy\n2. Go back");
                                if (Convert.ToInt32(Console.ReadLine) == 1)
                                {
                                    Console.WriteLine("Congrats");
                                }
                                break;
                            case 5:
                                products[productNumber - 1].View();
                                products[productNumber - 1].Description.View();
                                Console.WriteLine("1. Buy\n2. Go back");
                                if (Convert.ToInt32(Console.ReadLine) == 1)
                                {
                                    Console.WriteLine("Congrats");
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter card number:");
                        string cardNumber = Console.ReadLine();
                        Console.WriteLine("Enter card password:");
                        string cardPassword = Console.ReadLine();
                        Console.WriteLine("Enter card CVV:");
                        string cardCVV = Console.ReadLine();
                        customer.AddCard(cardNumber, cardPassword, cardCVV);
                        break;
                    case 3:
                        Console.WriteLine("Enter amount of money:");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        customer.AddBalance(amount);
                        break;
                    case 4:
                        break;
                    case 5:
                    default:
                        Console.WriteLine("Bye Bye");
                        isWorking = false;
                        break;
                }
            }


        }
    }
}
