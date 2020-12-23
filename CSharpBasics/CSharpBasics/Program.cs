using System;
using System.Collections.Generic;

namespace CSharpBasics
{
    class Program
    {
       
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                Exrc1();
                Exrc2(12);
                Exrc3(new string[] { "hi", "bye", "hi" });
                Console.WriteLine(ExrcBonus());
            }
            public static void Exrc1()
            {
                for (int i = 1; i < 333; i++)
                {
                    for (int j = i + 1; j <= (1000 - i) / 2; j++)
                    {
                        if (i * i + j * j == Math.Pow(1000 - i - j, 2))
                        {
                            Console.WriteLine($"{i},{j},{1000 - i - j}");
                            break;
                        }
                    }
                }
            }
            public static void Exrc2(int sum)
            {
                for (int i = 1; i < sum / 3; i++)
                {
                    for (int j = i + 1; j <= (sum - i) / 2; j++)
                    {
                        if (i * i + j * j == Math.Pow(sum - i - j, 2))
                        {
                            Console.WriteLine($"{i}\n{j}\n{sum - i - j}");
                        }
                    }
                }
            }
            public static void Exrc3(string[] strings)
            {
                var stringAppearances = new Dictionary<string, int>();
                foreach (string currString in strings)
                {
                    if (stringAppearances.ContainsKey(currString))
                    {
                        stringAppearances[currString] += 1;
                    }
                    else
                    {
                        stringAppearances[currString] = 1;
                    }
                }
                foreach (KeyValuePair<string, int> item in stringAppearances)
                {
                    Console.WriteLine("{0},{1}", item.Key, item.Value);
                }
            }
            public static int ExrcBonus()
            {
                return
                    "onetwothreefourfivesixseveneightnine".Length * 9 +
                    "teneleventwelvethirfourfifsixseveneighnine".Length + "teen".Length * 7 +
                     10 * ("twenthirforfifsixseveneighnine".Length + "ty".Length * 8);
            }
        }
    }
