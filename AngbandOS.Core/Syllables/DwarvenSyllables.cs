namespace AngbandOS.Core.Syllables
{
    /// <summary>
    /// Represents 'dwarven' names used by dwarves, cyclopes, half giants, golems, and nibelungen.
    /// </summary>
    internal class DwarvenSyllables : RaceNamingSyllables
    {
        public override string[] BeginningSyllables => new string[] { "B", "D", "F", "G", "Gl", "H", "K", "L", "M", "N", "R", "S", "T", "Th", "V" };
        public override string[] MiddleSyllables => new string[] { "a", "e", "i", "o", "oi", "u" };
        public override string[] EndingSyllables => new string[] { "bur", "fur", "gan", "gnus", "gnar", "li", "lin", "lir", "mli", "nar", "nus", "rin", "ran", "sin", "sil", "sur" };
    }
}
