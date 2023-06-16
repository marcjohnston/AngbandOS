// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Syllables;

/// <summary>
/// Represents 'cthuloid' syllables used to create names for mind flayers, miri nigri, and tcho tchos.
/// </summary>
internal class CthuloidSyllables : RaceNamingSyllables
{
    public override string[] BeginningSyllables => new string[] { "Cth", "Az", "Fth", "Ts", "Xo", "Q'N", "R'L", "Ghata", "L", "Zz", "Fl", "Cl", "S", "Y" };
    public override string[] MiddleSyllables => new string[] { "nar", "loi", "ul", "lu", "noth", "thon", "ath", "'N", "rhy", "oth", "aza", "agn", "oa", "og" };
    public override string[] EndingSyllables => new string[] { "l", "a", "u", "oa", "oggua", "oth", "ath", "aggua", "lu", "lo", "loth", "lotha", "agn", "axl" };
}
