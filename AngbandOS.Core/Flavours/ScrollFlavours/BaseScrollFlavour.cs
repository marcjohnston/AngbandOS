// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavours;

[Serializable]
internal abstract class BaseScrollFlavour : Flavour
{
    protected BaseScrollFlavour(SaveGame saveGame) : base(saveGame)
    {
    }

    public static readonly string[] Syllables =
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
}
