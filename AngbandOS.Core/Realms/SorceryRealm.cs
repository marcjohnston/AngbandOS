﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Realms;

[Serializable]
internal class SorceryRealm : Realm
{
    private SorceryRealm(Game savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Sorcery realm contains spells dealing with raw magic",
        "itself, for example spells dealing with magical items.",
        "It is the premier source of miscellaneous non-combat", 
        "utility spells."
    };
    public override string Name => "Sorcery";
    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.SorceryBook;

    /// <summary>
    /// Returns the Beginners Handbook, Master Sorcerers, Unaussprechlich Kulten and Liber Ivonis books because they belong to the Sorcery realm.
    /// </summary>
    protected override string[] SpellBookNames => new string[]
    {
        nameof(BeginnersHandbookSorceryBookItemFactory),
        nameof(MasterSorcerersHandbookSorceryBookItemFactory),
        nameof(UnaussprechlichenKultenSorceryBookItemFactory),
        nameof(LiberIvonisSorceryBookItemFactory)
    };
}