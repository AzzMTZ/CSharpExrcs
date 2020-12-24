using System;
using System.Collections.Generic;

namespace CSharpBasics
{

    /*
     * General comments:
     * 1. Too many magic numbers. Use constants which explains what use of those numbers
     * 2. Leave an empty line between each function and before logical oporators
     * 3. Use better vairable names
     */
    public class Program // Change to "public class Program"
    {
        private const int TRIPLES_NO_LIMIT = -1;

        public static void Main(string[] args) // Change to "public static void Main(string[] args)"
        {
            Exrc1();
            Exrc2(240);
            Exrc2(12);
            Exrc2(2000);
            Exrc3(new string[] { "Basmach", "Empire", "Basmach", "RZA", "Empire", "Basmach", "RZA", "Respect" });// Nice varible values so much better then the original :)
            Console.WriteLine(ExrcBonus());
        }

        public static void Exrc1()// Notice that Exrc1 and Exrc2 are the same function, instead of copying your code just call from one function to the other one
        {
            Exrc2(1000, 1);
        }

        public static void Exrc2(int sumOfSides, int pythagorianTriplesLimit = TRIPLES_NO_LIMIT)
        {
            for (int firstSide = 1; firstSide < sumOfSides / 3 && pythagorianTriplesLimit != 0; firstSide++)
            {
                for (int secondSide = firstSide + 1; secondSide <= (sumOfSides - firstSide) / 2 && pythagorianTriplesLimit != 0; secondSide++)
                {
                    int hypotenuse = sumOfSides - firstSide - secondSide;
                    double sumOfSquaredTwoSides = Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2);

                    if (sumOfSquaredTwoSides == Math.Pow(hypotenuse, 2))// I would have put i * i + j * j and Math.Pow(1000 - i - j, 2) in vairables just to explain the meaning of this condition better
                    {
                        Console.WriteLine($"{firstSide},{secondSide},{hypotenuse}");

                        if (pythagorianTriplesLimit > 0)
                        {
                            pythagorianTriplesLimit--;
                        }
                        // If you are only using this one break its only going to leave the inner for statment which means it will continue the loop in the outer loop statment.
                    }
                }
            }
        }

        public static void Exrc3(string[] strings)
        {
            Dictionary<string, int> stringAppearances = new Dictionary<string, int>();

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

            foreach (KeyValuePair<string, int> currString in stringAppearances)
            {
                Console.WriteLine("{0},{1}", currString.Key, currString.Value);
            }
        }

        public static int ExrcBonus()/* Each string here could be in a string array with a name that explains its purpse, 
                                      * for expmaple ["one", "two"...]. Read about join method.
                                      * In addition if you use arrays and vaiables you can switch the multipication with the array length,
                                      * for exanple instead of "* 9" you can use "* arrayVariable.length"
                                      */
        {
            const int LAST_DIGITS_APPEARANCES = 9,/*I am not sure if it's better to use the length of oneToNineNames
                                              instead of this constant, since it has a different meaning 
                                              than the array's length*/
                SECOND_LAST_DIGITS_APPEARANCES = 10;

            string[] oneToNineNames = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
            tenToTwelveNames = { "ten", "eleven", "twelve" },
            thirteenToNineteenNames = { "thir", "four", "fif", "six", "seven", "eigh", "nine" },
            twentyToNinetyNames = { "twen", "thir", "for", "fif", "six", "seven", "eigh", "nine" };

            return (string.Join("", oneToNineNames).Length * LAST_DIGITS_APPEARANCES) +
                   string.Join("", tenToTwelveNames).Length +
                   string.Join("", thirteenToNineteenNames).Length + "teen".Length * thirteenToNineteenNames.Length +
                   ((string.Join("", twentyToNinetyNames).Length + "ty".Length * twentyToNinetyNames.Length) * SECOND_LAST_DIGITS_APPEARANCES);
        }
    }
}