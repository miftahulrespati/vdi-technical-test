using System;
using System.Collections.Generic;
using System.Globalization;

namespace VDITechnicalTest
{
    public class ThirdQuestion
    {
        public void DoOperation()
        {
            Console.WriteLine("\nQuestion3");
            string input;
            string memberType = "";
            List<string> validType = new() { "platinum", "gold", "silver" };

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            do
            {
                int memberPoint = 0;
                int basePrice = 0;
                int disc = 0;
                int bonus = 0;
                bool isValid;

                Console.Write("Insert price: ");
                input = Console.ReadLine() ?? "";
                if (input.Equals("quit"))
                {
                    Console.WriteLine("Thank you!");
                    break;
                }
                isValid = int.TryParse(input, out basePrice);
                if (!isValid)
                {
                    Console.WriteLine("Price should be an integer\n");
                    continue;
                }

                Console.Write("Insert member type: ");
                input = Console.ReadLine() ?? "";
                if (input.Equals("quit"))
                {
                    Console.WriteLine("Thank you!");
                    break;
                }
                memberType = input ?? memberType;
                if (!validType.Contains(memberType) && !memberType.Equals(""))
                {
                    Console.WriteLine("Invalid member type");
                    Console.WriteLine("Valid member types are: " + String.Join(", ", validType));
                    Console.WriteLine("Or leave them blank if not member\n");
                    continue;
                }

                if (!memberType.Equals(""))
                {
                    Console.Write("Insert member point: ");
                    input = Console.ReadLine() ?? "";
                    if (input.Equals("quit"))
                    {
                        Console.WriteLine("Thank you!");
                        break;
                    }
                    isValid = int.TryParse(input, out memberPoint);
                    if (!isValid)
                    {
                        Console.WriteLine("Member point should be an integer\n");
                        continue;
                    }
                }

                if (memberType.Equals("platinum"))
                {
                    disc = 50;
                    if (memberPoint >= 100 && memberPoint <= 300)
                    {
                        bonus = 35;
                    }
                    else if (memberPoint >= 301 && memberPoint <= 500)
                    {
                        bonus = 50;
                    }
                    else if (memberPoint > 500)
                    {
                        bonus = 68;
                    }
                }
                else if (memberType.Equals("gold"))
                {
                    disc = 25;
                    if (memberPoint >= 100 && memberPoint <= 300)
                    {
                        bonus = 25;
                    }
                    else if (memberPoint >= 301 && memberPoint <= 500)
                    {
                        bonus = 34;
                    }
                    else if (memberPoint > 500)
                    {
                        bonus = 52;
                    }
                }
                else if (memberType.Equals("silver"))
                {
                    disc = 10;
                    if (memberPoint >= 100 && memberPoint <= 300)
                    {
                        bonus = 12;
                    }
                    else if (memberPoint >= 301 && memberPoint <= 500)
                    {
                        bonus = 27;
                    }
                    else if (memberPoint > 500)
                    {
                        bonus = 39;
                    }
                }

                float totalDisc = (basePrice * ((float)disc / 100)) + bonus;
                float totalPrice = basePrice - totalDisc;

                Console.WriteLine("MEMBER: " + memberType);
                Console.WriteLine("POINT: " + memberPoint);
                Console.WriteLine($"Total discount is {totalDisc}, and total price is {totalPrice}\n");

                var db = new DBConn();
                db.NewTransaction(basePrice.ToString(), memberType, memberPoint, totalDisc.ToString(), totalPrice.ToString());

            } while (true);
        }
    }
}