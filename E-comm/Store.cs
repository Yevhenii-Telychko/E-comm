using E_comm.Payment;
using E_comm.Products;

namespace E_comm
{
    public class Store
    {
        public List<Customer> CustomerList { get; set; }
        List<Product> Products { get; set; }
        Customer customer { get; set; }
        public Store()
        {
            CustomerList = GenerateCustomer();
            ProductGenerator productGenerator = new ProductGenerator();
            Products = productGenerator.InitProducts();
        }

        private List<Customer> GenerateCustomer()
        {
            CustomerController userController = new CustomerController();
            string credentials;
            do
            {
                Console.WriteLine("Enter your name and surname");
                credentials = Console.ReadLine();
            } while (string.IsNullOrEmpty(credentials));

            string name = credentials.Split(' ')[0];
            string surname = credentials.Split(' ')[1];

            return new List<Customer>
            {
                userController.getBaseCustomer(name, surname),
                userController.getVipCustomer(name, surname)
            };


        }
        private void Greeting()
        {
            Console.WriteLine("Welcome to our store\n" +
                "Which customer are you:" +
                "\n1. Customer" +
                "\n2. Vip customer" +
                "\nYour choice:");
            int customerSelection = Convert.ToInt32(Console.ReadLine());
            switch (customerSelection)
            {
                case 1:
                    customer = CustomerList[0];
                    break;
                case 2:
                    customer = CustomerList[1];
                    break;
                default:
                    Console.WriteLine("Okay, you will be a normal one.");
                    customer = CustomerList[0];
                    break;
            }

            Console.WriteLine($"Welcome {customer.Name} {customer.Surname}.");
            customer.ShowAllMoney();
        }

        private void ProductPage(int productNumber)
        {
            Product product = Products[productNumber - 1];
            product.View();
            product.Description.View();
            Console.WriteLine("1. Add to the cart\n2. Go back");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                product.Price = customer.UpdatePrice(product.Price);
                customer.AddToCart(product);
            }
        }

        public string[] EnterCardDetails()
        {
            Console.WriteLine("Enter card number:");
            string cardNumber = Console.ReadLine();
            Console.WriteLine("Enter card password:");
            string cardPassword = Console.ReadLine();
            Console.WriteLine("Enter card CVV:");
            string cardCVV = Console.ReadLine();
            return new string[] { cardNumber, cardPassword, cardCVV };
        }

        public void PaymentNavigation()
        {
            Console.WriteLine("Please, choose a payment method");
            Console.WriteLine("1.Card\n2.Cash\n3.Balance\n4.Go back");
            int paymentChoise = Convert.ToInt32(Console.ReadLine());
            switch (paymentChoise)
            {
                case 1:
                    Console.WriteLine("1.Enter card");
                    if (customer.Cards.Count > 0)
                    {
                        Console.WriteLine("2.Use your card");
                    }
                    Console.WriteLine("3.Go back");
                    int cardChoice = Convert.ToInt32(Console.ReadLine());
                    switch (cardChoice)
                    {
                        case 1:
                            string[] cardDetails = EnterCardDetails();
                            new Card(cardDetails[0], cardDetails[1], cardDetails[2]).Pay(customer.CustomerCart.TotalPrice);
                            customer.CustomerCart.CartStorage.Clear();
                            break;
                        case 2:
                            Console.WriteLine("Enter the name of the card");
                            string cardName = Console.ReadLine();
                            if (!customer.Cards.ContainsKey(cardName))
                            {
                                Console.WriteLine("there is no card like that");
                                break;
                            }
                            customer.Cards[cardName].Pay(customer.CustomerCart.TotalPrice);
                            customer.CustomerCart.CartStorage.Clear();
                            break;
                        case 3:
                        default:
                            break;
                    }

                    break;
                case 2:
                    try
                    {
                        customer.Cash.Pay(customer.CustomerCart.TotalPrice);
                        customer.CustomerCart.CartStorage.Clear();
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"{error.Message}");
                    }

                    break;
                case 3:
                    try
                    {
                        customer.Balance.Pay(customer.CustomerCart.TotalPrice);
                        customer.CustomerCart.CartStorage.Clear();
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"{error.Message}");
                    }

                    break;
                case 4:
                default:
                    break;
            }
        }
        public void Run()
        {
            Greeting();


            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("1. Check the products\n" +
                                  "2. Add my credit card\n" +
                                  "3. Add money to the balance\n" +
                                  "4. Check my cart\n" +
                                  "5. Exit");
                int customerSelection = Convert.ToInt32(Console.ReadLine());
                switch (customerSelection)
                {
                    case 1:
                        for (int i = 0; i < Products.Count(); i++)
                        {
                            Console.Write($"{i + 1}. ");
                            Products[i].View();
                        }
                        Console.WriteLine("Your choice: ");

                        string productNumber = Console.ReadLine();
                        if (!string.IsNullOrEmpty(productNumber) &&
                            productNumber.All(char.IsDigit) &&
                            Convert.ToInt32(productNumber) < Products.Count())
                        {
                            ProductPage(Convert.ToInt32(productNumber));
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the name of the card");
                        string cardName = Console.ReadLine();
                        if (string.IsNullOrEmpty(cardName)) cardName = $"card {customer.Cards.Count + 1}";
                        string[] cardDetails = EnterCardDetails();
                        customer.AddCard(cardName, cardDetails[0], cardDetails[1], cardDetails[2]);
                        break;
                    case 3:
                        Console.WriteLine("Enter amount of money:");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        customer.AddBalance(amount);
                        break;
                    case 4:
                        customer.CustomerCart.CheckCart();
                        Console.WriteLine("1.Buy products\n2.Go back");
                        int customerChoise = Convert.ToInt32(Console.ReadLine());
                        switch (customerChoise)
                        {
                            case 1:
                                PaymentNavigation();
                                break;
                            case 2:
                            default:
                                break;
                        }

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
