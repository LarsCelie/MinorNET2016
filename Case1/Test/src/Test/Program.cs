using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Animal a = new Bird();
            List<Animal> alist = new List<Animal>();
            IEnumerable<Bird> asd = new List<Bird>();
            IEnumerable<Animal> assd = new List<Bird>();
        }
    }

    internal class Bird : Animal
    {
    }

    internal class Animal
    {
    }
}
