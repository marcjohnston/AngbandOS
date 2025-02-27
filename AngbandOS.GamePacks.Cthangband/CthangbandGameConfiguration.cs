// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

public class CthangbandGameConfiguration : GameConfiguration
{
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

    public override HelpGroupGameConfiguration[]? HelpGroups => new HelpGroupGameConfiguration[]
    {
        new WizardCharacterEditingHelpGroup(),
        new WizardGeneralCommandsHelpGroup(),
        new WizardMonstersHelpGroup(),
        new WizardMovementHelpGroup(),
        new WizardObjectCommandsHelpGroup()
    };

    public override SymbolGameConfiguration[]? Symbols => new SymbolGameConfiguration[]
    {
        new AmpersandSymbol(),
        new AsteriskSymbol(),
        new AtSymbol(),
        new BackSlashSymbol(),
        new CaretSymbol(),
        new CloseBraceSymbol(),
        new CloseBracketSymbol(),
        new CloseParenthesisSymbol(),
        new ColonSymbol(),
        new CommaSymbol(),
        new DollarSignSymbol(),
        new DoubleQuoteSymbol(),
        new EqualSignSymbol(),
        new ExclamationPointSymbol(),
        new ForwardSlashSymbol(),
        new GreaterThanSymbol(),
        new LessThanSymbol(),
        new LowerASymbol(),
        new LowerBSymbol(),
        new LowerCSymbol(),
        new LowerDSymbol(),
        new LowerESymbol(),
        new LowerFSymbol(),
        new LowerGSymbol(),
        new LowerHSymbol(),
        new LowerISymbol(),
        new LowerJSymbol(),
        new LowerKSymbol(),
        new LowerLSymbol(),
        new LowerMSymbol(),
        new LowerNSymbol(),
        new LowerOSymbol(),
        new LowerPSymbol(),
        new LowerQSymbol(),
        new LowerRSymbol(),
        new LowerSSymbol(),
        new LowerTSymbol(),
        new LowerUSymbol(),
        new LowerVSymbol(),
        new LowerWSymbol(),
        new LowerXSymbol(),
        new LowerYSymbol(),
        new LowerZSymbol(),
        new LowerASymbol(),
        new MinusSignSymbol(),
        new NumberEightSymbol(),
        new NumberFiveSymbol(),
        new NumberFourSymbol(),
        new NumberNineSymbol(),
        new NumberOneSymbol(),
        new NumberSevenSymbol(),
        new NumberSixSymbol(),
        new NumberThreeSymbol(),
        new NumberTwoSymbol(),
        new NumberZeroSymbol(),
        new OpenBraceSymbol(),
        new OpenBracketSymbol(),
        new OpenParenthesisSymbol(),
        new PercentSignSymbol(),
        new PeriodSymbol(),
        new PlusSignSymbol(),
        new PoundSignSymbol(),
        new QuestionMarkSymbol(),
        new SemiColonSymbol(),
        new SingleQuoteSymbol(),
        new SpaceBarSymbol(),
        new TildeSymbol(),
        new UnderscoreSymbol(),
        new UpperASymbol(),
        new UpperBSymbol(),
        new UpperCSymbol(),
        new UpperDSymbol(),
        new UpperESymbol(),
        new UpperFSymbol(),
        new UpperGSymbol(),
        new UpperHSymbol(),
        new UpperISymbol(),
        new UpperJSymbol(),
        new UpperKSymbol(),
        new UpperLSymbol(),
        new UpperMSymbol(),
        new UpperOSymbol(),
        new UpperPSymbol(),
        new UpperQSymbol(),
        new UpperRSymbol(),
        new UpperSSymbol(),
        new UpperTSymbol(),
        new UpperUSymbol(),
        new UpperVSymbol(),
        new UpperWSymbol(),
        new UpperXSymbol(),
        new UpperYSymbol(),
        new UpperZSymbol(),
        new VerticalBarSymbol()
    };

    public override (string, string[])[]? StringRepositories => new (string, string[])[]
    {
        ("ElvishTexts", new string[]
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
            }
        ),
        ("FindQuests", new string[]
            {
                "You find the following inscription in the floor",
                "You see a message inscribed in the wall",
                "There is a sign saying",
                "Something is written on the staircase",
                "You find a scroll with the following message"
            }
        ),
        ("FunnyComments", new string[]
            {
                "Wow, cosmic, man!",
                "Rad!",
                "Groovy!",
                "Cool!",
                "Far out!"
            }
        ),
        ("FunnyDescriptions", new string[]
            {
                "silly", "hilarious", "absurd", "insipid", "ridiculous", "laughable", "ludicrous", "far-out", "groovy",
                "postmodern", "fantastic", "dadaistic", "cubistic", "cosmic", "awesome", "incomprehensible", "fabulous",
                "amazing", "incredible", "chaotic", "wild", "preposterous"
            }
        ),
        ("HorrificDescriptions", new string[]
            {
                "abominable", "abysmal", "appalling", "baleful", "blasphemous", "disgusting", "dreadful", "filthy",
                "grisly", "hideous", "hellish", "horrible", "infernal", "loathsome", "nightmarish", "repulsive",
                "sacrilegious", "terrible", "unclean", "unspeakable"
            }
        ),
        ("IllegibleFlavorSyllables", new string[]
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
            }
        ),
        ("InsultPlayerAttacks", new string[]
            {
                "insults you!", "insults your mother!", "gives you the finger!", "humiliates you!", "defiles you!",
                "dances around you!", "makes obscene gestures!", "moons you!"
            }
        ),
        ("MoanPlayerAttacks", new string[]
            {
                "seems sad about something.",
                "asks if you have seen his dogs.",
                "tells you to get off his land.",
                "mumbles something about mushrooms."
            }
        ),
        ("ShopkeeperAcceptedComments", new string[]
            {
                "Okay.",
                "Fine.",
                "Accepted!",
                "Agreed!",
                "Done!",
                "Taken!"
            }
        ),
        ("ShopkeeperBargainComments", new string[]
            {
                "Yipee!",
                "I think I'll retire!",
                "The shopkeeper jumps for joy.",
                "The shopkeeper smiles gleefully."
            }
        ),
        ("ShopkeeperGoodComments", new string[]
            {
                "Cool!",
                "You've made my day!",
                "The shopkeeper giggles.",
                "The shopkeeper laughs loudly."
            }
        ),
        ("ShopkeeperLessThanGuessComments", new string[]
            {
                "Damn!",
                "You bastard!",
                "The shopkeeper curses at you.",
                "The shopkeeper glares at you."
            }
        ),
        ("ShopkeeperWorthlessComments", new string[]
            {
                "Arrgghh!",
                "You bastard!",
                "You hear someone sobbing...",
                "The shopkeeper howls in agony!"
            }
        ),
        ("SingingPlayerAttacks", new string[]
            {
                "sings 'We are a happy family.'",
                "sings 'I love you, you love me.'"
            }
        ),
        ("WorshipPlayerAttacks", new string[]
            {
                "looks up at you!",
                "asks how many dragons you've killed!",
                "asks for your autograph!",
                "tries to shake your hand!",
                "pretends to be you!",
                "dances around you!",
                "tugs at your clothing!",
                "asks if you will adopt him!"
            }
        )
    };
}
