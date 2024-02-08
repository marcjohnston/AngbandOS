// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class ElvishTextRepositoryCollection : StringListRepositoryCollection
{
    public ElvishTextRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns ElvishTexts as the name of this string list repository.
    /// </summary>
    public override string Name => "ElvishTexts";

    public override void Load()
    {
        Add("adan", "ael", "in", "agl", "ar", "aina", "alda", "al", "qua", "am", "arth", "amon", "anca", "an", "dune",
            "anga", "anna", "ann", "on", "ar", "ien", "atar", "band", "bar", "ad", "bel", "eg", "brag", "ol", "breth",
            "il", "brith", "cal", "en", "gal", "en", "cam", "car", "ak", "cel", "eb", "cor", "on", "cu", "cui", "vie",
            "cul", "curu", "dae", "dag", "or", "del", "din", "dol", "dor", "draug", "du", "duin", "dur", "ear", "ech",
            "or", "edh", "el", "eith", "elen", "er", "ereg", "es", "gal", "fal", "as", "far", "oth", "faug", "fea",
            "fin", "for", "men", "fuin", "gaer", "gaur", "gil", "gir", "ith", "glin", "gol", "odh", "gond", "gor",
            "groth", "grod", "gul", "gurth", "gwaith", "gwath", "wath", "had", "hod", "haudh", "heru", "him", "hini",
            "hith", "hoth", "hyar", "men", "ia", "iant", "iath", "iaur", "ilm", "iluve", "kal", "gal", "kano", "kel",
            "kemen", "khel", "ek", "khil", "kir", "lad", "laure", "lhach", "lin", "lith", "lok", "lom", "lome", "londe",
            "los", "loth", "luin", "maeg", "mal", "man", "mel", "men", "menel", "mer", "eth", "min", "as", "mir",
            "mith", "mor", "moth", "nan", "nar", "naug", "dil", "dur", "nel", "dor", "nen", "nim", "orn", "orod", "os",
            "pal", "an", "pel", "quen", "quet", "ram", "ran", "rant", "ras", "rauko", "ril", "rim", "ring", "ris",
            "roch", "rom", "rond", "ros", "ruin", "ruth", "sarn", "ser", "eg", "sil", "sir", "sul", "tal", "dal", "tal",
            "ath", "tar", "tath", "ar", "taur", "tel", "thal", "thang", "thar", "thaur", "thin", "thol", "thon", "thor",
            "on", "til", "tin", "tir", "tol", "tum", "tur", "uial", "ur", "val", "wen", "wing", "yave");
    }
}