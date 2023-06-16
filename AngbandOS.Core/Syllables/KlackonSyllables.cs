namespace AngbandOS.Core.Syllables;

/// <summary>
/// Represents 'klackon' names used by klackons.
/// </summary>
internal class KlackonSyllables : RaceNamingSyllables
{
    public override string[] BeginningSyllables => new string[] { "K'", "K", "Kri", "Kir", "Kiri", "Iriki", "Irik", "Karik", "Iri", "Akri" };
    public override string[] MiddleSyllables => new string[] { "arak", "i", "iri", "ikki", "ki", "kiri", "ikir", "irak", "arik", "k'", "r" };
    public override string[] EndingSyllables => new string[] { "akkak", "ak", "ik", "ikkik", "irik", "arik", "kidik", "kii", "k", "ki", "riki", "irk" };
}
