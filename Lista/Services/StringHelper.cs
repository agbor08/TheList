using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Lista.Services
{
    public class StringHelper
    {
        public static String RemoveDiacritics(String s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        public static string ReplaceAllDecimalToHex(string str)
        {
            StringBuilder convertedResult = new StringBuilder();

            Match match;
            while (Regex.Match(str, @"\d+").Success)
            {
                match = Regex.Match(str, @"\d+");
                convertedResult.Append(str, 0, match.Index);

                string num = match.Value;
                int intnum = int.Parse(num);
                string hex = String.Format("#{0:X2}", intnum);

                convertedResult.Append(hex, 0, hex.Length);

                str = str.Remove(0, match.Index + match.Length);
            }
            convertedResult.Append(str);
            return str = convertedResult.ToString();
        }
    }
}