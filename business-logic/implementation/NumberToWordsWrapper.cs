using System;

namespace business_logic
{
    public class NumberToWordsWrapper
    {
        // PROGRAM HANDLES NEGATIVE AND POSITIVE DOUBLES
        public static string ConvertNumToWords(double n)
        {
            string words = "";
            double intPart;
            double decPart = 0;

            if (n == 0)
                return "ZERO";

            try
            {
                string[] splitter = n.ToString().Split('.');
                intPart = double.Parse(splitter[0]);
                decPart = double.Parse(splitter[1]);

                int counter = splitter[1].Length;

                if (counter == 1)
                {
                    string decPartString = int.Parse(decPart.ToString()).ToString() + "0";
                    decPart = double.Parse(decPartString);
                }
            }
            catch
            {
                intPart = n;
            }

            words = NumWords(intPart);

            if (decPart > 0)
            {
                if (words != "")
                {
                    words += intPart > 1 ? " PESOS AND " : " PESO AND ";
                }

                words += NumWords(decPart);
                words += decPart > 01 ? " CENTAVOS ONLY" : " CENTAVO ONLY";
            }
            else
            {
                words += intPart > 1 ? " PESOS ONLY" : " PESO ONLY";
            }

            return words;
        }

        public static string NumWords(double n) //converts double to words
        {
            string[] numbersArr = new string[] { "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            string[] tensArr = new string[] { "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
            string[] suffixesArr = new string[] { "THOUSAND", "MILLION", "BILLION", "TRILLION", "QUADRILLION", "QUINTILLION", "SEXTILLION", "SEPTILLION", "OCTILLION", "NONILLION", "DECILLION", "UNDECILLION", "DUODECILLION", "TREDECILLION", "QUATTUORDECILLION", "QUINDECILLION", "SEXDECILLION", "SEPTEN-DECILLION", "OCTODECILLION", "NOVEMDECILLION", "VIGINTILLION" };
            string words = "";

            bool tens = false;

            if (n < 0)
            {
                words += "NEGATIVE ";
                n *= -1;
            }

            int power = (suffixesArr.Length + 1) * 3;

            while (power > 3)
            {
                double pow = Math.Pow(10, power);

                if (n >= pow)
                {
                    if (n % pow > 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1] + " ";
                    }
                    else if (n % pow == 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1];
                    }

                    n %= pow;
                }

                power -= 3;
            }

            if (n >= 1000)
            {
                if (n % 1000 > 0) words += NumWords(Math.Floor(n / 1000)) + " THOUSAND ";
                else words += NumWords(Math.Floor(n / 1000)) + " THOUSAND";
                n %= 1000;
            }

            if (0 <= n && n <= 999)
            {
                if ((int)n / 100 > 0)
                {
                    words += NumWords(Math.Floor(n / 100)) + " HUNDRED";
                    n %= 100;
                }

                if ((int)n / 10 > 1)
                {
                    if (words != "")
                        words += " ";
                    words += tensArr[(int)n / 10 - 2];
                    tens = true;
                    n %= 10;
                }

                if (n < 20 && n > 0)
                {
                    if (words != "" && tens == false)
                        words += " ";
                    words += (tens ? " " + numbersArr[(int)n - 1] : numbersArr[(int)n - 1]);
                    n -= Math.Floor(n);
                }
            }

            return words;
        }
    }
}
