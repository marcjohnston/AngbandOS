using System;
using System.Collections.Generic;
using System.Text;

namespace AngbandOS.Core
{
    public static class StringLibrary
    {
        public static string SuffixIf(string? value, string suffix) => String.IsNullOrEmpty(value) ? "" : $"{value}{suffix}";
        public static string DelimitIf(string? prefix, string delimiter, string? suffix) => String.IsNullOrEmpty(prefix) || String.IsNullOrEmpty(suffix) ? $"{prefix}{suffix}" : $"{prefix}{delimiter}{suffix}";
        public static string DelimitIf(string? prefix, char delimiter, char? suffix) => String.IsNullOrEmpty(prefix) || suffix is null ? $"{prefix}{suffix}" : $"{prefix}{delimiter}{suffix}";
        public static string DelimitIf(string? prefix, char delimiter, string? suffix) => String.IsNullOrEmpty(prefix) || String.IsNullOrEmpty(suffix) ? $"{prefix}{suffix}" : $"{prefix}{delimiter}{suffix}";

        /// <summary>
        /// Returns whether or not a character is a vowel.
        /// </summary>
        /// <param name="ch"> The character </param>
        /// <returns> Whether or not the character is a vowel </returns>
        public static bool IsVowel(this char ch)
        {
            switch (ch)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                case 'A':
                case 'E':
                case 'I':
                case 'O':
                case 'U':
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Pads a string in both directions to center the original
        /// </summary>
        /// <param name="source"> The original string </param>
        /// <param name="totalWidth"> The total width of the padded string </param>
        /// <param name="paddingChar"> The character with which to pad the string </param>
        /// <returns> The padded string </returns>
        public static string PadCenter(this string source, int totalWidth, char paddingChar = ' ')
        {
            int spaces = totalWidth - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft, paddingChar).PadRight(totalWidth, paddingChar);
        }

        /// <summary>
        /// Converts an integer to a Roman numeral
        /// </summary>
        /// <param name="number"> The number to convert </param>
        /// <param name="forGeneration"> True if the number is the generation of a character </param>
        /// <returns> The number as a Roman numeral </returns>
        public static string ToRoman(this int number)
        {
            Dictionary<int, string> NumberRomanDictionary = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };


            // Roman numerals are not positional, so simply start with the highest number and keep
            // appending and subtracting until we can't
            StringBuilder roman = new StringBuilder();
            foreach (KeyValuePair<int, string> item in NumberRomanDictionary)
            {
                while (number >= item.Key)
                {
                    roman.Append(item.Value);
                    number -= item.Key;
                }
            }

            return roman.ToString();
        }

        /// <summary>
        /// Returns a value (converted to a string) with a leading positive or negative symbol depending on the value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetSignedValue(int value)
        {
            if (value >= 0)
            {
                // Positive values will not render with a plus-symbol.  We need to manually add one.
                return $"+{value}";
            }
            else
            {
                // Negative values will automatically have the negative value rendered.  We do not need to manually add it.
                return $"{value}";
            }
        }
    }
}
