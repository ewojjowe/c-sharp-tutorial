using System;
using System.Collections;
using NamespaceAndComments.Fruits;
using NamespaceAndComments.Heroes.MobileLegends.Fighters;
using NamespaceAndComments.Heroes.MobileLegends.Mages;

// namespace alias
using PinoyBisayaHero = NamespaceAndComments.Heroes.Pinoy.Bisaya;

namespace NamespaceAndComments
{
    class Program
    {
        static void Main(string[] args)
        {
            #region -- Namespace Demo --

            Console.WriteLine("Hello World");
            var queue = new Queue();
            var banana = new Banana();
            var apple = new NamespaceAndComments.Fruits.Apple();

            // Hero
            var lapu2 = new LapuLapu();
            var valir = new Valir();

            var lapuLapu = new PinoyBisayaHero.LapuLapu();

            #endregion

            #region -- Comments Demo --

            // this is a single line comment

            /*
             * this is a multiple line comment 
             * format
            */

            #endregion
        }
    }
}