using System;

namespace IntegerToEnglishWords
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int One = 1;
            const int Ten = 10;
            const int Twenty = 20;
            const int Hundred = 100;
            const int OneThousand = 1_000;
            const int OneMillion = 1_000_000;
            const int OneBillion = 1_000_000_000;


            var o = new SolutionFoundOnline();
            Console.WriteLine(o.NumberToWords(532));
            Console.ReadKey();
        }
    }

    public class SolutionFoundOnline
    {
        private readonly string[] belowTen =
            {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};

        private readonly string[] belowTwenty =
        {
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private readonly string[] belowHundred =
            {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};

        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            return Helper(num);
        }

        private string Helper(int num)
        {
            if (num < 10) return belowTen[num];
            if (num < 20) return belowTwenty[num % 10];
            if (num < 100) return $"{belowHundred[num / 10]} {belowTen[num % 10]}".Trim();
            if (num < 1000) return $"{Helper(num / 100)} Hundred {Helper(num % 100)}".Trim();
            if (num < 1000000) return $"{Helper(num / 1000)} Thousand {Helper(num % 1000)}".Trim();
            if (num < 1_000_000_000) return $"{Helper(num / 1_000_000)} Million {Helper(num % 1000000)}".Trim();

            return $"{Helper(num / 1000000000)} Billion {Helper(num % 1000000000)}".Trim();
        }
    }

    public class Solution
    {
        private const int ONE_HUNDRED = 1_00;
        private const int ONE_THOUSAND = 1_000;
        private const int ONE_MILLION = 1_000_000;
        private const int ONE_BILLION = 1_000_000_000;

        private readonly string[] belowTen =
            {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};

        private readonly string[] belowTwenty =
        {
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private readonly string[] belowHundred =
            {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};

        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            return NumberToWordsRecursive(num);
        }

        private string NumberToWordsRecursive(int num)
        {
            if (num < 10) return this.belowTen[num];
            if (num < 20) return this.belowTwenty[num % 10];
            if (num < 100) return $"{this.belowHundred[num / 10]} {this.belowTen[num % 10]}".Trim();
            if (num < 1_000) return $"{NumberToWordsRecursive(num / 100)} Hundred {NumberToWordsRecursive(num % 100)}".Trim();
            if (num < 1_000_000) return $"{NumberToWordsRecursive(num / 1_000)} Thousand {NumberToWordsRecursive(num % 1_000)}".Trim();
            if (num < 1_000_000_000) return $"{NumberToWordsRecursive(num / ONE_MILLION)} Million {NumberToWordsRecursive(num % 1_000_000)}".Trim();

            return $"{NumberToWordsRecursive(num / ONE_BILLION)} Billion {NumberToWordsRecursive(num % ONE_BILLION)}".Trim();
        }
    }
}