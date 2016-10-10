using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IamNumberFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number;
            bool isValid;

            do
            {
                Console.Write("Enter a number : ");
                input = Console.ReadLine();
                isValid = int.TryParse(input, out number);
                if (!isValid)
                    Console.WriteLine("\n  Not an integer, please try again\n");
                else                    
                    Console.WriteLine("\n  {0}\n", Result(number));
            }

            while (!(isValid && number == 0));
            Console.WriteLine("\nProgram ended");
        }

        public static string NumberToText(int number)
        {
            if (number == 0) return "Zero";
            string and = "";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] words1 = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] words2 = { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] words3 = { "Thousand", "Million", "Billion" };
            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        public static string Result(int a)
        {
            string spellednum = NumberToText(a);
            int b = spellednum.Length;

            Console.WriteLine(a + " is " + b);

            while (b != 4)
            {
                spellednum = NumberToText(b);
                a = spellednum.Length;

                Console.WriteLine(b + " is " + a);

                spellednum = NumberToText(a);
                b = spellednum.Length;

                if (a != 4)
                {
                    Console.WriteLine(a + " is " + b);
                }

            }

            if (b == b)
            {
                Console.WriteLine(b + " is " + b);

                Console.WriteLine("I AM NUMBER FOUR");
            }


            return "";
        }
       
    }
}
