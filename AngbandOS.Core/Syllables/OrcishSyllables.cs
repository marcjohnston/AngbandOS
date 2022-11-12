namespace AngbandOS.Core.Syllables
{
    /// <summary>
    /// Represents 'orcish' names used by half orcs, half ogres, and half trolls
    /// </summary>
    internal class OrcishSyllables : RaceNamingSyllables
    {
        public override string[] BeginningSyllables => new string[] { "B", "Er", "G", "Gr", "H", "P", "Pr", "R", "V", "Vr", "T", "Tr", "M", "Dr" };
        public override string[] MiddleSyllables => new string[] { "a", "i", "o", "oo", "u", "ui" };
        public override string[] EndingSyllables => new string[] { "dash", "dish", "dush", "gar", "gor", "gdush", "lo", "gdish", "k", "lg", "nak", "rag", "rbag", "rg", "rk", "ng", "nk", "rt", "ol", "urk", "shnak", "mog", "mak", "rak" };
    }
}
