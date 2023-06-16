namespace AngbandOS.Core.Syllables;

/// <summary>
/// Represents 'angelic' syllables used to create names for imps.
/// </summary>
internal class AngelicSyllables : RaceNamingSyllables
{
    public override string[] BeginningSyllables => new string[] { "Sa", "A", "U", "Mi", "Ra", "Ana", "Pa", "Lu", "She", "Ga", "Da", "O", "Pe", "Lau", "Za", "Ze", "E" };
    public override string[] MiddleSyllables => new string[] { "br", "m", "l", "z", "zr", "mm", "mr", "r", "ral", "ch", "zaz", "tr", "n", "lar" };
    public override string[] EndingSyllables => new string[] { "iel", "ial", "ael", "ubim", "aphon", "iel", "ael" };
}
