// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.SyllableSets;

/// <summary>
/// Represents 'hobbit' names used by hobbits and kobolds.
/// </summary>
internal class HobbitSyllableSet : SyllableSet
{
    private HobbitSyllableSet(Game game) : base(game) { } // This object is a singleton.
    public override string[] BeginningSyllables => new string[] { "B", "Ber", "Br", "D", "Der", "Dr", "F", "Fr", "G", "H", "L", "Ler", "M", "Mer", "N", "P", "Pr", "Per", "R", "S", "T", "W" };
    public override string[] MiddleSyllables => new string[] { "a", "e", "i", "ia", "o", "oi", "u" };
    public override string[] EndingSyllables => new string[]
    {
        "bo", "ck", "decan", "degar", "do", "doc", "go", "grin", "lba", "lbo", "lda", "ldo", "lla", "ll", "lo", "m",
        "mwise", "nac", "noc", "nwise", "p", "ppin", "pper", "tho", "to"
    };
}
