using System;
using System.Collections.Generic;

namespace CSharpBasics
{

    public class Program
    {
        private const int TRIPLES_NO_LIMIT = -1;
        private static readonly string[] ONE_TO_NINE = { "one", "two", "three", "four", "five",
                                                            "six", "seven", "eight", "nine" },
                                         TEN_TO_TWELVE = { "ten", "eleven", "twelve" },
                                         THIRTEEN_TO_NINETEEN = { "thir", "four", "fif", "six",
                                                                     "seven", "eigh", "nine" },
                                         TWENTY_TO_NINETY = { "twen", "thir", "for", "fif",
                                                                 "six", "seven", "eigh", "nine" };

        public static void Main(string[] args)
        {
            Exrc1();
            Exrc2(240);
            Exrc2(12);
            Exrc2(2000);
            Exrc3(new string[] { "Basmach", "Empire", "Basmach", "RZA", "Empire", "Basmach", "RZA", "Respect" });
            Console.WriteLine(ExrcBonus());
        }

        public static void Exrc1()
        {
            Exrc2(1000, 1);
        }

        public static void Exrc2(int sumOfSides, int pythagorianTriplesLimit = TRIPLES_NO_LIMIT)
        {
            for (int firstSide = 1;
                firstSide < sumOfSides / 3 && pythagorianTriplesLimit != 0;
                firstSide++)
            {
                for (int secondSide = firstSide + 1;
                    secondSide <= (sumOfSides - firstSide) / 2 && pythagorianTriplesLimit != 0;
                    secondSide++)
                {
                    int hypotenuse = sumOfSides - firstSide - secondSide;
                    double sumOfSquaredTwoSides = Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2);

                    if (sumOfSquaredTwoSides == Math.Pow(hypotenuse, 2))
                    {
                        Console.WriteLine($"{firstSide},{secondSide},{hypotenuse}");

                        if (pythagorianTriplesLimit > 0)
                        {
                            pythagorianTriplesLimit--;
                        }
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

        public static int ExrcBonus()
        {
            return getNumLettersOfLastDigits() + 
                   getNumLettersOfTenToNineteen() + 
                   getNumLettersOfSecondLastDigits();
        }

        private static int getNumLettersOfLastDigits()
        {
            const int LAST_DIGITS_APPEARANCES = 9;

            return string.Join("", ONE_TO_NINE).Length * LAST_DIGITS_APPEARANCES;
        }

        private static int getNumLettersOfTenToNineteen()
        {
            return string.Join("", TEN_TO_TWELVE).Length +
                   string.Join("", THIRTEEN_TO_NINETEEN).Length +
                   ("teen".Length * THIRTEEN_TO_NINETEEN.Length);
        }

        private static int getNumLettersOfSecondLastDigits()
        {
            const int SECOND_LAST_DIGITS_APPEARANCES = 10;

            return (string.Join("", TWENTY_TO_NINETY).Length + "ty".Length * TWENTY_TO_NINETY.Length) * 
                   SECOND_LAST_DIGITS_APPEARANCES;
        }
    }
}