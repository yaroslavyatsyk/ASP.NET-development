using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names1 = new string[] { "apple", "banana"};
            string[] names2 = new string[] { "Kivi", "apple", "banana" };

            string[] mergedNames = names1.Concat(names2).Distinct().ToArray();

            
            foreach(string name in mergedNames)
            {
                Console.WriteLine(name);
            }
           
        }
    }
}
