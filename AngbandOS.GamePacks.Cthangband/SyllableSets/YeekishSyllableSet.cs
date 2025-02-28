// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represent 'yeekish' names used by yeeks.
/// </summary>
public class YeekishSyllableSet : SyllableSetGameConfiguration
{
    public override string[] BeginningSyllables => new string[] { "Y", "Ye", "Yee", "Y" };
    public override string[] MiddleSyllables => new string[] { "ee", "eee", "ee", "ee-ee", "ee'ee", "'ee", "eee", "ee", "ee" };
    public override string[] EndingSyllables => new string[] { "k", "k", "k", "ek", "eek", "ek" };
}
