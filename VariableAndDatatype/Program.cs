using System;

namespace Episode1Part2b
{
    class Program
    {
        static void Main(string[] args)
        {
            #region -- About Variables --

            #region -- Local Variables --

            //local variables - within a method scope
            //LocalDataStoreSlot variable
            //explicit
            int sampleNumber = 3;
            //implicit
            var sampleNumberImplicit = 3; // var assign datatype during design time
            dynamic sampleNumberDynamic = 5; // dynamic assign datatype during runtime

            #endregion

            #region -- Class & Instance Variables --

            var episode1 = new EpisodeClass();
            Console.WriteLine(episode1.samplePublicInt);
            episode1.samplePublicInt = 250;
            Console.WriteLine(episode1.samplePublicInt);

            Console.WriteLine("****************");
            Console.WriteLine(EpisodeClass.sampleStaticOrClassVairableInt);
            EpisodeClass.sampleStaticOrClassVairableInt = 200;
            Console.WriteLine(EpisodeClass.sampleStaticOrClassVairableInt);

            #endregion

            #endregion

            #region -- About Datatypes --

            //Parse & Convert - avialable to any datatype

            // on parse, if provided null it will throw an error
            string textOne = "5";
            var intOne = int.Parse(textOne);
            var result = intOne * 5;
            Console.WriteLine($"(Parse)Text One result: {result}");

            string textTwo = "Sample";
            int intTwo;
            int.TryParse(textTwo, out intTwo);
            Console.WriteLine($"Result Two using TryParse: {intTwo}");

            string textThree = ":)";
            int intThree;
            if (int.TryParse(textThree, out intThree))
            {
                Console.WriteLine($"Result Three using TryParse: {intThree}");
            }
            else
            {
                Console.WriteLine($"{textThree} is not a number!");
            }

            // Inline variable declarations
            string textFour = "**TEST**";
            if (int.TryParse(textThree, out int intFour))
            {
                Console.WriteLine($"Result Four using TryParse: {intFour}");
            }
            else
            {
                Console.WriteLine($"{textFour} is not a number!");
            }

            // on convert, if provided null it will return a default 0 value
            var intConverted = Convert.ToInt32(textOne);
            result = intConverted * 5;
            Console.WriteLine($"(Convert)Text One result: {result}");

            #endregion
        }
    }

    public class EpisodeClass
    {
        // Class variable - attached to the type or class
        public static int sampleStaticOrClassVairableInt = 3;

        // Instance variable - need to create new instance of this class to be accessible
        public int samplePublicInt = 500;
        // Private - same with field, only accessible inside the class
        private int samplePrivateInt = 100;

        #region -- Fields Variable --

        //field variables - within a class scope  and accessible to any method

        int sampleFieldInt = 5;
        static int sampleStaticInt = 6;
        // readonly can be reassign once and only on the constructor method
        readonly long sampleLong;
        readonly long sampleLong2 = 10;

        // need an initial value and cannot be modified anywhere
        const int sampleIntNaConst = 150;
        const float mathPI = 3.14F;

        #endregion

        public EpisodeClass()
        {
            sampleLong = 500;
            sampleLong2 = 100;
        }

        public void SampleMethod1()
        {
            int sampleLocalInt = 1;
            var sampleLocalDouble = 1.5;
            sampleFieldInt = 0;
            sampleStaticInt = 0;
        }

        public void SampleMethod2()
        {
            int sample2Int = 1;
            sampleFieldInt = 0;
            sampleStaticInt = 0;
        }

        public static void SampleStaticMethod()
        {
            //sampleFieldInt = 0;
            sampleStaticInt = 0;
        }
    }
}