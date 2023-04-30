using System;
using System.Collections.Generic;

namespace ListEnumearationCollectionAndList
{
    class Program
    {
        static void Main(string[] args)
        {
            #region -- Array Declaration --

            // Implicit
            //int[] members = new int[10];
            //int[] numbersWithInit = new int[] { 1, 2, 3, 4 };
            //int[][] multiNumbers = new int[3][]
            //{
            //    new int[3] { 1, 2, 3},
            //    new int[3] { 4, 5, 6},
            //    new int[3] { 7, 8, 9}
            //};
            //int[,] otherNumbers = new int[2, 2];

            // Explicit
            var members = new int[10];
            var numbersWithInit = new int[] { 1, 2, 3, 4 };
            var multiNumbers = new int[3][]
            {
                new int[3] { 1, 2, 3},
                new int[3] { 4, 5, 6},
                new int[3] { 7, 8, 9}
            };

            #endregion

            #region -- Array Sample --

            var names = new[] { "fred", "jowe", "cute" };
            Console.WriteLine("Before update");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            names[1] = "fredddee";
            Console.WriteLine("After update");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"name at index 2: {names[2]}");

            // Multi-dimensional
            var rowsANdCells = new int[3][]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                new[] {7, 8, 9}
            };

            for (var row = 0; row < rowsANdCells.Length; row++)
            {
                Console.WriteLine($"row: {row}");
                foreach (var cell in rowsANdCells[row])
                {
                    Console.WriteLine($"value: {cell}");
                }
            }

            #endregion

            #region -- Enumerable, Collection, and List --

            // Enumeration - GetEnumerator()
            var countries = new[] { "Philippines", "USA", "Canada", "Pakistan", "Afghanistan" };
            IEnumerable<string> enumerableCountries = countries;
            //enumerableCountries[0] = "Phl";
            Console.WriteLine("================================");
            Console.WriteLine("Enumerable:");
            foreach(var country in enumerableCountries)
            {
                Console.WriteLine(country);
            }

            // Collection - GetEnumerator(), Count(), Add(), Remove(), Clear()
            ICollection<string> colCountries = new List<string>(enumerableCountries);
            colCountries.Add("Australia");
            colCountries.Remove("USA");
            //colCountries[0] = "sample";
            Console.WriteLine("================================");
            Console.WriteLine("Collections:");
            foreach(var country in colCountries)
            {
                Console.WriteLine(country);
            }

            // List - GetEnumerator(), Count(), Add(), Remove(), Clear(), this[], InsertAt(), RemoveAt()
            var listCountries = new List<string>(countries);
            var listInitCountries = new List<string>()
            {
                "Philippines",
                "USA"
            };
            var listCountriesNew = new List<string>();
            listCountriesNew.Add("Philippines");
            listCountriesNew.Add("USA");
            listCountriesNew.AddRange(new[] { "Canada", "Australia" });
            listCountriesNew.Remove("Philippines");
            listCountriesNew[0] = "America";
            Console.WriteLine("================================");
            Console.WriteLine("List of countries");
            for(var index = 0; index < listCountriesNew.Count; index++)
            {
                Console.WriteLine($"{index}:{listCountriesNew[index]}");
            }

            #endregion
        }
    }
}
