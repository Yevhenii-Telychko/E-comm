namespace E_comm
{
    public class Cart
    {
        public List<Product> CartStorage { get; set; }
        public double TotalPrice
        {
            get
            {
                double price = 0;
                foreach (var product in CartStorage)
                {
                    price += product.Price;
                }
                return price;
            }
        }

        public Cart()
        {
            CartStorage = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            CartStorage.Add(product);
            Console.WriteLine("Product added");
        }

        public void CheckCart()
        {
            if (CartStorage.Count != 0)
            {
                foreach (var product in CartStorage)
                {
                    product.View();

                }
                Console.WriteLine($"Total: {TotalPrice}");

            }
            else
            {
                Console.WriteLine("Your cart is empty");

            }
        }
    }
}
