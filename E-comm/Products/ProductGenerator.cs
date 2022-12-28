namespace E_comm.Products
{
    public class ProductGenerator
    {
        Dictionary<string, string> productsBase = new Dictionary<string, string>()
        {
            {"Iphone 14", "1200$" },
            {"AirPods Pro", "270$" },
            {"MacBook Pro", "2700$" },
            {"IPad Pro", "1400$" },
            {"Dyson", "600$" },
        };

        List<Dictionary<string, string>> productsDescrition = new List<Dictionary<string, string>>()
        {
            new Dictionary<string, string>()
            {
                { "Screen diagonal","6.1" },
                { "Display resolution", "2532x1170" },
                { "Number of SIM cards", "2" },
                { "Built-in memory", "128 GB"}
            },
            new Dictionary<string, string>()
            {
                { "Headphone type", "TWS (2 separate)"},
                { "Peculiarities", "Apple compatibility, With moisture protection"},
                { "Connection type", "Wireless"},
                { "Availability of active noise cancellation", "With active noise cancellation"},
            },
            new Dictionary<string, string>()
            {
                { "Screen diagonal", "16.2"},
                { "CPU", "Octa-core Apple M1 Max"},
                { "RAM", "32 GB"},
                { "SSD capacity", "1 TB"},
            },
            new Dictionary<string, string>()
            {
                { "Screen diagonal", "12.9"},
                { "Built-in memory", "128 GB"},
                { "CPU", "Apple M2"},
                { "Screen refresh rate", "120 Hz"},
            },
            new Dictionary<string, string>()
            {
                { "Mode", "overheat protection, Ionization, Cold air supply"},
                { "Power, W", "1600"},
                { "Number of speeds", "3"},
                { "Number of temperature modes", "3"},
            }
        };

        public List<Product> InitProducts()
        {
            List<Product> products = new List<Product>();
            foreach (var productBase in productsBase)
            {
                Product product = new Product(productBase.Key, productBase.Value);
                products.Add(product);
            }
            for (int i = 0; i < products.Count; i++)
            {
                products[i].AddDescription(productsDescrition[i]);
            }
            return products;
        }
    }
}
