using System;
using System.Collections.Generic;
using System.Linq;

namespace VDITechnicalTest.Question
{
    public class Anagram
    {
        public void DoOperation()
        {
            Console.WriteLine("\nQuestion 2");
            string input1;
            string input2;
            List<int> result = new();

            do
            {
                Console.Write("Input your first array of strings separated by comma(,): ");
                input1 = Console.ReadLine() ?? "";
                input1 = input1.Replace(" ", ""); // Remove all whitespaces even between characters
                if (input1.Any(char.IsUpper))
                {
                    Console.WriteLine("Only lowercase characters are allowed");
                    continue;
                }
                var arr1 = new List<string>(input1.Split(',').Select(s => s));

                if (input1.Equals("quit"))
                {
                    Console.WriteLine("Thank you!");
                    break;
                }

                Console.Write("Input your second array of strings separated by comma(,): ");
                input2 = Console.ReadLine() ?? "";
                input2 = input2.Replace(" ", ""); // Remove all whitespaces even between characters
                if (input2.Any(char.IsUpper))
                {
                    Console.WriteLine("Only lowercase characters are allowed");
                    continue;
                }
                var arr2 = new List<string>(input2.Split(',').Select(s => s));

                if (input2.Equals("quit"))
                {
                    Console.WriteLine("Thank you!");
                    break;
                }

                if (arr1.Count != arr2.Count)
                {
                    Console.WriteLine("Both arrays don't have the same number of elements");
                    Console.WriteLine($"First array has {arr1.Count} element(s), Second array has {arr2.Count} element(s)\n");
                    continue;
                }

                result.Clear();
                for (int i = 0; i < arr1.Count; i++)
                {
                    if (arr1[i].Length != arr2[i].Length)
                    {
                        result.Add(0);
                    }
                    else if (String.Concat(arr1[i].OrderBy(c => c)).Equals(String.Concat(arr2[i].OrderBy(c => c))))
                    {
                        result.Add(1);
                    }
                    else { result.Add(0); }
                }

                Console.WriteLine($"Result: {String.Join("", result)}\n");
            } while (true);
        }
    }
}