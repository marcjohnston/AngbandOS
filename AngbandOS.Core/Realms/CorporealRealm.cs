// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Realms;

[Serializable]
internal class CorporealRealm : Realm
{
    private CorporealRealm(Game savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Corporeal realm contains spells that exclusively affect",
        "the caster's body, although some spells also indirectly",
        "affect other creatures or objects. The corporeal realm is",
        "particularly good at sensing spells."
   };

    /// <summary>
    /// Returns the Basic Chi, Yogic Mastery, DeVermis Mysteriis and Pnakotic Manuscript books because they belong to the Corporeal realm.
    /// </summary>
    protected override string[] SpellBookNames => new string[]
    {
        nameof(BasicChiFlowCorporealBookItemFactory),
        nameof(YogicMasteryCorporealBookItemFactory),
        nameof(DeVermisMysteriisCorporealBookItemFactory),
        nameof(PnakoticManuscriptsCorporealBookItemFactory)
    };

    public override string Name => "Corporeal";
}
