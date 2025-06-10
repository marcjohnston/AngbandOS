// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents 'gnomish' names used by gnomes and draconians.
/// </summary>
public class GnomishSyllableSet : SyllableSetGameConfiguration
{
    public override string[] BeginningSyllables => new string[]
    {
        "Aar", "An", "Ar", "As", "C", "H", "Han", "Har", "Hel", "Iir", "J", "Jan", "Jar", "K", "L", "M", "Mar", "N",
        "Nik", "Os", "Ol", "P", "R", "S", "Sam", "San", "T", "Ter", "Tom", "Ul", "V", "W", "Y"
    };

    public override string[] MiddleSyllables => new string[] { "a", "aa", "ai", "e", "ei", "i", "o", "uo", "u", "uu" };
    public override string[] EndingSyllables => new string[]
    {
        "ron", "re", "la", "ki", "kseli", "ksi", "ku", "ja", "ta", "na", "namari", "neli", "nika", "nikki", "nu",
        "nukka", "ka", "ko", "li", "kki", "rik", "po", "to", "pekka", "rjaana", "rjatta", "rjukka", "la", "lla",
        "lli", "mo", "nni"
    };
}
