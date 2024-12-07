// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.SyllableSets;

/// <summary>
/// Represents 'elvish' names used by elves, dark elves, high elves, half-elves, and sprites.
/// </summary>
internal class ElvishSyllableSet : SyllableSet
{
    public override string[] BeginningSyllables => new string[]
    {
        "Al", "An", "Bal", "Bel", "Cal", "Cel", "El", "Elr", "Elv", "Eow", "Ear", "F", "Fal", "Fel", "Fin", "G",
        "Gal", "Gel", "Gl", "Is", "Lan", "Leg", "Lom", "N", "Nal", "Nel", "S", "Sal", "Sel", "T", "Tal", "Tel",
        "Thr", "Tin"
    };

    public override string[] MiddleSyllables => new string[] { "a", "adrie", "ara", "e", "ebri", "ele", "ere", "i", "io", "ithra", "ilma", "il-Ga", "ili", "o", "orfi", "u", "y" };
    public override string[] EndingSyllables => new string[]
        {
        "l", "las", "lad", "ldor", "ldur", "linde", "lith", "mir", "n", "nd", "ndel", "ndil", "ndir", "nduil", "ng",
        "mbor", "r", "rith", "ril", "riand", "rion", "s", "thien", "viel", "wen", "wyn"
    };
}
