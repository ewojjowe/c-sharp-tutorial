using System;

namespace InputsAndExpressionsAndOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region -- Write --

            //Console.Write($"a{Environment.NewLine}");
            //Console.Write("b\n");

            //Console.WriteLine("c");
            //Console.WriteLine("d");

            #endregion

            #region -- Read --

            //var stringVlaue = Console.ReadLine();
            //Console.WriteLine($"Inputted value: {stringVlaue}");

            //var readTest = Console.Read();
            //Console.WriteLine($"{readTest}");

            //Console.WriteLine("Input your age: ");
            //var ageString = Console.ReadLine();
            //var age = int.Parse(ageString ?? "0");
            //if (age < 18)
            //    Console.WriteLine("minor");
            //else
            //    Console.WriteLine("adult");

            #endregion

            #region -- Expressions & Operators --

            /*
             * Types of Expressions
             * Constant expressions: 10
             * Literal Exrepssions with multiplication: 5 * 2
             * Compound Expressions: 2 + (4 * 2)
             * Void Expressions: Console.WriteLine()
             * Assignment Expressions: a = 10, Compound Assignment: a = 5 + 5
             * Primary Expressions: Math.Pow(10, 1)
             * Boolean Expressions
            */

            /*
             * Types of Operators
             * Assignment "="
             * Arithmetic "* / + - %", precedence: (), [], ++, --, *, /, %, +. -
             * Boolean/Logical " && || "
             * Equality "== !="
             * Comparison ">< >= <="
             * Null-coalescing "??"
             * Unary "! ++ --", pre/post decrement and increment
             * Ternary "? :"
             * Bitwise and shift
             * Member access
            */

            /*
             * Sample pythagorean theorem
             * Formula to get C: c = square root of (a square + b square)
            */ 

            Console.WriteLine("Input a value: ");
            var formulaA = double.Parse(Console.ReadLine());
            Console.WriteLine("Input b value: ");
            var formulaB = double.Parse(Console.ReadLine());

            var computedSquareRt = Math.Sqrt(Math.Pow(formulaA, 2) + Math.Pow(formulaB, 2));
            Console.WriteLine($"Sample C result: {computedSquareRt}");

            #endregion
        }
    }
}