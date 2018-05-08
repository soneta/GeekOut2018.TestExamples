using System;
using System.Linq;

namespace GeekOut2018.TestExamples
{
    public class PeselValidator
    {
        public bool Validate(string pesel)
        {
            var result = false;
            try
            {
                if (pesel.Length == 11)
                {
                    result = CheckSum(pesel).Equals(pesel[10].ToString());
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        private static readonly int[] Multipliers = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        private static string CheckSum(string pesel)
        {
            var sum = Multipliers.Select((t, i) => t * int.Parse(pesel[i].ToString())).Sum();
            var remainder = sum % 10;
            return remainder == 0 ? remainder.ToString() : (10 - remainder).ToString();
        }
    }
}
