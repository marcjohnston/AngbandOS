// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
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
        if (i < InventorySlotEnum.MeleeWeapon)
        {
            return alphabet[i];
        }
        return alphabet[i - InventorySlotEnum.MeleeWeapon];
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
    /// Converts a character from a-z into a numeric index 0-25
    /// </summary>
    /// <param name="x"> The character to convert </param>
    /// <returns> The index of the character </returns>
    public static int LetterToNumber(this char x)
    {
        return x - 'a';
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
}