namespace E_comm.Products
{
    public class ProductDescription
    {
        public Dictionary<string, string> Description { get; set; }

        public ProductDescription(Dictionary<string, string> description)
        {
            Description = description;
        }

        public void View()
        {
            foreach (var item in Description)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

    }
}
