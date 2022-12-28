using E_comm.Products;

namespace E_comm
{
    public class Product
    {
        private static int idGenerator = 1234;
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public ProductDescription Description { get; set; }

        public Product(string name, string price)
        {
            Name = name;
            Price = price;
        }

        public void View()
        {
            Console.WriteLine($"Name: {Name} Price: {Price}");
        }

        public void AddDescription(Dictionary<string, string> descrition)
        {
            Description = new ProductDescription(descrition);
        }

    }
}
