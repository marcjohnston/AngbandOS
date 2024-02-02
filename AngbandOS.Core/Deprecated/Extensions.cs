// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text;

namespace AngbandOS.Core;

/// <summary>
/// Extension methods for primitive types
/// </summary>
internal static class Extensions
{
    /// <summary>
    /// Converts an index (0-37) to a letter (a-z) for an inventory or equipment slot
    /// </summary>
    /// <param name="i"> The index </param>
    /// <returns> The letter </returns>
    public static char IndexToLabel(this int i)
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyzz";
        if (i < InventorySlot.MeleeWeapon)
        {
            return alphabet[i];
        }
        return alphabet[i - InventorySlot.MeleeWeapon];
    }

    /// <summary>
    /// Converts an index (0-25) to a lower case letter (a-z)
    /// </summary>
    /// <param name="x"> The index </param>
    /// <returns> The letter </returns>
    public static char IndexToLetter(this int x)
    {
        return (char)('a' + (char)x);
    }

    /// <summary>
    /// Returns whether or not a character is a vowel
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
    /// Converts a character from a-z into a numeric index 0-25
    /// </summary>
    /// <param name="x"> The character to convert </param>
    /// <returns> The index of the character </returns>
    public static int LetterToNumber(this char x)
    {
        return x - 'a';
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
    /// Pluralizes a monster name, with various special cases for unusual names
    /// </summary>
    /// <param name="name"> The name to pluralize.</param>
    /// <returns> The plural form of the name.</returns>
    public static string PluralizeMonsterName(this string name)
    {
        string plural;
        // "X of Y" -> "Xs of Y"
        if (name.Contains(" of "))
        {
            int i = name.IndexOf(" of ", StringComparison.Ordinal);
            plural = name.Substring(0, i);
            // "XS of Y -> XSes of Y"
            if (plural.EndsWith("s"))
            {
                plural += "es";
            }
            // "Young of Y" or "Spawn of Y" are unchanged
            else if (plural.EndsWith("ng") || plural.EndsWith("wn"))
            {
                // Plural matches singular
            }
            else
            {
                plural += "s";
            }
            plural += name.Substring(i);
        }
        // "Pile of X coins" -> "Piles of X coins"
        else if (name.Contains("coins"))
        {
            plural = "piles of " + name;
        }
        // "Manes" and "Mi-Go" are their own plurals
        else if (name == "Manes" || name == "Mi-Go")
        {
            plural = name;
        }
        // "Homonculous" -> "Homonculi"
        else if (name == "Homonculous")
        {
            plural = "Homonculi";
        }
        // "Stairway to hell" -> "Stairways to hell"
        else if (name == "Stairway to hell")
        {
            plural = "Stairways to hell";
        }
        // "Harpy" or similar -> "Harpies" or similar
        else if (name.EndsWith("y"))
        {
            plural = name.Substring(0, name.Length - 1) + "ies";
        }
        // "Mouse" or similar -> "Mice" or similar
        else if (name.EndsWith("ouse"))
        {
            plural = name.Substring(0, name.Length - 4) + "ice";
        }
        // "Pukelman" -> "Pukelmen"
        else if (name.EndsWith("kelman") || name.EndsWith(" man"))
        {
            plural = name.Substring(0, name.Length - 2) + "en";
        }
        // "X child" -> "X children"
        else if (name.EndsWith("hild"))
        {
            plural = name + "ren";
        }
        // "X vortex" -> "X vortices"
        else if (name.EndsWith("ex"))
        {
            plural = name.Substring(0, name.Length - 2) + "ices";
        }
        // "X wolf" and "X thief" -> "X wolves" and "X thieves"
        else if (name.EndsWith("olf") || name.EndsWith("ief"))
        {
            plural = name.Substring(0, name.Length - 1) + "ves";
        }
        // "Leech" (or similar) -> "Leeches"
        else if (name.EndsWith("ch") || name.EndsWith("s"))
        {
            plural = name + "es";
        }
        // If all else fails, just add an 's'.
        else
        {
            plural = name + "s";
        }
        return plural;
    }

    /// <summary>
    /// Converts a numeric ability score (3-118) to a string (3-40+)
    /// </summary>
    /// <param name="val"> The value of the ability score </param>
    /// <returns> The display value </returns>
    public static string StatToString(this int val)
    {
        // Above 18, scores are measured in tenths of a point
        if (val > 18)
        {
            int bonus = val - 18;
            if (bonus > 220)
            {
                return "   40+";
            }
            bonus = (bonus - 1) / 10;
            return (bonus + 19).ToString().PadLeft(6);
        }
        return val.ToString().PadLeft(6);
    }

    /// <summary>
    /// Converts an integer to a Roman numeral
    /// </summary>
    /// <param name="number"> The number to convert </param>
    /// <param name="forGeneration"> True if the number is the generation of a character </param>
    /// <returns> The number as a Roman numeral </returns>
    public static string ToRoman(this int number, bool forGeneration)
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


        StringBuilder roman = new StringBuilder();
        // If we're for a generation, we want to skip 'I' (you're simply "John", not "John I")
        // and prefix with a space if not 'I')
        if (forGeneration)
        {
            if (number == 1)
            {
                return string.Empty;
            }
            else
            {
                roman.Append(' ');
            }
        }
        // Roman numerals are not positional, so simply start with the highest number and keep
        // appending and subtracting until we can't
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

    public static string Pluralize(string singular, int count)
    {
        if (count == 1)
        {
            return singular;
        }
        else
        {
            if ("sh".IndexOf(singular[singular.Length - 1]) >= 0)
            {
                return $"{singular}es";
            }
            else
            {
                return $"{singular}s";
            }
        }
    }

    public static string GetPrefixCount(bool includeSingularPrefix, string singularNoun, int count, bool isKnownArtifact)
    {
        if (count <= 0)
        {
            return $"no more {singularNoun}";
        }
        else if (count > 1)
        {
            return $"{count} {singularNoun}";
        }
        else if (isKnownArtifact)
        {
            return $"The {singularNoun}";
        }
        else if (includeSingularPrefix)
        {
            if (singularNoun[0].IsVowel())
            {
                return $"an {singularNoun}";
            }
            else
            {
                return $"a {singularNoun}";
            }
        }
        else
        {
            return singularNoun;
        }
    }

    public static string GetSignedValue(int value)
    {
        if (value >= 0)
        {
            return $"+{value}";
        }
        else
        {
            return $"{value}";
        }
    }
}