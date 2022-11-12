namespace AngbandOS.Core.Syllables
{
    /// <summary>
    /// Represents 'hobbit' names used by hobbits and kobolds.
    /// </summary>
    internal class HobbitSyllables : RaceNamingSyllables
    {
        public override string[] BeginningSyllables => new string[] { "B", "Ber", "Br", "D", "Der", "Dr", "F", "Fr", "G", "H", "L", "Ler", "M", "Mer", "N", "P", "Pr", "Per", "R", "S", "T", "W" };
        public override string[] MiddleSyllables => new string[] { "a", "e", "i", "ia", "o", "oi", "u" };
        public override string[] EndingSyllables => new string[]
        {
            "bo", "ck", "decan", "degar", "do", "doc", "go", "grin", "lba", "lbo", "lda", "ldo", "lla", "ll", "lo", "m",
            "mwise", "nac", "noc", "nwise", "p", "ppin", "pper", "tho", "to"
        };
    }
}
