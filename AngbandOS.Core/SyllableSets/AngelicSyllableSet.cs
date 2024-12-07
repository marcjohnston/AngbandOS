// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.SyllableSets;

/// <summary>
/// Represents 'angelic' syllables used to create names for imps.
/// </summary>
internal class AngelicSyllableSet : SyllableSet
{
    public override string[] BeginningSyllables => new string[] { "Sa", "A", "U", "Mi", "Ra", "Ana", "Pa", "Lu", "She", "Ga", "Da", "O", "Pe", "Lau", "Za", "Ze", "E" };
    public override string[] MiddleSyllables => new string[] { "br", "m", "l", "z", "zr", "mm", "mr", "r", "ral", "ch", "zaz", "tr", "n", "lar" };
    public override string[] EndingSyllables => new string[] { "iel", "ial", "ael", "ubim", "aphon", "iel", "ael" };
}
