using System;
using System.Collections;
using NamespaceAndComments.Fruits;

namespace NamespaceAndComments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var queue = new Queue();
            var banana = new Banana();
            var apple = new NamespaceAndComments.Fruits.Apple();
        }
    }
}