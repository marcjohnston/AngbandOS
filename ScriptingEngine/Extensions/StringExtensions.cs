using Microsoft.VisualBasic;

namespace Big6Search.ScriptingEngine
{

    // Public Module StringExtensions
    // ''' <summary>
    // ''' Returns the index of the first non-space in the string.  If the string is empty or all spaces, 0 is returned.
    // ''' </summary>
    // ''' <param name="s"></param>
    // ''' <returns></returns>
    // ''' <remarks></remarks>
    // <Extension()> _
    // Public Function CountOfLeadingSpaces(s As String) As Integer
    // Dim count As Integer = 0
    // While (Len(s) > count) AndAlso Mid(s, count + 1, 1) = " "
    // count += 1
    // End While
    // If Len(s) <= count Then
    // ' Line is empty or all white space.
    // Return 0
    // Else
    // Return count
    // End If
    // End Function
    // End Module

    public static class StringLib
    {
        /// <summary>
    /// Returns the index of the first non-space in the string.  If the string is empty or all spaces, 0 is returned.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static int CountOfLeadingSpaces(string s)
        {
            int count = 0;
            while (Strings.Len(s) > count && Strings.Mid(s, count + 1, 1) == " ")
                count += 1;
            if (Strings.Len(s) <= count)
            {
                // Line is empty or all white space.
                return 0;
            }
            else
            {
                return count;
            }
        }
    }
}