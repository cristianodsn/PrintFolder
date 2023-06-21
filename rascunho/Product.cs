using System.Globalization;

namespace rascunho
{
    public class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
           

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        double calculate()
        {          
            return (Price * Quantity);
        }

        public override string ToString()
        {
            return $"{Name}, {calculate()}";
        }
    }
}
