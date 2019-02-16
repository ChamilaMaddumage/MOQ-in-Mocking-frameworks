using System;

namespace Numbers.Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var numbers = "30,2,4,55,21";
                IFileManager fileManager = new FileManager();
                SortManager sortManager = new SortManager(fileManager);

                var sortedNumbers = sortManager.Sort("inputNumbers.csv");

                Console.WriteLine("Sorted Numbers are ......");
                foreach (var number in sortedNumbers)
                {
                    Console.WriteLine(number);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured,Failed to sort numbers");
                Console.WriteLine(e);
            }
        }
    }
}
