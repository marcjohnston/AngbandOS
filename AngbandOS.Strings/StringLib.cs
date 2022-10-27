using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AngbandOS.Strings
{
    public static class StringLib
    {
        /// <summary>
        /// Returns true if all string value are not empty or nothing.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool AllHaveValue(params string[] values)
        {
            for (int i = 0, loopTo = Information.UBound(values); i <= loopTo; i++)
            {
                if (string.IsNullOrEmpty(values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true if any string value is not empty or nothing.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool AnyHasValue(params string[] values)
        {
            for (int i = 0, loopTo = Information.UBound(values); i <= loopTo; i++)
            {
                if (!string.IsNullOrEmpty(values[i]))
                {
                    return true;
                }
            }
            return false;
        }

        ///// <summary>
        ///// Returns a concatenation of all path segments with one and only one separator between each path segment.
        ///// </summary>
        ///// <param name="separator">The separator to use between each segment of the path.  \ or / are commonly used.</param>
        ///// <param name="ensureLeading">Set to TRUE, to ensure there is a separator at the beginning of the path.</param>
        ///// <param name="ensureTrailing">Set to TRUE, to ensure there is a separator at the end of the path.</param>
        ///// <param name="pathSegments">The list of segments to concatenate.  Leading and trailing separators are ignored.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public static string BuildPath(string separator, bool ensureLeading, bool ensureTrailing, params string[] pathSegments)
        //{
        //    string path = string.Empty;

        //    if (ensureLeading)
        //    {
        //        path = path + separator;
        //    }
        //    foreach (string segment in pathSegments)
        //    {
        //        // Strip all preceeding and trailing separators from the path segment.
        //        while ((segment.Substring(0, 1) ?? "") == (separator ?? ""))
        //            segment = segment.Substring(2);
        //        while ((Microsoft.VisualBasic.Strings.Right(segment, 1) ?? "") == (separator ?? ""))
        //            segment = segment.Substring(segment.Length - 1);

        //        // Concatenate the segment into the path.
        //        path = DelimitIf(path, separator, segment);
        //    }
        //    if (ensureTrailing)
        //    {
        //        path = path + separator;
        //    }
        //    return path;
        //}

        ///// <summary>
        ///// Returns a path with a single backslash between each and every segment.  The returned path is guaranteed to have no leading or trailing backslash
        ///// </summary>
        ///// <param name="pathSegments"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public static string BuildPath(params string[] pathSegments)
        //{
        //    return BuildPath(@"\", false, false, pathSegments);
        //}

        /// <summary>
        /// Returns -1, 0 or 1 based on the result of a hybrid string and numeric comparison.  A numeric portion of the string at the beginning is used to determine the comparison.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int CompareLeadingNumeric(string s1, string s2)
        {
            var d1 = default(double);
            var d2 = default(double);

            if (TryParseLeadingDouble(s1, ref d1) && TryParseLeadingDouble(s2, ref d2))
            {
                if (d1 < d2)
                {
                    return -1;
                }
                else if (d1 > d2)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return string.Compare(s1, s2);
            }
        }

        /// <summary>
        /// Returns the concatenation of two strings with a delimiter between them, if both strings are non-empty.
        /// </summary>
        /// <param name="prefix">The first string to concatenate.</param>
        /// <param name="delimiter">A delimiter to place inbetween the two strings, in both of them are non-empty.</param>
        /// <param name="suffix">The second string to concatenate.</param>
        /// <returns>A string that represents [stringA] + [delimiter] + [stringB].</returns>
        public static string DelimitIf(string prefix, string delimiter, string suffix)
        {
            if (Microsoft.VisualBasic.Strings.Len(prefix) > 0 && Microsoft.VisualBasic.Strings.Len(suffix) > 0)
            {
                return prefix + delimiter + suffix;
            }
            else
            {
                return prefix + suffix;
            }
        }

        /// <summary>
        /// Returns the concatenation of a string copied a specific number of times.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Duplicate(string s, int count)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 1, loopTo = count; i <= loopTo; i++)
                stringBuilder.Append(s);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Concatenates a prefix and suffix string to a string value, if the string value is non-empty.
        /// </summary>
        /// <param name="prefix">The string to prefix the stringValue parameter with.</param>
        /// <param name="stringValue">The string to test and return.</param>
        /// <param name="suffix">The string to concatate as the prefix of stringValue, if stringValue is non-empty.</param>
        /// <returns>[stringValue] + [conditionalPrefixString]</returns>
        public static string EncapsulateIf(string prefix, string stringValue, string suffix)
        {
            return PrefixIf(prefix, SuffixIf(stringValue, suffix));
        }

        /// <summary>
        /// Returns a string enclosed in quotes, with the quote character doubled in the string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="quoteChar"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string EncapsulateInQuotes(string s, string quoteChar = "\"")
        {
            s = Microsoft.VisualBasic.Strings.Replace(s, quoteChar, quoteChar + quoteChar);
            return quoteChar + s + quoteChar;
        }

        /// <summary>
        /// Returns a string with a specific prefix.  The original string is returned if it already contains the prefix; otherwise the prefix is concatenated to it.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string EnsurePrefix(string prefix, string value)
        {
            if ((Microsoft.VisualBasic.Strings.Left(value, Microsoft.VisualBasic.Strings.Len(prefix)) ?? "") != (prefix ?? ""))
            {
                return prefix + value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns a string with a specific suffix.  The original string is returned if it already contains the suffix; otherwise the suffix is concatenated to it.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string EnsureSuffix(string value, string suffix)
        {
            if ((Microsoft.VisualBasic.Strings.Right(value, Microsoft.VisualBasic.Strings.Len(suffix)) ?? "") != (suffix ?? ""))
            {
                return value + suffix;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns a substring found within a another string.  A starting position, prefix and suffix can all be specified to identify the location of the text to extract.
        /// </summary>
        /// <param name="text">The source text from which the substring will be returned from.</param>
        /// <param name="startPosition">An integer position to start the search from.  If no starting position is specified, an index position of 1 (base 1) is used.</param>
        /// <param name="prefixText">A string that is used to identify the starting location for the text to return.  The starting position will be advanced to this search text.  If this prefix text is not found, nothing is returned.</param>
        /// <param name="suffixText">A string that is used to identify where the returned text is to stop.  If this suffix text is not specified, the remaining text in the string is returned.  If the suffix text is not found, nothing is returned.</param>
        /// <param name="nextPosition">Returns the character index position that follows after the suffix text.  If no suffix text was specified, Len(text) + 1 is returned.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ExtractText(string text, int? startPosition, string prefixText, string suffixText, [Optional, DefaultParameterValue(0)] ref int nextPosition)
        {
            string ExtractTextRet = default;
            // If there was no text supplied, return nothing.
            if (text == null)
            {
                nextPosition = 0;
                return null;
            }

            // First step is to compute the starting position for the searching process.  Check to see if a start position was specified.
            if (!startPosition.HasValue)
            {
                // No.  Use the beginning of the document.
                startPosition = 1;
            }

            // Now check to see if there is a prefix that we need to find.
            if (!string.IsNullOrEmpty(prefixText))
            {
                // Find the prefix text.
                startPosition = Microsoft.VisualBasic.Strings.InStr(startPosition.Value, text, prefixText);

                // Check to see if the text was found.
                if (0 is var arg2 && startPosition is { } arg1 && arg1 == arg2)
                {
                    // Return pos2 as the starting position and return nothing.
                    nextPosition = (int)startPosition;
                    return null;
                }
            }

            // Move the starting position forward to th appropriate position.
            startPosition += Microsoft.VisualBasic.Strings.Len(prefixText);

            // Initialize the ending position.
            nextPosition = Microsoft.VisualBasic.Strings.Len(text);

            // Check to see if there is a suffix to find.
            if (!(suffixText == null))
            {
                // Find the suffix text.
                nextPosition = Microsoft.VisualBasic.Strings.InStr(startPosition.Value, text, suffixText);
                if (nextPosition == 0)
                {
                    nextPosition = (int)startPosition;
                    return null;
                }
            }

            // Extract the text.
            ExtractTextRet = Microsoft.VisualBasic.Strings.Mid(text, (int)startPosition, (int)(nextPosition - startPosition));

            // Move the ending position.
            nextPosition += Microsoft.VisualBasic.Strings.Len(suffixText);
            return ExtractTextRet;
        }

        /// <summary>
        /// Returns a value instead of a value with no length.
        /// </summary>
        /// <param name="value">The value to test for nothing.</param>
        /// <param name="emptyValue">The value to return if, <paramref name="value" /> is blank.</param>
        /// <returns>The object <paramref name="emptyValue" />, if <paramref name="value" /> is nothing; otherwise <paramref name="value" />.</returns>
        public static object IfEmpty(string value, object emptyValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return emptyValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns True, if every character in a string is an alphabetic character (a-z, A-Z).
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns>TRUE, if every character in <paramref name="s" /> is a character between 'a' and 'z' or 'A' and 'Z'; FALSE otherwise.</returns>
        public static bool IsAlpha(string s)
        {
            for (int index = 1, loopTo = Microsoft.VisualBasic.Strings.Len(s); index <= loopTo; index++)
            {
                char c = Conversions.ToChar(Microsoft.VisualBasic.Strings.UCase(Microsoft.VisualBasic.Strings.Mid(s, index, 1)));
                if (!IsAlpha(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsAlpha(char c)
        {
            c = Microsoft.VisualBasic.Strings.UCase(c);
            if (Operators.CompareString(c.ToString(), "A", false) < 0 || Operators.CompareString(c.ToString(), "Z", false) > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true, if every character in a string is alphabetic or numeric (a-z, A-Z, 0-9).
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns>TRUE, if every character in <paramref name="s" /> is a character between 'a' and 'z' or 'A' and 'Z' or '0' and '9'; FALSE otherwise.</returns>
        public static bool IsAlphaNumeric(string s)
        {
            for (int index = 1, loopTo = Microsoft.VisualBasic.Strings.Len(s); index <= loopTo; index++)
            {
                char c = Conversions.ToChar(Microsoft.VisualBasic.Strings.Mid(s, index, 1));
                if (!IsAlphaNumeric(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true, if a character is alphabetic or numeric (a-z, A-Z, 0-9).
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsAlphaNumeric(char c)
        {
            if (!IsDigits(c) && !IsAlpha(c))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns True, if a every character in a string is a digit (0-9) or the string is empty.
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns>TRUE, if every character in <paramref name="s" /> is a character between '0' and '9'; FALSE otherwise.</returns>
        public static bool IsDigit(string s)
        {
            for (int index = 1, loopTo = Microsoft.VisualBasic.Strings.Len(s); index <= loopTo; index++)
            {
                char c = Conversions.ToChar(Microsoft.VisualBasic.Strings.Mid(s, index, 1));
                if (!IsDigits(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns True, if a single character is a digit.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsDigits(char c)
        {
            if (Operators.CompareString(c.ToString(), "0", false) < 0 || Operators.CompareString(c.ToString(), "9", false) > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns TRUE, is a string has a given prefix and suffix.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="prefixAndSuffix"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsEnclosed(string s, string prefixAndSuffix)
        {
            return IsEnclosed(s, prefixAndSuffix, prefixAndSuffix);
        }
        public static bool IsEnclosed(string s, string prefix, string suffix)
        {
            return (Microsoft.VisualBasic.Strings.Left(s, Microsoft.VisualBasic.Strings.Len(prefix)) ?? "") == (prefix ?? "") && (Microsoft.VisualBasic.Strings.Right(s, Microsoft.VisualBasic.Strings.Len(suffix)) ?? "") == (suffix ?? "");
        }

        /// <summary>
        /// Returns true, if every character in a string is a hexadecimal digit.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsHexadecimal(string s)
        {
            foreach (char c in s)
            {
                char cc = Microsoft.VisualBasic.Strings.UCase(c);
                if ((Operators.CompareString(cc.ToString(), "0", false) < 0 || Operators.CompareString(cc.ToString(), "9", false) > 0) && (Operators.CompareString(cc.ToString(), "A", false) < 0 || Operators.CompareString(cc.ToString(), "F", false) > 0))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns True, if every character in a string is lowercase alphabetic (a-z).
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns>TRUE, if every character in <paramref name="s" /> is a character between 'a' and 'z'; FALSE otherwise.</returns>
        public static bool IsLowerAlpha(string s)
        {
            for (int index = 1, loopTo = Microsoft.VisualBasic.Strings.Len(s); index <= loopTo; index++)
            {
                char c = Conversions.ToChar(Microsoft.VisualBasic.Strings.Mid(s, index, 1));
                if (!IsLowerAlpha(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns True, if a single character is lowercase alphabetic (a-z).
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsLowerAlpha(char c)
        {
            if (Operators.CompareString(c.ToString(), "a", false) < 0 || Operators.CompareString(c.ToString(), "z", false) > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true, if every character in a string is uppercase alphabetic (A-Z).
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns>TRUE, if every character in <paramref name="s" /> is a character between 'A' and 'Z'; FALSE otherwise.</returns>
        public static bool IsUpperAlpha(string s)
        {
            for (int index = 1, loopTo = Microsoft.VisualBasic.Strings.Len(s); index <= loopTo; index++)
            {
                char c = Conversions.ToChar(Microsoft.VisualBasic.Strings.Mid(s, index, 1));
                if (!IsUpperAlpha(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true, if a single character is uppercase alphabetic (A-Z).
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsUpperAlpha(char c)
        {
            if (Operators.CompareString(c.ToString(), "A", false) < 0 || Operators.CompareString(c.ToString(), "Z", false) > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true, if every character in a string is uppercase alphabetic or numeric (A-Z, 0-9).
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns>TRUE, if every character in <paramref name="s" /> is a character between 'A' and 'Z' or '0' and '9'; FALSE otherwise.</returns>
        public static bool IsUpperAlphaNumeric(string s)
        {
            for (int index = 1, loopTo = Microsoft.VisualBasic.Strings.Len(s); index <= loopTo; index++)
            {
                char c = Conversions.ToChar(Microsoft.VisualBasic.Strings.Mid(s, index, 1));
                if (!IsUpperAlphaNumeric(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true, if a single character is uppercase alphabetic or numeric (A-Z, 0-9).
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsUpperAlphaNumeric(char c)
        {
            if (!IsDigits(c) & !IsUpperAlpha(c))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Concatenates a list of strings.  Allows item delimiters, last item delimiters, item prefixes and item suffixes to be specified.
        /// </summary>
        /// <param name="list">The list to join.</param>
        /// <param name="delimiter">The text to insert between entries, if there is more than one extry and excluding the last entry.  If not specified, a comma will be used.</param>
        /// <param name="lastDelimiter">The text to insert before the last entry, if it is not the only entry.  If not specified, the delimiter will be used.</param>
        /// <param name="itemPrefix">The text to insert before each entry.  If not specified, nothing will be inserted.</param>
        /// <param name="itemSuffix">The text to insert after each entry.  If not specified, nothing will be inserted.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method can be used to produce an english reading list.  Example: cars, automobiles, trains and planes.
        /// This routine was converted from using the DelimitIf routine to using a StringBuilder to improve performance.
        /// </remarks>
        public static string JoinList(List<string> list, string delimiter = ",", string lastDelimiter = null, string itemPrefix = "", string itemSuffix = "")
        {
            var s = new StringBuilder();

            if (lastDelimiter == null)
            {
                lastDelimiter = delimiter;
            }

            if (!(list == null) && list.Count > 0)
            {
                for (int i = 0, loopTo = list.Count - 2; i <= loopTo; i++)
                {
                    if (s.Length > 0)
                    {
                        s.Append(delimiter);
                    }
                    s.Append(itemPrefix);
                    string currentItem = list[i];
                    if (!(currentItem == null))
                    {
                        s.Append(currentItem.ToString());
                    }
                    s.Append(itemSuffix);
                }
                string lastItem = list[list.Count - 1];
                if (!(lastItem == null))
                {
                    if (s.Length > 0)
                    {
                        s.Append(delimiter);
                    }
                    s.Append(itemPrefix);
                    s.Append(lastItem.ToString());
                    s.Append(itemSuffix);
                }
            }
            return s.ToString();
        }
        public static string JoinList(string delimiter, string lastDelimiter, string itemPrefix, string itemSuffix, params string[] items)
        {
            return JoinList(items, delimiter, lastDelimiter, itemPrefix, itemSuffix);
        }
        public static string JoinList(IEnumerable list, string delimiter = ",", string lastDelimiter = null, string itemPrefix = "", string itemSuffix = "")
        {
            if (list == null)
            {
                return null;
            }

            var s = new StringBuilder();
            IEnumerator enumerator;
            object lastItem = null;

            // If the last delimiter wasn't specified, default it to the delimiter.
            if (lastDelimiter == null)
            {
                lastDelimiter = delimiter;
            }

            enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (!(lastItem == null))
                {
                    if (s.Length > 0)
                    {
                        s.Append(delimiter);
                    }
                    s.Append(itemPrefix);
                    s.Append(lastItem.ToString());
                    s.Append(itemSuffix);
                }
                lastItem = enumerator.Current;
            }
            if (!(lastItem == null))
            {
                if (s.Length > 0)
                {
                    s.Append(delimiter);
                }
                s.Append(itemPrefix);
                s.Append(lastItem.ToString());
                s.Append(itemSuffix);
            }
            return s.ToString();
        }

        /// <summary>
        /// Concatenates a prefix string to a string value, if the string value is non-empty.
        /// </summary>
        /// <param name="conditionalPrefixString">The string to concatate as the prefix of stringValue, if stringValue is non-empty.</param>
        /// <param name="stringValue">The string to test and return.</param>
        /// <returns>[conditionalPrefixString] + [stringValue]</returns>
        public static string PrefixIf(string conditionalPrefixString, string stringValue)
        {
            if (Microsoft.VisualBasic.Strings.Len(stringValue) != 0)
            {
                return conditionalPrefixString + stringValue;
            }
            else
            {
                return stringValue;
            }
        }

        /// <summary>
        /// Returns a quantity number followed by either a singular or plural version of text, depending on whether the quantity value is equal to 1 or not.
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="singularText"></param>
        /// <param name="pluralText"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Plural(int quantity, string singularText, string pluralText, bool showQuantity = true)
        {
            return DelimitIf(Conversions.ToString(Interaction.IIf(showQuantity, quantity.ToString(), "")), " ", Conversions.ToString(Interaction.IIf(quantity == 1, singularText, pluralText)));
        }
        public static string Plural(double quantity, string singularText, string pluralText, bool showQuantity = true)
        {
            return DelimitIf(Conversions.ToString(Interaction.IIf(showQuantity, quantity.ToString(), "")), " ", Conversions.ToString(Interaction.IIf(quantity == 1d, singularText, pluralText)));
        }
        public static string Plural(long quantity, string singularText, string pluralText, bool showQuantity = true)
        {
            return DelimitIf(Conversions.ToString(Interaction.IIf(showQuantity, quantity.ToString(), "")), " ", Conversions.ToString(Interaction.IIf(quantity == 1L, singularText, pluralText)));
        }

        /// <summary>
        /// Concatenates a suffix string to a string value, if the string value is non-empty.
        /// </summary>
        /// <param name="stringValue">The string to test and return.</param>
        /// <param name="conditionalSuffixString">The string to concatate as the prefix of stringValue, if stringValue is non-empty.</param>
        /// <returns>[stringValue] + [conditionalPrefixString]</returns>
        public static string SuffixIf(string stringValue, string conditionalSuffixString)
        {
            if (Microsoft.VisualBasic.Strings.Len(stringValue) != 0)
            {
                return stringValue + conditionalSuffixString;
            }
            else
            {
                return stringValue;
            }
        }

        /// <summary>
        /// Returns a numeric value (of type double) that is found at the beginning of a string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool TryParseLeadingDouble(string s, ref double d)
        {
            int i = 1;
            while (i <= Microsoft.VisualBasic.Strings.Len(s) && Microsoft.VisualBasic.Strings.InStr("0123456789-.+E", Microsoft.VisualBasic.Strings.Mid(s, i, 1)) > 0)
                i += 1;
            if (i == 1)
            {
                return false;
            }
            else
            {
                d = Conversions.ToDouble(Microsoft.VisualBasic.Strings.Mid(s, 1, i - 1));
                return true;
            }
        }
    }
}