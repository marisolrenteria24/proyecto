using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price {  get; set; }


        public Product()
        {
            Name = string.Empty;
            Code = string.Empty;
            Price = 0;
        }

        public Product(string name, string code, double price)
        {
            Name = name;
            Code = code;
            Price = price;
        }


        public override string ToString()
        {
            return $"{Name}, {Code}, Precio: {Price}";
        }
        public static List<Product> Productos { get; set; } = new List<Product>();
    }
}
