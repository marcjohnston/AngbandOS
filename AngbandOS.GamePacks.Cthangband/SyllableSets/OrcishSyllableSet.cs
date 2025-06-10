// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents 'orcish' names used by half orcs, half ogres, and half trolls
/// </summary>
public class OrcishSyllableSet : SyllableSetGameConfiguration
{
    public override string[] BeginningSyllables => new string[] { "B", "Er", "G", "Gr", "H", "P", "Pr", "R", "V", "Vr", "T", "Tr", "M", "Dr" };
    public override string[] MiddleSyllables => new string[] { "a", "i", "o", "oo", "u", "ui" };
    public override string[] EndingSyllables => new string[] { "dash", "dish", "dush", "gar", "gor", "gdush", "lo", "gdish", "k", "lg", "nak", "rag", "rbag", "rg", "rk", "ng", "nk", "rt", "ol", "urk", "shnak", "mog", "mak", "rak" };
}
