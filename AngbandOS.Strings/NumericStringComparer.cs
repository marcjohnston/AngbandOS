using System;
using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace byMarc.Net2.Library.Strings
{
    public class NumericStringComparer : IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>-1, if x is less than y, 0 if both strings are identical, 1 if x is greater than y.</returns>
        /// <remarks></remarks>
        public int Compare(object x, object y)
        {
            int xIndex = 1;
            int yIndex = 1;
            bool numericMode = false;
            var numericStart = default(int);
            while (xIndex <= Microsoft.VisualBasic.Strings.Len(x) && yIndex <= Microsoft.VisualBasic.Strings.Len(y))
            {
                char xc = Conversions.ToChar(Microsoft.VisualBasic.Strings.Mid(Conversions.ToString(x), xIndex, 1));
                char yc = Conversions.ToChar(Microsoft.VisualBasic.Strings.Mid(Conversions.ToString(y), yIndex, 1));
                if (numericMode)
                {
                    if (!Information.IsNumeric(xc) && !Information.IsNumeric(yc))
                    {
                        // Both numbers are of the same length.
                        int xNumber = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(Conversions.ToString(x), numericStart, xIndex - numericStart + 1)));
                        int yNumber = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(Conversions.ToString(y), numericStart, yIndex - numericStart + 1)));
                        if (xNumber == yNumber)
                        {
                            // The numbers are the same, go to the next character and turn off numeric mode.
                            xIndex += 1;
                            yIndex += 1;
                            numericMode = false;
                        }
                        else if (xNumber < yNumber)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else if (!Information.IsNumeric(xc))
                    {
                        // Y has more digits, continue to move just y.
                        yIndex += 1;
                    }
                    else if (!Information.IsNumeric(yc))
                    {
                        // X has more digits, continue to move just x.
                        xIndex += 1;
                    }
                    else
                    {
                        // Absorb more digits.
                        xIndex += 1;
                        yIndex += 1;
                    }
                }

                if (!numericMode)
                {
                    if (Information.IsNumeric(xc) && Information.IsNumeric(yc))
                    {
                        numericMode = true;
                        numericStart = xIndex;
                        xIndex += 1;
                        yIndex += 1;
                    }
                    else if (xc < yc)
                    {
                        return -1;
                    }
                    else if (xc > yc)
                    {
                        return 1;
                    }
                    else
                    {
                        // Go to the next character.
                        xIndex += 1;
                        yIndex += 1;
                    }
                }
            }

            if (xIndex > Microsoft.VisualBasic.Strings.Len(x) && yIndex > Microsoft.VisualBasic.Strings.Len(y))
            {
                // The strings are identical.
                return 0;
            }
            else if (xIndex > Microsoft.VisualBasic.Strings.Len(x))
            {
                // X is shorter.
                return -1;
            }
            else
            {
                // Y is shorter
                return 1;
            }
        }
    }
}