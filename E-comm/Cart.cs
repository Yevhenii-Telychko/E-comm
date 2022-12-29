namespace E_comm
{
    public class Cart
    {
        public List<Product> CartStorage { get; set; }
        public double TotalPrice { get; set; }

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
                    TotalPrice += product.Price;

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
