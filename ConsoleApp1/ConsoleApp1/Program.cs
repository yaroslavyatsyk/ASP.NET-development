using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };

            string[] mergedNames = new string[names1.Length + names2.Length];

            int i = 0;
            int j = 0;
            int k = 0;

            while(i < names1.Length && j < names2.Length)
            {
                if(names1[i] != names2[j])
                {
                    mergedNames[k] = names1[i];
                    i++;
                   
                }
                else if(names2[j] != names1[i])
                {
                    mergedNames[k] = names2[j];
                    j++;
                }
                k++;
            }

            foreach(var name in mergedNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
