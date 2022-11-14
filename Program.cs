using System;

namespace VDITechnicalTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to VDI Technical Test Console App by Miftahul Respati");
            Console.WriteLine("Type 'quit' to exit app \n");

            do
            {
            START:
                Console.Write("Select question: ");
                string input;
                int question;
                bool isValid = true;

                input = Console.ReadLine() ?? "";
                isValid = int.TryParse(input, out question);

                if (input.Equals("quit"))
                {
                    Console.WriteLine("Thank you!");
                    break;
                }

                if (!isValid)
                {
                    Console.WriteLine("Question number have to be a number \n");
                    continue;
                }

                switch (question)
                {
                    case 1:
                        var q1 = new FirstQuestion();
                        q1.DoOperation();
                        break;

                    case 2:
                        var q2 = new SecondQuestion();
                        q2.DoOperation();
                        break;

                    case 3:
                        var db = new DBConn();
                        db.CreateTable();

                        var q3 = new ThirdQuestion();
                        q3.DoOperation();
                        break;

                    default:
                        Console.WriteLine("There are only questions number 1, 2, and 3 \n");
                        goto START;
                }
                return;
            } while (true);
        }
    }
}