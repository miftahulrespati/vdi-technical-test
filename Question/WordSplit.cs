using System;

namespace VDITechnicalTest.Question
{
    public class WordSplit
    {
        public void DoOperation()
        {
            Console.WriteLine("\nQuestion 1");

            do
            {
                Console.Write("Input your word: ");
                string input = Console.ReadLine() ?? "";

                if (input.Equals("quit"))
                {
                    Console.WriteLine("Thank you!");
                    break;
                }

                int half = input.Length / 2;
                string mid = "";
                if (input.Length % 2 != 0)
                {
                    mid = input[half].ToString();
                    half++;
                }

                string start = input.Substring(0, input.Length / 2);
                string end = input.Substring(half, input.Length / 2);

                start = Reverse(start);
                end = Reverse(end);

                Console.WriteLine($"Result: {start + mid + end}\n");

            } while (true);
        }

        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}