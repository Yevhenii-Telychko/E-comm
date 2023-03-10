using E_comm.Payment;

namespace E_comm
{
    public abstract class Customer
    {
        private static int IdGenerator = 1234;

        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Balance Balance { get; set; }
        public Cash Cash { get; set; }
        public Cart CustomerCart { get; }
        public Dictionary<string, Card> Cards { get; set; }

        public Customer(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Cards = new Dictionary<string, Card>();
            Balance = new Balance();
            Cash = new Cash();
            CustomerCart = new Cart();
            Id = ++IdGenerator;
        }

        public abstract double UpdatePrice(double price);

        public virtual void AddCard(string cardName, string cardNumber, string cardPassword, string cvv)
        {
            try
            {

                Card card = new Card(cardNumber, cardPassword, cvv);
                Cards.Add(cardName, card);
                Console.WriteLine("Successfully added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public virtual void AddBalance(int amount)
        {
            try
            {
                Cash.TransferToBalance(amount, Balance);
                Console.WriteLine("Chin chin...\n");
                ShowAllMoney();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public virtual void AddToCart(Product product)
        {
            CustomerCart.AddProduct(product);
        }

        public virtual void ShowAllMoney()
        {
            Console.WriteLine($"Your balance: {Balance.Amount}.\nYour cash: {Cash.Amount}.");
        }
    }
}
