// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Realms;

[Serializable]
internal class ChaosRealm : Realm
{
    private ChaosRealm(Game savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Chaos realm is the most destructive realm. It focuses",
        "on combat spells. It is a very good choice for anyone who",
        "wants to be able to damage their foes directly, but is ",
        "somewhat lacking in non-combat spells."
    };

    public override string Name => "Chaos";
    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.ChaosBook;

    /// <summary>
    /// Returns the Sign Of Chaos, Mastery Chaos, Gharne Fragments and Azathoth Chaos books because they belong to the Chaos realm.
    /// </summary>
    protected override string[] SpellBookNames => new string[]
    {
        nameof(SignOfChaosChaosBookItemFactory),
        nameof(MasteryChaosBookItemFactory),
        nameof(GharneFragmentsChaosBookItemFactory),
        nameof(AzathothChaosBookItemFactory)
    };
}
