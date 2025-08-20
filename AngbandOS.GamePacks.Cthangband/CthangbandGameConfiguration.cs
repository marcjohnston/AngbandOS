// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

public class CthangbandGameConfiguration : GameConfiguration
{
    public override int[] RequiredExperiencePerLevel => new int[] 
    {
        10, 25, 45, 70, 100, 140, 200, 280, 380, 500, 650, 850, 1100, 1400, 1800, 2300, 2900, 3600, 4400, 5400,
        6800, 8400, 10200, 12500, 17500, 25000, 35000, 50000, 75000, 100000, 150000, 200000, 275000, 350000, 450000,
        550000, 700000, 850000, 1000000, 1250000, 1500000, 1800000, 2100000, 2400000, 2700000, 3000000, 3500000,
        4000000, 4500000, 5000000
    };

    public override int[][] BlowsTable => new int[][]
    {
        new[] {1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3},
        new[] {1, 1, 1, 1, 2, 2, 3, 3, 3, 4, 4, 4},
        new[] {1, 1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5},
        new[] {1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 5},
        new[] {1, 2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5},
        new[] {2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5, 6},
        new[] {2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5, 6},
        new[] {2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 5, 6},
        new[] {3, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6},
        new[] {3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6},
        new[] {3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6},
        new[] {3, 3, 4, 4, 4, 4, 5, 5, 6, 6, 6, 6}
    };

    public override int[] ExtractEnergy => new int[]
    {
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* S-50 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* S-40 */     2,  2,  2,  2,  2,  2,  2,  2,  2,  2,
	/* S-30 */     2,  2,  2,  2,  2,  2,  2,  3,  3,  3,
	/* S-20 */     3,  3,  3,  3,  3,  4,  4,  4,  4,  4,
	/* S-10 */     5,  5,  5,  5,  6,  6,  7,  7,  8,  9,
	/* Norm */    10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
	/* F+10 */    20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
	/* F+20 */    30, 31, 32, 33, 34, 35, 36, 36, 37, 37,
	/* F+30 */    38, 38, 39, 39, 40, 40, 40, 41, 41, 41,
	/* F+40 */    42, 42, 42, 43, 43, 43, 44, 44, 44, 44,
	/* F+50 */    45, 45, 45, 45, 45, 46, 46, 46, 46, 46,
	/* F+60 */    47, 47, 47, 47, 47, 48, 48, 48, 48, 48,
	/* F+70 */    49, 49, 49, 49, 49, 49, 49, 49, 49, 49,
	/* Fast */    49, 49, 49, 49, 49, 49, 49, 49, 49, 49
    };


    public override string? DungeonViewBindingKey => nameof(DungeonView);

    public override string[]? GoldFactoriesBindingKeys => new string[]
    {
        "CopperGoldItemFactory",
        "Copper1GoldItemFactory",
        "Copper2GoldItemFactory",
        "PieceOfSilverGoldItemFactory",
        "Silver1GoldItemFactory",
        "Silver2GoldItemFactory",
        "SomeGarnetsGoldItemFactory",
        "LotOfGarnetsGoldItemFactory",
        "GoldGoldItemFactory",
        "SomeGoldGoldItemFactory",
        "LotOfGoldGoldItemFactory",
        "OpalsGoldItemFactory",
        "SapphiresGoldItemFactory",
        "RubiesGoldItemFactory",
        "DiamondsGoldItemFactory",
        "EmeraldsGoldItemFactory",
        "MithrilGoldItemFactory",
        "AdamantiteGoldItemFactory"
    };

    public override string[]? ElvishTexts => new string[]
    {
        "adan", "ael", "in", "agl", "ar", "aina", "alda", "al", "qua", "am", "arth", "amon", "anca", "an", "dune",
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
        "on", "til", "tin", "tir", "tol", "tum", "tur", "uial", "ur", "val", "wen", "wing", "yave"
    };

    public override string[]? FindQuests => new string[]
    {
        "You find the following inscription in the floor",
        "You see a message inscribed in the wall",
        "There is a sign saying",
        "Something is written on the staircase",
        "You find a scroll with the following message"
    };

    public override string[]? FunnyComments => new string[]
    {
        "Wow, cosmic, man!",
        "Rad!",
        "Groovy!",
        "Cool!",
        "Far out!"
    };

    public override string[]? FunnyDescriptions => new string[]
    {
        "silly", "hilarious", "absurd", "insipid", "ridiculous", "laughable", "ludicrous", "far-out", "groovy",
        "postmodern", "fantastic", "dadaistic", "cubistic", "cosmic", "awesome", "incomprehensible", "fabulous",
        "amazing", "incredible", "chaotic", "wild", "preposterous"
    };

    public override string[]? HorrificDescriptions => new string[]
    {
        "abominable", "abysmal", "appalling", "baleful", "blasphemous", "disgusting", "dreadful", "filthy",
        "grisly", "hideous", "hellish", "horrible", "infernal", "loathsome", "nightmarish", "repulsive",
        "sacrilegious", "terrible", "unclean", "unspeakable"
    };

    public override string[]? IllegibleFlavorSyllables => new string[]
    {
        "a", "ab", "ag", "aks", "ala", "an", "ankh", "app", "arg", "arze", "ash", "aus", "ban", "bar", "bat", "bek",
        "bie", "bin", "bit", "bjor", "blu", "bot", "bu", "byt", "comp", "con", "cos", "cre", "dalf", "dan", "den",
        "der", "doe", "dok", "eep", "el", "eng", "er", "ere", "erk", "esh", "evs", "fa", "fid", "flit", "for",
        "fri", "fu", "gan", "gar", "glen", "gop", "gre", "ha", "he", "hyd", "i", "ing", "ion", "ip", "ish", "it",
        "ite", "iv", "jo", "kho", "kli", "klis", "la", "lech", "man", "mar", "me", "mi", "mic", "mik", "mon",
        "mung", "mur", "nag", "nej", "nelg", "nep", "ner", "nes", "nis", "nih", "nin", "o", "od", "ood", "org",
        "orn", "ox", "oxy", "pay", "pet", "ple", "plu", "po", "pot", "prok", "re", "rea", "rhov", "ri", "ro", "rog",
        "rok", "rol", "sa", "san", "sat", "see", "sef", "seh", "shu", "ski", "sna", "sne", "snik", "sno", "so",
        "sol", "sri", "sta", "sun", "ta", "tab", "tem", "ther", "ti", "tox", "trol", "tue", "turs", "u", "ulk",
        "um", "un", "uni", "ur", "val", "viv", "vly", "vom", "wah", "wed", "werg", "wex", "whon", "wun", "x",
        "yerg", "yp", "zun", "tri", "blaa", "jah", "bul", "on", "foo", "ju", "xuxu"
    };

    public override string[]? ShopkeeperAcceptedComments => new string[]
    {
        "Okay.",
        "Fine.",
        "Accepted!",
        "Agreed!",
        "Done!",
        "Taken!"
    };
}
