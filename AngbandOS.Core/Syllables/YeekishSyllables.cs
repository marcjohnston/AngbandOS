namespace AngbandOS.Core.Syllables
{
    /// <summary>
    /// Represent 'yeekish' names used by yeeks.
    /// </summary>
    internal class YeekishSyllables : RaceNamingSyllables
    {
        public override string[] BeginningSyllables => new string[] { "Y", "Ye", "Yee", "Y" };
        public override string[] MiddleSyllables => new string[] { "ee", "eee", "ee", "ee-ee", "ee'ee", "'ee", "eee", "ee", "ee" };
        public override string[] EndingSyllables => new string[] { "k", "k", "k", "ek", "eek", "ek" };
    }
}
