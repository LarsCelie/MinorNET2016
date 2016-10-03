using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag16.NorthWind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DeleteProduct();
            //AddProduct();
            //PrintProductByFilter();
            //PrintAllProducts();
        }

        private static void DeleteProduct()
        {
            var target = new ProductRepository();
            target.Delete(target.FindBy(Product => Product.ProductId == 78).Single());
            Console.WriteLine("Product with Id 78 deleted");
            Console.ReadLine();
        }

        private static void AddProduct()
        {
            var target = new ProductRepository();
            var product = new Products { ProductName = "How to be amazing like Lars" };
            target.Insert(product);
            Console.ReadLine();
        }

        private static void PrintProductByFilter()
        {
            var target = new ProductRepository();
            foreach (Products product in target.FindBy(product => product.ProductId == 1))
            {
                Console.WriteLine(product.ProductName);

            }
            Console.ReadLine();
        }

        private static void PrintAllProducts()
        {
            var target = new ProductRepository();
            foreach (Products product in target.FindAll())
            {
                Console.WriteLine(product.ProductName);

            }
            Console.ReadLine();
        }
    }
}
