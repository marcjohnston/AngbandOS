namespace AngbandOS.Core.Syllables
{
    /// <summary>
    /// Represents 'gnomish' names used by gnomes and draconians.
    /// </summary>
    internal class GnomishSyllables : RaceNamingSyllables
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
}
