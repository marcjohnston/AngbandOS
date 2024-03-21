// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Realms;

[Serializable]
internal class DeathRealm : Realm
{
    private DeathRealm(SaveGame savedGame) : base(savedGame) { }

    public override string[] Info => new string[] {
        "The Death realm has a combination of life-draining spells,",
        "curses, and undead summoning. Like chaos, it is a very",
        "offensive realm."
    };
    public override string Name => "Death";
    public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.DeathBook;

    /// <summary>
    /// Returns the Black Prayers, Black Mass, Cultesdes Goules and Necronomicon books because they belong to the Death realm.
    /// </summary>
    protected override string[] SpellBookNames => new string[]
    {
        nameof(BlackPrayersDeathBookItemFactory),
        nameof(BlackMassDeathBookItemFactory),
        nameof(CultesdesGoulesDeathBookItemFactory),
        nameof(NecronomiconDeathBookItemFactory)
    };
    public override bool ResistantToHolyAndHellProjectiles => true;
}
