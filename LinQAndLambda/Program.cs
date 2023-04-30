using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQAndLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            #region -- First Sample --

            Console.WriteLine("First Sample");
            Console.WriteLine();
            // Print even numbers onlu
            var numbers = new[] { 5, 6, 2, 9, 1 };

            //Using loop If-else

            Console.WriteLine("====================");
            Console.WriteLine("Loop and If-Else");
            Console.WriteLine("====================");
            var evenNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            foreach (var even in evenNumbers)
                Console.WriteLine(even);

            Console.WriteLine("====================");
            Console.WriteLine("LINQ");
            Console.WriteLine("====================");
            // Using LinQ
            var linqEvenNumbers = from number in numbers where number % 2 == 0 select number;
            foreach (var even in linqEvenNumbers)
                Console.WriteLine(even);

            Console.WriteLine("====================");
            Console.WriteLine("Lambda");
            Console.WriteLine("====================");
            var lambdaEvenNumbers = numbers.Where(number => number % 2 == 0);
            foreach (var even in lambdaEvenNumbers)
                Console.WriteLine(even);

            #endregion

            #region -- With Order and Transformation of data --

            Console.WriteLine();
            Console.WriteLine("With Order and Transformation of data");
            Console.WriteLine();
            // Print only those numbers less than 9

            // Linq
            var mixedNumbers = new[] { 3, 5, 6, 9 };

            Console.WriteLine("====================");
            Console.WriteLine("LINQ");
            Console.WriteLine("====================");
            var linqQuery = from number in mixedNumbers
                            where number < 9
                            orderby number descending
                            select $"numero: {number}";
            foreach (var num in linqQuery)
                Console.WriteLine(num);

            // Lambda
            Console.WriteLine("====================");
            Console.WriteLine("Lambda");
            Console.WriteLine("====================");
            var lambdaQuery = mixedNumbers
                .Where(number => number < 9)
                .OrderByDescending(number => number)
                .Select(number => $"number: {number}");
            foreach (var num in lambdaQuery)
                Console.WriteLine(num);

            #endregion

            #region -- JOINS --

            Console.WriteLine();
            Console.WriteLine("JOINS");
            Console.WriteLine();
            var students = new List<Student>()
            {
                new Student() { Name = "jowe", Age = 32, Grade = 1 },
                new Student() { Name = "fred", Age = 24, Grade = 3 },
                new Student() { Name = "john", Age = 30, Grade = 1 }
            };
            var sections = new List<Section>()
            {
                new Section() { Grade = 1, SectionName = "Section Cutie"},
                new Section() { Grade = 1, SectionName = "Section Medyo Cutie"}
            };

            Console.WriteLine("====================");
            Console.WriteLine("LINQ");
            Console.WriteLine("====================");
            var query = from section in sections
                        join student in students on section.Grade equals student.Grade
                        where student.Age > 20
                        orderby student.Age, student.Grade
                        select new
                        {
                            section.SectionName,
                            StudentName = student.Name
                        };
            foreach (var sectionAndStudent in query)
                Console.WriteLine($"Section {sectionAndStudent.SectionName}, Student Name: {sectionAndStudent.StudentName}");


            Console.WriteLine("====================");
            Console.WriteLine("Lambda");
            Console.WriteLine("====================");
            var lambdaQueryTwo= sections
                                .Join( // has four parameters
                                    students.Where(student => student.Age > 20), // 1. enumerable parameter
                                    section => section.Grade, // 2. paramater from the current object to compare to other object
                                    student => student.Grade, // 3. parameter from the other object to compare to the current object
                                    (section, student) => new // 4. select or callback parameter
                                    {
                                        section.SectionName,
                                        StudentName = student.Name, // StudentName is an Anonymous variable
                                        student.Age,
                                        student.Grade
                                    }
                                    ).OrderBy(student => student.Age) // sort by and ascending
                                    .ThenBy(student => student.Grade); // then sort again and ascending
            foreach (var sectionAndStudent in lambdaQueryTwo)
                Console.WriteLine($"Section {sectionAndStudent.SectionName}, Student Name {sectionAndStudent.StudentName}");

            #endregion

            #region -- GROUPING --

            Console.WriteLine();
            Console.WriteLine("GROUPING");
            Console.WriteLine();
            var groupingStudents = new List<Student>()
            {
                new Student() { Name = "jowe", Age = 32, Grade = 1 },
                new Student() { Name = "fred", Age = 24, Grade = 3 },
                new Student() { Name = "john", Age = 30, Grade = 1 }
            };

            Console.WriteLine("====================");
            Console.WriteLine("LINQ");
            Console.WriteLine("====================");
            var groupingQuery = from student in students
                                group student by student.Grade into gradeGroup
                                select new GradeCount { Grade = gradeGroup.Key, StudentCount = gradeGroup.Count() }; // Strongly Typed
            foreach (var gradeCount in groupingQuery)
                Console.WriteLine($"Grade: {gradeCount.Grade}, Count: {gradeCount.StudentCount}");


            Console.WriteLine("====================");
            Console.WriteLine("Lambda");
            Console.WriteLine("====================");
            var groupingQueryLambda = students.GroupBy(student => student.Grade, student => student) // GroupBy as two parameters, (1. Key - for grouping, 2. Content enumerable)
                .Select(groupCount =>
                new GradeCount // Strongly Type
                {
                    Grade = groupCount.Key,
                    StudentCount = groupCount.Count()
                });
            foreach (var gradeCount in groupingQueryLambda)
                Console.WriteLine($"Grade: {gradeCount.Grade}, Count: {gradeCount.StudentCount}");


            #endregion

            #region -- Lambda Only - Aggregation --


            Console.WriteLine();
            Console.WriteLine("Lambda Only Functions");
            Console.WriteLine();
            var newNumbers = Enumerable.Range(1, 10); // Equivalent to  { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
            Console.WriteLine(string.Join(",", newNumbers));

            // Average
            var average = newNumbers.Average();
            var num1To5Average = newNumbers.Where(n => n <= 5).Average();
            Console.WriteLine($"Average: {average}, Average 1 to 5: {num1To5Average}");

            // Count or Long Count, use Long Count when expected count is more than int capacity
            var count = newNumbers.Count();

            // Max and Min
            var maxNumber = newNumbers.Max();
            var minNumber = newNumbers.Min();

            // Sum
            var summation = newNumbers.Sum();

            Console.WriteLine($"Count: {count}, Max: {maxNumber}, Min: {minNumber}, SUm: {summation}");


            #endregion

            #region -- Lambda Only - Conversion --

            var conversionList = new List<int>(newNumbers);
            var enumValue = conversionList.AsEnumerable(); // converted to enumerable
            var backToList = enumValue.ToList(); // converted back to list

            conversionList = (from number in newNumbers where number >= 5 select number).ToList();

            #endregion

            #region -- Lambda Only - Element Access --

            var firstNumber = newNumbers.FirstOrDefault(); // if empty enumerable default 0, else will get the first item/element
            var lastNumber = newNumbers.LastOrDefault(); // will get the first item/element

            var firstEvenNumber = newNumbers.FirstOrDefault(n => n % 2 == 0); // can add callback func tion

            var firstWithoutDefault = newNumbers.First(); // if empty, will throw error exceptions
            var lastWithoutDefault = newNumbers.Last(); // if empty, will throw error exceptions


            #endregion

            #region -- Lambda Only - Partioning --

            Console.WriteLine();
            var numberSkip5 = newNumbers.Skip(5);
            var numberSkipWhile = newNumbers.SkipWhile(n => n < 5);

            var numberTakes5 = newNumbers.Take(5);
            var numberTakeWhile = newNumbers.TakeWhile(n => n < 5);

            Console.WriteLine($"Skip5: {string.Join(",", numberSkip5)}");
            Console.WriteLine($"SkipWhile: {string.Join(",", numberSkipWhile)}");
            Console.WriteLine($"Take5: {string.Join(",", numberTakes5)}");
            Console.WriteLine($"TakeWhile: {string.Join(",", numberTakeWhile)}");

            #endregion

            #region -- Lambda Only - Set --

            Console.WriteLine();
            var repeatedNumbers = new[] { 1, 2, 3, 1, 5, 1, 1, 2 };
            var distinctNumbers = repeatedNumbers.Distinct();

            Console.WriteLine($"Distinct: {string.Join(",", distinctNumbers)}");

            var excludeNumbers = new[] { 5, 6, 7 };
            var newNumbersSet = newNumbers.Except(excludeNumbers);
            Console.WriteLine($"Exclude: {string.Join(",", newNumbersSet)}");

            var checkerNumber = new int[] { 1, 9, 10, 11, 12 };
            var intersectionNumbers = newNumbers.Intersect(checkerNumber);
            Console.WriteLine($"Intersect: {string.Join(",", intersectionNumbers)}");

            var appendNumbers = new[] { 10, 11, 12, 13 };
            var unionNumbers = newNumbers.Union(appendNumbers);
            Console.WriteLine($"Union: {string.Join(",", unionNumbers)}");

            #endregion
        }
    }

    #region -- For Demo Only --

    public class Student
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }

    public class Section
    {
        public string? SectionName { get; set; }
        public int Grade { get; set; }
    }

    public class GradeCount
    {
        public int Grade { get; set; }
        public int StudentCount { get; set; }
    }

    #endregion
}

