using System;
using System.Collections.Generic;
using System.IO;

namespace rascunho
{
    static class StockCalculate
    {
        public static void calculate(string target)
        {
            List<Product> products = new List<Product>();
            string[] itens = File.ReadAllLines(target);
            foreach (string item in itens)
            {
                string[] vet = Console.ReadLine().Split(',');
                string name = vet[0];
                double price = double.Parse(vet[1]);
                int quantity = int.Parse(vet[2]);
                Product p = new Product(name, price, quantity);
                Console.WriteLine(p);
            }
        }
    }

}
